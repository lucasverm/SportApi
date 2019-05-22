using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectG05.Data.Repositories
{
    public class LesmateriaalRepository : ILesmateriaal
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Lesmateriaal> _lesmaterialen;
        private readonly DbSet<Raadpleging> _raadplegings;
        public LesmateriaalRepository(ApplicationDbContext context)
        {
            _context = context;
            _lesmaterialen = _context.Lesmaterialen;
            _raadplegings = _context.Raadplegingen;
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
            StringBuilder sb = new StringBuilder();
            List<Lesmateriaal> alleLesmaterialen = _lesmaterialen.ToList();
            List<string> raadHulp = new List<string>();
            alleLesmaterialen.ForEach(act =>
            {
                if (act.Raadplegingen == null)
                    act.Raadplegingen = new List<Raadpleging>();
                List<Raadpleging> raadplegingen = _raadplegings.Where(a => a.Lesmateriaal == act).Include(t => t.Lid).ToList();
                foreach (Raadpleging raad in raadplegingen)
                {
                    if (raad.Lesmateriaal != null)
                        if (raad.Lesmateriaal == act)
                        {
                            sb.Append(raad.Lesmateriaal.Id).Append("Lid").Append(" ").Append(raad.Lid.Voornaam).Append(" ").Append(raad.Lid.Naam).Append(" heeft op ").Append(raad.Datum.ToShortDateString()).Append(" ").Append(raad.TijdStip.Hours).Append(":").Append(raad.TijdStip.Minutes).Append(" ").Append("dit lesmateriaal ").Append(" geraadpleegd");
                            raadHulp.Add(sb.ToString());
                            sb.Clear();
                        }
                }
                act.RaadplegingenApi = raadHulp;
            });
            List<Lesmateriaal> lesmat = _lesmaterialen.Include(t => t.Afbeeldingen).Include(t => t.Videos).ToList();
            return lesmat;
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