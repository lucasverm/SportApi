using Microsoft.AspNetCore.Identity;
using ProjectG05.Models.Domain;
using SportApi.IRepos;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectG05.Data
{
    public class DataInitializer
    {
        #region Fields

        private ApplicationDbContext _dbContext;

        private List<Beheerder> beheerders;

        private List<Gebruiker> lesgevers;

        private List<Lid> leden;
        private List<NietLid> Nietleden;

        private ILes _lesRepository;

        private ISessie _sessieRepository;

        #endregion Fields

        #region Constructors

        public DataInitializer(ApplicationDbContext dbContext, ILes lesRepo, ISessie sessieRepository)
        {
            _dbContext = dbContext;
            _lesRepository = lesRepo;
            _sessieRepository = sessieRepository;
            beheerders = new List<Beheerder>();
            lesgevers = new List<Gebruiker>();
            leden = new List<Lid>();
            Nietleden = new List<NietLid>();
        }

        #endregion Constructors

        #region Methods

        public void InitializeData()
        {
            _dbContext.Database.EnsureDeleted();

            if (_dbContext.Database.EnsureCreated())
            {
                //lesmateriaal & afbeelding aanmaken
                Lesmateriaal lesMat1 = new Lesmateriaal(5, "oefening1", "Uitleg bij oefening 1", "duwen", new List<Afbeelding>(), new List<Video>(), new List<Commentaar>());
                _dbContext.Lesmaterialen.Add(lesMat1);
                Afbeelding a1 = new Afbeelding(lesMat1.Id, "adresNaarAfbeelding1");
                _dbContext.Afbeeldingen.Add(a1);
                Lesmateriaal lesMat2 = new Lesmateriaal(5, "oefening2", "Uitleg bij oefening 2", "duwen", new List<Afbeelding>(), new List<Video>(), new List<Commentaar>());
                _dbContext.Lesmaterialen.Add(lesMat2);
                Afbeelding a2 = new Afbeelding(lesMat2.Id, "adresNaarAfbeelding1");
                _dbContext.Afbeeldingen.Add(a1);

                //gebruiker aanmaken
                Gebruiker g = new Lesgever("Lucas", "Vermeulen", "pinksterbloemstraat", "19", "9030", "Gent", "0495192770", "lucasvermeulen@gmail.com", DateTime.Today, "Man");
                _dbContext.Gebruikers.Add(g);

                _dbContext.SaveChanges();
            }
        }

        #endregion Methods
    }
}