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
        private readonly IGebruiker _gebruikerRepository;

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
            //activiteit.GebruikersApi.ForEach(a =>
            //{
            //    _gebruikerActiviteit.Add(new GebruikerActiviteit(activiteit, a));
            //});
            List<GebruikerActiviteit> alleActiviteitLeden = _gebruikerActiviteit.ToList();
            alleActiviteitLeden.ForEach(gebruikerActiviteit =>
            {
                if (gebruikerActiviteit.Activiteit == activiteit)
                {
                    _gebruikerActiviteit.Remove(gebruikerActiviteit);
                }
            });

            //alle activiteitleden van deze activiteit opnieuw toevoegen
            if (activiteit.GebruikersApi != null)
            {
                activiteit.GebruikersApi.ForEach(a =>
                {
                    _gebruikerActiviteit.Add(new GebruikerActiviteit(activiteit, a));
                });
            }
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
            if (activiteit.GebruikersApi != null)
            {
                activiteit.GebruikersApi.ForEach(a =>
                {
                    _gebruikerActiviteit.Add(new GebruikerActiviteit(activiteit, a));
                });
            }

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
            List<int> gebruikersAct = new List<int>();
            List<Activiteit> hulpList = new List<Activiteit>();
            alleActiviteitsen.ForEach(act =>
            {
                gebruikersAct.Clear();
                if (act.GebruikersApi == null)
                    act.GebruikersApi = new List<Gebruiker>();
                List<GebruikerActiviteit> gebruikerActiviteits = _gebruikerActiviteit.Where(a => a.Activiteit.Id == act.Id).Include(i => i.Activiteit).Include(t => t.Gebruiker).ToList();
                foreach(GebruikerActiviteit geb in gebruikerActiviteits)
                {
                    if (geb.Activiteit.Id == act.Id)
                    {
                        if(geb.Gebruiker != null)
                        gebruikersAct.Add(geb.Gebruiker.Id);
                        act.GebruikersApi.Add(geb.Gebruiker);
                    }
                       
                }
                //_gebruikerActiviteit.Where(a => a.Activiteit.Id == act.Id).Include(i => i.Activiteit).Include(t => t.Gebruiker).ToList().ForEach(t =>
                //{
                //    if (t.Gebruiker.IdApi != 0)
                //    {
                //        gebruikersAct.Add(t.Gebruiker.IdApi);
                //    }
                //    else
                //    {
                //        if(t.Activiteit.Id == t.Activiteit.Id)
                //        gebruikersAct.Add(t.Gebruiker.Id);
                //    }
                //});
                hulpList.Add(act);
                Activiteit hulpact = act;
      //          hulpList.Add(hulpact);
      //          hulpact = null;
            });
            alleActiviteitsen.Clear();
            foreach(Activiteit a in hulpList)
            {
                List<int> hulpints = new List<int>();
                foreach(Gebruiker gebruiker in a.GebruikersApi)
                {
                    if(gebruiker != null)
                    hulpints.Add(gebruiker.Id);
                }
                a.GebruikersVoorActiviteit = hulpints;
                alleActiviteitsen.Add(a);
                hulpints.Clear();
            }
            return alleActiviteitsen;
        }

        public Activiteit GetBy(int id)
        {
            Activiteit act = _activiteiten.SingleOrDefault(s => s.Id == id);
            if (act != null)
            {
                act.GebruikersApi = new List<Gebruiker>();
                List<Gebruiker> geb = new List<Gebruiker>();
                try
                {
                    _gebruikerActiviteit.Where(a => a.Activiteit == act).Include(i => i.Activiteit).Include(t => t.Gebruiker).ToList().ForEach(t =>
                    {
                        act.GebruikersVoorActiviteit = new List<int>();
                        //Gebruiker gebruiker = new Gebruiker(t.Gebruiker.Voornaam, t.Gebruiker.Naam, t.Gebruiker.Straatnaam, t.Gebruiker.Huisnummer, t.Gebruiker.Busnummer, t.Gebruiker.Postcode, t.Gebruiker.Stad, t.Gebruiker.Telefoonnummer, t.Gebruiker.Email, t.Gebruiker.GeboorteDatum, t.Gebruiker.Geslacht, t.Gebruiker.Type);
                        // Gebruiker gebruiker = _
                        //    if (t.Id != 0)
                        //        gebruiker.Id = t.Id;
                        //    act.GebruikersApi.Add(gebruiker);
                        //    if (gebruiker.Id != 0)
                        //          act.GebruikersVoorActiviteit.Add(gebruiker.Id);
                        //      else
                        if (t.Gebruiker.IdApi != 0)
                            //act.GebruikersVoorActiviteit.Add(t.Gebruiker.IdApi);
                            geb.Add(t.Gebruiker);
                        else
                            //act.GebruikersVoorActiviteit.Add(t.Gebruiker.Id);
                            geb.Add(t.Gebruiker);
                        act.GebruikersApi = geb;
                    });

                }
                catch(Exception e)
                {
                   act = _activiteiten.SingleOrDefault(s => s.Id == id);
                    return act;
                }
              
            }
            //      _activiteiten.SingleOrDefault(s => s.Id == id);
            //        if (act != null)
            //List<int> ids = new List<int>();
            //foreach(Gebruiker gebruiker in act.GebruikersApi)
            //{
            //    if (gebruiker.Id != 0)
            //        ids.Add(gebruiker.Id);
            //    else
            //        ids.Add(gebruiker.IdApi);
            //}
            //act.GebruikersVoorActiviteit = ids;

            return act;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion Methods
    }
}