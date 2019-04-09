using Microsoft.EntityFrameworkCore;
using ProjectG05.Data;
using ProjectG05.Models.Domain;
using SportApi.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportApi.Repos
{
        public class LesRepository : ILes
        {
            #region Fields

            private readonly ApplicationDbContext _context;
            private readonly DbSet<Les> _lessen;
            private readonly DbSet<LesLid> _LesLid;

            #endregion Fields

            #region Constructors

            public LesRepository(ApplicationDbContext context)
            {
                _context = context;
                _lessen = _context.Lessen;
                _LesLid = _context.LesLid;
            }

            #endregion Constructors

            #region Methods

            public void Add(Les les)
            {
                les.LedenVoorLes.ForEach(a =>
                {
                    _LesLid.Add(new LesLid(les, a));
                });
                _lessen.Add(les);
                SaveChanges();
            }

            public void Delete(Les les)
            {
                _lessen.Remove(les);
                List<LesLid> verwijderen = _LesLid.ToList();
                verwijderen.ForEach(a =>
                {
                    if (a.Les == les)
                    {
                        _LesLid.Remove(a);
                    }
                });
                SaveChanges();
            }

            

            public IEnumerable<Les> GetAll()
            {
                List<Les> alleLessen = _lessen.ToList();
                alleLessen.ForEach(les =>
                {
                    les.LedenVoorLes = new List<Lid>();
                    _LesLid.Where(k => k.Les == les).Include(l => l.Les).Include(l => l.Lid).ToList().ForEach(t =>
                    {
                        les.LedenVoorLes.Add(t.Lid);
                    });
                });
                return alleLessen;
            }

            public List<Les> GeefLessenVanLesgever(Gebruiker lesgever)
            {
                List<Les> alleLessenVanLesgever = _lessen.Where(a => a.Lesgever == lesgever).ToList();
                alleLessenVanLesgever.ForEach(LesVanLesgever =>
                {
                    LesVanLesgever.LedenVoorLes = new List<Lid>();
                    _LesLid.Where(LesLid => LesLid.Les == LesVanLesgever).Include(l => l.Les).Include(l => l.Lid).ToList().ForEach(LesLidVanLesgever =>
                    {
                        LesVanLesgever.LedenVoorLes.Add(LesLidVanLesgever.Lid);
                    });
                });
                return alleLessenVanLesgever;
            }

            public Les GetBy(int id)
            {
                Les l = _lessen.SingleOrDefault(s => s.Id == id);
                _LesLid.Where(a => a.Les == l).Include(i => i.Les).Include(t => t.Lid).ToList().ForEach(t =>
                {
                    Lid lid = new Lid(t.Lid.Naam, t.Lid.Voornaam, t.Lid.Straatnaam, t.Lid.Huisnummer, t.Lid.Postcode, t.Lid.Stad, t.Lid.Telefoonnummer, t.Lid.Email, t.Lid.Geboortedatum, t.Lid.Nationaleit, t.Lid.EmailOuders, t.Lid.Rijksregisternummer, t.Lid.GeborenTe, t.Lid.Geslacht, t.Lid.InschrijvingsDatum, t.Lid.Graad);
                    l.LedenVoorLes.Add(lid);
                });
                return l;
            }

            public void SaveChanges()
            {
                _context.SaveChanges();
            }

            #endregion Methods
        
    }
}
