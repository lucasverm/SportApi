using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class SessieRepository : ISessie
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Sessie> _sessies;
        private readonly DbSet<GebruikerSessie> _gebruikerSessies;

        public SessieRepository(ApplicationDbContext context)
        {
            _context = context;
            _sessies = _context.Sessies;
            _gebruikerSessies = _context.GebruikerSessie;
        }

        public void Add(Sessie sessie)
        {
            if (sessie.Aanwezigen.Count != 0)
            {
                sessie.Aanwezigen.ForEach(a =>
                {
                    _gebruikerSessies.Add(new GebruikerSessie(sessie, a));
                    SaveChanges();
                });
            }

            _sessies.Add(sessie);
            SaveChanges();
        }

        public void Update(Sessie sessie)
        {
            //alle gebruiker sessies van deze sessie verwijderen
            List<GebruikerSessie> AlleGebruikerSessies = _gebruikerSessies.ToList();
            AlleGebruikerSessies.ForEach(GS =>
            {
                if (GS.Sessie == sessie)
                {
                    _gebruikerSessies.Remove(GS);
                }
            });

            //alle gebruikers toevoegen
            sessie.Aanwezigen.ForEach(a =>
                {
                    _gebruikerSessies.Add(new GebruikerSessie(sessie, a));
                });

            _sessies.Add(sessie);
            SaveChanges();


        }

        public Sessie AddAanwezige(Sessie s, Gebruiker g)
        {
            Sessie sessie = this.GetBy(s.Id);
            sessie.Aanwezigen.Add(g);
            _gebruikerSessies.Add(new GebruikerSessie(sessie, g));
            SaveChanges();
            return sessie;
        }

        public Sessie RemoveAanwezige(Sessie s, Gebruiker g)
        {
            Sessie sessie = this.GetBy(s.Id);
            sessie.Aanwezigen.Remove(g);
            var gebruikerVerwijderen = _gebruikerSessies.SingleOrDefault(t => t.Sessie == sessie && t.Gebruiker == g);
            _gebruikerSessies.Remove(gebruikerVerwijderen);
            SaveChanges();
            return sessie;
        }

        public void Delete(Sessie sessie)
        {
            _sessies.Remove(sessie);
            _gebruikerSessies.ToList().ForEach(t =>
            {
                if (t.Sessie.Equals(sessie))
                {
                    _gebruikerSessies.Remove(t);
                }
            });
            SaveChanges();
        }

        public IEnumerable<Sessie> GetAll()
        {
            List<Sessie> alleSessies = _sessies.ToList();
            alleSessies.ForEach(sesh =>
            {
                sesh.Aanwezigen = new List<Gebruiker>();
                _gebruikerSessies.Where(gs => gs.Sessie == sesh).Include(l => l.Sessie).Include(l => l.Gebruiker).ToList().ForEach(t =>
                {
                    sesh.Aanwezigen.Add(t.Gebruiker);
                });
            });
            return alleSessies.OrderBy(t => t.Id);
        }

        public Sessie GetBy(int id)
        {
            Sessie sesh = _sessies.SingleOrDefault(s => s.Id == id);
            sesh.Aanwezigen = new List<Gebruiker>();
            _gebruikerSessies.Where(gs => gs.Sessie == sesh).Include(l => l.Sessie).Include(l => l.Gebruiker).ToList().ForEach(t =>
            {
                sesh.Aanwezigen.Add(t.Gebruiker);
            });
            return sesh;
        }

        public Sessie GetCurrentSession()
        {
            Sessie sesh = _sessies.Include(t => t.Lesgever).Include(t => t.LedenVoorLes).FirstOrDefault(s => s.Bezig == true);
            sesh.Aanwezigen = new List<Gebruiker>();
            _gebruikerSessies.Where(gs => gs.Sessie == sesh).Include(l => l.Sessie).Include(l => l.Gebruiker).ToList().ForEach(t =>
            {
                sesh.Aanwezigen.Add(t.Gebruiker);
            });
            return sesh;
        }

        public Boolean noCurrentSession()
        {
            Sessie sesh = _sessies.Include(t => t.Lesgever).FirstOrDefault(s => s.Bezig == true);
            try
            {
                if (sesh.Equals(null))
                    return false;
                else
                    return true;
            }
            catch (NullReferenceException exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}