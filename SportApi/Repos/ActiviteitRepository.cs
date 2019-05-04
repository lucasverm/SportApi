using Microsoft.EntityFrameworkCore;
using ProjectG05.Data;
using ProjectG05.Models.Domain;
using SportApi.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportApi.Repos
{
    public class ActiviteitRepository : IActiviteit
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private readonly DbSet<Activiteit> _activiteiten;
        private readonly DbSet<GebruikerActiviteit> _gebruikerActiviteit;

        #endregion Fields

        #region Constructors

        public ActiviteitRepository(ApplicationDbContext context)
        {
            _context = context;
            _activiteiten = _context.Activiteiten;
            _gebruikerActiviteit = _context.GebruikerActiviteit;
        }

        #endregion Constructors

        #region Methods

        public void Add(Activiteit activiteit)
        {
            activiteit.GebruikersVoorActiviteit.ForEach(a =>
            {
                _gebruikerActiviteit.Add(new GebruikerActiviteit(activiteit, a));
            });
            _activiteiten.Add(activiteit);
            SaveChanges();
        }

        public void Update(Activiteit activiteit)
        {
            //alle activiteitleden van deze activiteit verwijderen
            List<GebruikerActiviteit> alleActiviteitLeden = _gebruikerActiviteit.ToList();
            alleActiviteitLeden.ForEach(gebruikerActiviteit =>
            {
                if (gebruikerActiviteit.Activiteit == activiteit)
                {
                    _gebruikerActiviteit.Remove(gebruikerActiviteit);
                }
            });

            //alle activiteitleden van deze activiteit opnieuw toevoegen
            activiteit.GebruikersVoorActiviteit.ForEach(a =>
            {
                _gebruikerActiviteit.Add(new GebruikerActiviteit(activiteit, a));
            });

            _activiteiten.Update(activiteit);
            SaveChanges();
        }

        public void Delete(Activiteit activiteit)
        {
            _activiteiten.Remove(activiteit);
            List<GebruikerActiviteit> verwijderen = _gebruikerActiviteit.ToList();
            verwijderen.ForEach(a =>
            {
                if (a.Activiteit == activiteit)
                {
                    _gebruikerActiviteit.Remove(a);
                }
            });
            SaveChanges();
        }



        public IEnumerable<Activiteit> GetAll()
        {
            List<Activiteit> alleActiviteitsen = _activiteiten.ToList();
            alleActiviteitsen.ForEach(activiteit =>
            {
                activiteit.GebruikersVoorActiviteit = new List<Gebruiker>();
                _gebruikerActiviteit.Where(k => k.Activiteit == activiteit).Include(l => l.Activiteit).Include(l => l.Gebruiker).ToList().ForEach(t =>
                {
                    activiteit.GebruikersVoorActiviteit.Add(t.Gebruiker);
                });
            });
            return alleActiviteitsen;
        }


        public Activiteit GetBy(int id)
        {
            Activiteit act = _activiteiten.SingleOrDefault(s => s.Id == id);
            if (act != null)
            {
                act.GebruikersVoorActiviteit = new List<Gebruiker>();
                _gebruikerActiviteit.Where(a => a.Activiteit == act).Include(i => i.Activiteit).Include(t => t.Gebruiker).ToList().ForEach(t =>
                {
                    Gebruiker gebruiker = new Gebruiker(t.Gebruiker.Voornaam, t.Gebruiker.Naam, t.Gebruiker.Straatnaam, t.Gebruiker.Huisnummer, t.Gebruiker.Postcode, t.Gebruiker.Stad, t.Gebruiker.Telefoonnummer, t.Gebruiker.Email, t.Gebruiker.Geboortedatum, t.Gebruiker.Geslacht, t.Gebruiker.Type);
                    act.GebruikersVoorActiviteit.Add(gebruiker);
                });
            }

            return act;
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion Methods

    }
}
