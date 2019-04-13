using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface ILesmateriaal
    {
        #region Methods

        void Update(Lesmateriaal lesmateriaal);

        void Add(Lesmateriaal lesmateriaal);

        void Delete(Lesmateriaal lesmateriaal);

        IEnumerable<Lesmateriaal> GetAll();

        Lesmateriaal GetByGraad(int graad);

        IEnumerable<Lesmateriaal> GetVoorSpecifiekeGraad(int graad);

        Lesmateriaal GetBy(int lesMateriaalId);

        List<string> GetCategorieënVoorGraad(int graad);

        void SaveChanges();


        #endregion Methods
    }
}