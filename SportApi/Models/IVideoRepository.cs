using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectG05.Models.Domain
{
    public interface IVideoRepository
    {
        #region Methods

        void Add(Video video);

        void Delete(Video video);

        List<Video> GetAlleVideoDieHorenBijEenSpecifiekLesmateriaal(int id);

        void SaveChanges();

        #endregion Methods
    }
}
