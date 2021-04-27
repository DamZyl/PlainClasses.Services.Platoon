using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlainClasses.Services.Platoon.Infrastructure.Sql.Configurations
{
    public class PlatoonConfiguration : IEntityTypeConfiguration<Domain.Models.Platoon>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Platoon> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}