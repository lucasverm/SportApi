using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class ActiviteitConfiguration : IEntityTypeConfiguration<Activiteit>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Activiteit> builder)
        {
            builder.ToTable("Activiteiten");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
            
            builder.HasMany(t => t.GebruikersApi).WithOne();
            builder.Ignore(t => t.GebruikersVoorActiviteit);
            builder.Ignore(t => t.GebruikersApi);
        }

        #endregion Methods
    }
}