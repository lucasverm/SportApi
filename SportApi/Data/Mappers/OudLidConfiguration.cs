using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class OudLidConfiguration : IEntityTypeConfiguration<OudLid>
    {
        public void Configure(EntityTypeBuilder<OudLid> builder)
        {
            builder.ToTable("OudLeden");
        }
    }
}