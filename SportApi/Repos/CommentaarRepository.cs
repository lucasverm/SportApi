using Microsoft.EntityFrameworkCore; 
using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class CommentaarRepository : ICommentaar

    {
        private ApplicationDbContext _context;
        private DbSet<Commentaar> _commentaren;

        public CommentaarRepository(ApplicationDbContext context)
        {
            _context = context;
            _commentaren = context.Commentaren;
        }

        public IEnumerable<Commentaar> GetByLesmateriaal(int id)
        {
            return _commentaren.Where(e =>e.Lesmateriaal.Id == id);
        }

        public void Update(Commentaar commentaar)
        {
            _commentaren.Update(commentaar);
        }
        public void Add(Commentaar commentaar)
        {
            _commentaren.Add(commentaar);
            SaveChanges();
        }

        public void Delete(Commentaar commentaar)
        {
            _commentaren.Remove(commentaar);
            SaveChanges();
        }

        public IEnumerable<Commentaar> GetAll()
        {
            return _commentaren.Include(e => e.Lesmateriaal).Include(e => e.Lid).ToList();
        }

        public Commentaar GetBy(DateTime datum, TimeSpan tijdstip)
        {
            return _commentaren.Include(e => e.Lesmateriaal).Include(e => e.Lid).FirstOrDefault(l => l.Datum == datum && l.TijdStip == tijdstip);
        }

        public Commentaar GetBy(int id)
        {
            return _commentaren.Include(e => e.Lesmateriaal).Include(e => e.Lid).SingleOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}