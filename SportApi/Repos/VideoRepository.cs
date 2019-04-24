using Microsoft.EntityFrameworkCore;
using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Data.Repositories
{
    public class VideoRepository : IVideo
    {
        #region Fields

        private readonly ApplicationDbContext _context;

        private readonly DbSet<Video> _videos;

        #endregion Fields

        #region Constructors

        public VideoRepository(ApplicationDbContext context)
        {
            _context = context;
            _videos = context.Videos;
        }

        #endregion Constructors

        #region Methods

        public void Add(Video video)
        {
            _videos.Add(video);
        }

        public void Delete(Video video)
        {

            _videos.Remove(video);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<Video> GetAlleVideoDieHorenBijEenSpecifiekLesmateriaal(int id)
        {
            return _videos.Where(a => a.LesmateriaalId == id).ToList();
        }

        public IEnumerable<Video> GetAll()
        {
            return _videos.ToList();
        }

        public Video GetBy(int id)
        {
            return _videos.SingleOrDefault(a => a.Id == id);
        }

        public void Update(Video video)
        {
            _videos.Update(video);
        }
        #endregion Methods
    }
}