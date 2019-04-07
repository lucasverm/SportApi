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
            return _commentaren.ToList();
        }

        public Commentaar GetBy(DateTime datum, TimeSpan tijdstip)
        {
            return _commentaren.FirstOrDefault(l => l.Datum == datum && l.TijdStip == tijdstip);
        }

        public IEnumerable<Commentaar> GetById(int id)
        {
            return _commentaren.Where(c => c.Id == id); //Id is niet specifiek want dit id hoort bij een lesmateriaal. Dus je kan meerdere commentaren hebben met hetzelfde id. (wanneer 2 mensen reageren op het zelfde lesmateriaal)
            //return _commentaren.Where(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}