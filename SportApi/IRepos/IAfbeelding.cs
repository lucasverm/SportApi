using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectG05.Models.Domain
{
    public interface IVideo
    {
        #region Methods

        void Update(Video video);
        Video GetBy(int id);
        void Add(Video video);

        void Delete(Video video);

        IEnumerable<Video> GetAll();

        List<Video> GetAlleVideoDieHorenBijEenSpecifiekLesmateriaal(int id);

        void SaveChanges();

        #endregion Methods
    }
}
