using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectG05.Data.Mappers;
using ProjectG05.Models.Domain;

namespace ProjectG05.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Properties

        public DbSet<Beheerder> Beheerders { get; set; }

        public DbSet<Lid> Leden { get; set; }

        public DbSet<Lesgever> Lesgevers { get; set; }

        public DbSet<LesLid> LesLid { get; set; }

        public DbSet<Les> Lessen { get; set; }


        public DbSet<Sessie> Sessies { get; set; }

        public DbSet<GebruikerSessie> GebruikerSessie { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }

        public DbSet<Lesmateriaal> Lesmaterialen { get; set; }
        public DbSet<Raadpleging> Raadplegingen { get; set; }
        public DbSet<Afbeelding> Afbeeldingen { get; set; }
        public DbSet<Commentaar> Commentaren { get; set; }

        public DbSet<Video> Videos { get; set; }

        #endregion Properties

        #region Constructors

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion Constructors

        #region Methods

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new LidConfiguration());
            builder.ApplyConfiguration(new LesLidConfiguration());
            builder.ApplyConfiguration(new LesgeverConfiguration());
            builder.ApplyConfiguration(new BeheerderConfiguration());
            builder.ApplyConfiguration(new SessieConfiguration());
            builder.ApplyConfiguration(new LesConfiguration());
            builder.ApplyConfiguration(new RaadplegingConfiguration());
            builder.ApplyConfiguration(new LesmateriaalConfiguration());
            builder.ApplyConfiguration(new GebruikerSessieConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new NietLidConfiguration());
            builder.ApplyConfiguration(new CommentaarConfiguration());
            builder.ApplyConfiguration(new AfbeeldingConfiguration());
            builder.ApplyConfiguration(new VideoConfiguration());
        }

        #endregion Methods
    }
}