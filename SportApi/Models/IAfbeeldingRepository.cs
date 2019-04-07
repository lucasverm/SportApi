using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectG05.Models.Domain
{
    public interface IAfbeeldingRepository
    {
        #region Methods

        void Add(Afbeelding afbeelding);

        void Delete(Afbeelding afbeelding);

        //IEnumerable<Afbeelding> GetAll();

        List<Afbeelding> GetAlleAfbeeldingDieHorenBijEenSpecifiekLesmateriaal(int id);

        void SaveChanges();

        #endregion Methods
    }
}
