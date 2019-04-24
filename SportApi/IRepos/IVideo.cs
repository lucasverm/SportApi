using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectG05.Models.Domain
{
    public interface IAfbeelding
    {
        #region Methods

        void Update(Afbeelding afbeelding);
        Afbeelding GetBy(int id);
        void Add(Afbeelding afbeelding);

        void Delete(Afbeelding afbeelding);

        IEnumerable<Afbeelding> GetAll();

        List<Afbeelding> GetAlleAfbeeldingDieHorenBijEenSpecifiekLesmateriaal(int id);

        void SaveChanges();

        #endregion Methods
    }
}
