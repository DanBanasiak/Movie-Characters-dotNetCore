using Dapper;
using MediatR;
using StarWars.Application.Dtos.CharacterEpisodes;
using StarWars.Application.Dtos.Characters;
using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Dtos.Friends;
using StarWars.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetCharactersQueryHandler : IRequestHandler<GetCharactersQuery, IReadOnlyList<GetCharacterDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetCharactersQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IReadOnlyList<GetCharacterDto>> Handle(GetCharactersQuery request, CancellationToken cancellationToken)
        {
            const string sql =
                "SELECT c.CharacterId, c.CreatedAt, c.Name, c.Strength, c.Defense, c.Intelligence, " +
                "e.Name as EpisodeName, e.EpisodeId, f.Name as FriendName, f.CharacterId as FriendId " +
                "FROM characters c " +
                "LEFT JOIN characterEpisodes ec ON ec.CharacterId = c.CharacterId " +
                "LEFT JOIN episodes e ON e.EpisodeId = ec.EpisodeId " +
                "LEFT JOIN CharacterFriends ef ON ef.CharacterId = c.CharacterId " +
                "LEFT JOIN Characters f ON f.CharacterId = ef.FriendId";
                //"ORDER BY c.CreatedAt " +
                //"OFFSET @Offset ROWS " +
                //"FETCH NEXT @PageSize ROWS ONLY";

            var connection = _sqlConnectionFactory.GetOpenConnection();

            var list = await connection.QueryAsync<GetCharacterDto, DynamicFriendEpisodeDto, GetCharacterDto>(
                sql, (character, dynamicValue) =>
                {
                    //todo: Map Name, Defense, etc. from GetCharacterDto, not DynamicFriendEpisodeDto
                    character.Name = dynamicValue.Name;
                    character.Intelligence = dynamicValue.Intelligence;
                    character.Strength = dynamicValue.Strength;
                    character.Defense = dynamicValue.Defense;

                    if (dynamicValue.EpisodeId > 0)
                    {
                        character.Episodes.Add(new GetEpisodeDto()
                        {
                            EpisodeId = dynamicValue.EpisodeId,
                            Name = dynamicValue.EpisodeName
                        });
                    }

                    if (dynamicValue.FriendId > 0)
                    {
                        character.Friends.Add(new GetFriendDto()
                        {
                            CharacterId = dynamicValue.FriendId,
                            FriendName = dynamicValue.FriendName,
                        });
                    }
                    return character;
                }, new
                {
                    Offset = request.ProductSpecParams.PageIndex,
                    request.ProductSpecParams.PageSize
                }, splitOn: "Name");

            return list.AsList();
        }
    }
}