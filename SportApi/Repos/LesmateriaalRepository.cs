using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class LesmateriaalRepository : ILesmateriaal
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Lesmateriaal> _lesmaterialen;
        public LesmateriaalRepository(ApplicationDbContext context)
        {
            _context = context;
            _lesmaterialen = _context.Lesmaterialen;
        }
        public void Add(Lesmateriaal lesmateriaal)
        {
            _lesmaterialen.Add(lesmateriaal);
            SaveChanges();
        }

        
        public void Update(Lesmateriaal lesmateriaal)
        {
            _lesmaterialen.Update(lesmateriaal);
            SaveChanges();
        }
        public void Delete(Lesmateriaal lesmateriaal)
        {
            _lesmaterialen.Remove(lesmateriaal);
            SaveChanges();
        }
        public IEnumerable<Lesmateriaal> GetAll()
        {
            return _lesmaterialen.Include(t => t.Afbeeldingen).Include(t => t.Videos).ToList();
        }

        public Lesmateriaal GetByGraad(int graad)
        {
            return _lesmaterialen.FirstOrDefault(l => l.Graad == graad);
        }

        public Lesmateriaal GetBy(int lesMateriaalId)
        {
            return _lesmaterialen.SingleOrDefault(l => l.Id == lesMateriaalId);
        }

        public IEnumerable<Lesmateriaal> GetVoorSpecifiekeGraad(int graad)
        {
            return _lesmaterialen.Where(l => l.Graad == graad).ToList();
        }

        public List<string> GetCategorieënVoorGraad(int graad)
        {
            List<string> cat = new List<string>();
            _lesmaterialen.Where(l => l.Graad == graad).ToList().ForEach(t =>
            {
                cat.Add(t.Categorie);
            });
            return cat;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}