using Dapper;
using MediatR;
using StarWars.Application.Dtos.Weapons;
using StarWars.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace StarWars.Application.Queries.Handlers
{
    public class GetWeaponsQueryHandler : IRequestHandler<GetWeaponsQuery, IReadOnlyList<GetWeaponsDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetWeaponsQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IReadOnlyList<GetWeaponsDto>> Handle(GetWeaponsQuery request, CancellationToken cancellationToken)
        {
            const string sql = "SELECT * FROM Weapons";
            var connection = _sqlConnectionFactory.GetOpenConnection();
            var list = await connection.QueryAsync<GetWeaponsDto>(sql);

            return list.AsList();
        }

    }
}