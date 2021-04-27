using System;
using Dapper;
using MicroserviceLibrary.Application.Configurations.Data;
using PlainClasses.Services.Platoon.Domain.Models.DomainServices;

namespace PlainClasses.Services.Platoon.Application.DomainServices
{
    public class ChangePlatoonForPerson : IChangePlatoonForPerson
    {
        // private readonly ISqlConnectionFactory _sqlConnectionFactory;
        //
        // public ChangePlatoonForPerson(ISqlConnectionFactory sqlConnectionFactory)
        // {
        //     _sqlConnectionFactory = sqlConnectionFactory;
        // }
        //
        // public void ChangePlatoon(Person person, Guid platoonId)
        // {
        //     var connection = _sqlConnectionFactory.GetOpenConnection();
        //     
        //     const string sqlPlatoon = "SELECT " + 
        //                               "[Platoon].[Id], " +
        //                               "[Platoon].[Acronym] " +
        //                               "FROM Platoons AS [Platoon] " +
        //                               "WHERE [Platoon].[Id] = @PlatoonId ";
        //     
        //     var platoon = connection.QuerySingleOrDefault<Domain.Models.Platoon>(sqlPlatoon, new { platoonId });
        //
        //     if (person.PlatoonId != platoon.Id)
        //     {
        //         person.ChangePlatoon(platoon);
        //     }
        // }
        //
        // public void ChangePlatoon(Person person) => person.ChangePlatoon();
    }
}