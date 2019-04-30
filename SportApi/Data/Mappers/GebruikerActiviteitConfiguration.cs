using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class GebruikerActiviteitConfiguration : IEntityTypeConfiguration<GebruikerActiviteit>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<GebruikerActiviteit> builder)
        {
            builder.ToTable("GebruikerActiviteit");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
        }

        #endregion Methods
    }
}