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

        private List<Beheerder> _beheerders;

        private List<Gebruiker> _lesgevers;

        private List<Lid> _leden;
        private List<NietLid> _Nietleden;

        private ILes _lesRepository;

        private ISessie _sessieRepository;

        #endregion Fields

        #region Constructors

        public DataInitializer(ApplicationDbContext dbContext, ILes lesRepo, ISessie sessieRepository)
        {
            _dbContext = dbContext;
            _lesRepository = lesRepo;
            _sessieRepository = sessieRepository;
            this._beheerders = new List<Beheerder>();
            _lesgevers = new List<Gebruiker>();
            _leden = new List<Lid>();
            _Nietleden = new List<NietLid>();
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
                Gebruiker lid = new Lid("Lid", "Achternaam", "lidstraat", "1", "9030", "Gent", "0495192770", "lucas@gmail.com", new DateTime(), "belg", "lucas@ouder.be", "98.05.26-367.73", "Gent", "man", 5);
                _dbContext.Gebruikers.Add(lid);
                lid = new Lid("Lid2", "Achternaam", "lidstraat", "1", "9030", "Gent", "0495192770", "lucas@gmail.com", new DateTime(), "belg", "lucas@ouder.be", "98.05.26-367.73", "Gent", "man", 5);
                _dbContext.Gebruikers.Add(lid);

                //lessen aanmaken
                List<Lid> LedenVoorLes = new List<Lid>();
                LedenVoorLes.Add((Lid)lid);

                Les l = new Les(g, new TimeSpan(12, 30, 0), new TimeSpan(2, 0, 0), DayOfWeek.Friday, LedenVoorLes);
                _dbContext.Lessen.Add(l);
                _dbContext.SaveChanges();
            }
        }

        #endregion Methods
    }
}