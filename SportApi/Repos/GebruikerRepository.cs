using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class GebruikerRepository : IGebruiker
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        private readonly DbSet<Gebruiker> _gebruikers;

        private readonly DbSet<GebruikerSessie> _gebruikerSessies;

        private readonly DbSet<Les> _lessen;

        #endregion Fields

        #region Constructors

        public GebruikerRepository(ApplicationDbContext context)
        {
            _context = context;
            _gebruikers = context.Gebruikers;
            _gebruikerSessies = context.GebruikerSessie;
            _lessen = context.Lessen;
        }

        #endregion Constructors

        #region Methods

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public int GeefScoreBord()
        {
            int puntenVanGebruiker = 0;
            int aantalLessenVanGebruiker = 0;
            int puntenToevoegenBijAanwezigheid = 0;
            var gebruiker = (Lid) this.GetBy(1);
            if (gebruiker == null) return 0;

            _lessen.ToList().ForEach(t =>
           {
               t.LedenVoorLes.ForEach(i =>
               {
                   if (i.Id == 1)
                   {
                       aantalLessenVanGebruiker += 1;
                   }
               });
           });
            if(aantalLessenVanGebruiker == 2)
            {
                puntenToevoegenBijAanwezigheid = 5;
            }
            else if (aantalLessenVanGebruiker == 1)
            {
                puntenToevoegenBijAanwezigheid = 10;
            }
            else
            {
                Debug.WriteLine("----------------------------------------");
                Debug.WriteLine("De gebruiker bezit geen 1/2 lessen!!");
            }
            _gebruikerSessies.ToList().ForEach(t =>
            {
                if (t.Gebruiker.Id == gebruiker.Id)
                {
                    puntenVanGebruiker += puntenToevoegenBijAanwezigheid;
                }
            });

            Debug.WriteLine("---------------------------");
            Debug.WriteLine(gebruiker.Naam + " heeft " + puntenVanGebruiker);
            return puntenVanGebruiker;


        }

        public void Update(Gebruiker gebruiker)
        {

            _gebruikers.Update(gebruiker);

        }

        public void Delete(Gebruiker gebruiker)
        {
            _gebruikers.Remove(gebruiker);
            Gebruiker gebruik = GetBy(gebruiker.Id);
            _gebruikers.Remove(gebruiker);
            SaveChanges();

        }

        public void Replace(Gebruiker gebruiker, int id)
        {
            Gebruiker geb = GetBy(id);
            geb = gebruiker;
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.OrderBy(t => t.Voornaam).ToList();
        }

        public IEnumerable<Gebruiker> GetAllLedenNietLeden()
        {
            return _gebruikers.Where(c => c.GetType() == typeof(Lid) || c.GetType() == typeof(NietLid)).OrderBy(t => t.Voornaam).ToList();
        }

        public IEnumerable<Gebruiker> GetAllNietLeden()
        {
            return _gebruikers.Where(c => c.GetType() == typeof(NietLid)).OrderBy(t => t.Voornaam).ToList();
        }

        public IEnumerable<Gebruiker> GetAllLeden()
        {
            return _gebruikers.Where(c => c.GetType() == typeof(Lid)).OrderBy(t => t.Voornaam).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Gebruiker GetBy(int id)
        {
            Gebruiker gebruiker = _gebruikers.SingleOrDefault(g => g.Id == id);
            return gebruiker;
        }

        public Gebruiker GetByApiId(int id)
        {
            Gebruiker gebruiker = _gebruikers.SingleOrDefault(g => g.IdApi == id);
            return gebruiker;
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers.SingleOrDefault(g => g.Email == email);
        }

        public IEnumerable<Gebruiker> GetAllLesgevers()
        {
            return _gebruikers.Where(c => c.GetType() == typeof(Lesgever)).OrderBy(t => t.Voornaam).ToList();
        }

        public IEnumerable<Gebruiker> GetAllBeheerders()
        {
            return _gebruikers.Where(c => c.GetType() == typeof(Beheerder)).OrderBy(t => t.Voornaam).ToList();
        }

        #endregion Methods
    }
}