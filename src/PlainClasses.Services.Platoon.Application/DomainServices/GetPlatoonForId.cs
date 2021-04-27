using System;
using System.Threading.Tasks;
using Dapper;
using MicroserviceLibrary.Application.Configurations.Data;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.DomainServices
{
    public class GetPlatoonForId : IGetPlatoonForId
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetPlatoonForId(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }
        
        public Domain.Models.Platoon Get(Guid platoonId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoon = "SELECT " + 
                                      "[Platoon].[Id], " +
                                      "[Platoon].[Acronym] " +
                                      "FROM Platoons AS [Platoon] " +
                                      "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = connection.QuerySingleOrDefault<Domain.Models.Platoon>(sqlPlatoon, new { platoonId });

            return platoon;
        }
        
        public async Task<Domain.Models.Platoon> GetAsync(Guid platoonId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoon = "SELECT " + 
                                      "[Platoon].[Id] " +
                                      "FROM Platoons AS [Platoon] " +
                                      "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = await connection.QuerySingleOrDefaultAsync<Domain.Models.Platoon>(sqlPlatoon, new { platoonId });

            return platoon;
        }

        public async Task<Domain.Models.Platoon> GetDetailAsync(Guid platoonId)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            
            const string sqlPlatoon = "SELECT " + 
                                      "[Platoon].[Id], " +
                                      "[Platoon].[Name], " +
                                      "[Platoon].[Acronym], " +
                                      "[Platoon].[Commander] " +
                                      "FROM Platoons AS [Platoon] " +
                                      "WHERE [Platoon].[Id] = @PlatoonId ";
            
            var platoon = await connection.QuerySingleOrDefaultAsync<Domain.Models.Platoon>(sqlPlatoon, new { platoonId });

            return platoon;
        }
    }
}