using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class AfbeeldingRepository : IAfbeelding
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        private readonly DbSet<Afbeelding> _afbeeldingen;

        #endregion Fields

        #region Constructors

        public AfbeeldingRepository(ApplicationDbContext context)
        {
            _context = context;
            _afbeeldingen = context.Afbeeldingen;
        }

        #endregion Constructors

        #region Methods

        public void Add(Afbeelding afbeelding)
        {
            _afbeeldingen.Add(afbeelding);
        }

        public void Delete(Afbeelding afbeelding)
        {

            _afbeeldingen.Remove(afbeelding);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Afbeelding> GetAlleAfbeeldingDieHorenBijEenSpecifiekLesmateriaal(int id)
        {
            return _afbeeldingen.Where(a => a.LesmateriaalId == id).ToList();
        }

        public IEnumerable<Afbeelding> GetAll()
        {
            return _afbeeldingen.ToList();
        }

        public Afbeelding GetBy(int id)
        {
            return _afbeeldingen.SingleOrDefault(a => a.Id == id);
        }

        public void Update(Afbeelding afbeelding)
        {
            _afbeeldingen.Update(afbeelding);
        }
        #endregion Methods
    }
}