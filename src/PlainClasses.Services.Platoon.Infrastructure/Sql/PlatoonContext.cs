using MicroserviceLibrary.Application.Configurations.Options;
using MicroserviceLibrary.Infrastructure.Databases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PlainClasses.Services.Platoon.Infrastructure.Sql
{
    public class PlatoonContext : AbstractApplicationDbContext
    {
        #region DbSets
        
        public DbSet<Domain.Models.Platoon> Platoons { get; set; }

        #endregion
        
        public PlatoonContext(IOptions<SqlOption> options) : base(options, "PlainClasses.Services.Platoon.Api") { }
    }
}