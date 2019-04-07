using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class NietLidConfiguration : IEntityTypeConfiguration<NietLid>
    {
        public void Configure(EntityTypeBuilder<NietLid> builder)
        {
            builder.ToTable("NietLeden");
        }
    }
}