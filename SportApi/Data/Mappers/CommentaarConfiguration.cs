using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data.Mappers
{
    public class CommentaarConfiguration : IEntityTypeConfiguration<Commentaar>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<Commentaar> builder)
        {
            builder.ToTable("Commentaren");
            builder.HasKey(t => new { t.Datum, t.TijdStip });
            builder.HasOne(t => t.Lid).WithMany().IsRequired();
            builder.HasOne(c => c.Lesmateriaal).WithMany().HasForeignKey(c => c.Id);
        }

        #endregion Methods
    }
}