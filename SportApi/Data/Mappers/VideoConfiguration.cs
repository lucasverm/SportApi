using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Videos");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id).ValueGeneratedOnAdd();
        }

        #endregion Methods
    }
}