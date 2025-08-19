using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace LibeyTechnicalTestDomain.EFCore.Configuration
{
    public class UbigeoConfiguration : IEntityTypeConfiguration<Ubigeo>
    {
        public void Configure(EntityTypeBuilder<Ubigeo> builder)
        {
            builder.ToTable("Ubigeo");
            builder.HasKey(u => u.UbigeoCode);
        }
    }
}