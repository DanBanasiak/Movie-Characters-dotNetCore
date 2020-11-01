using Dapper;
using MediatR;
using StarWars.Application.Dtos.Episodes;
using StarWars.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetEpisodesQueryHandler : IRequestHandler<GetEpisodesQuery, IReadOnlyList<GetEpisodeDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetEpisodesQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IReadOnlyList<GetEpisodeDto>> Handle(GetEpisodesQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM Episodes";
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var list = await connection.QueryAsync<GetEpisodeDto>(sql);

            return list.AsList();
        }
    }
}