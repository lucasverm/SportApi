using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface ILesmateriaal
    {
        #region Methods

        void Add(Lesmateriaal lesmateriaal);

        void Delete(Lesmateriaal lesmateriaal);

        IEnumerable<Lesmateriaal> GetAll();

        Lesmateriaal GetByGraad(int graad);

        IEnumerable<Lesmateriaal> GetVoorSpecifiekeGraad(int graad);

        Lesmateriaal GetById(int lesMateriaalId);

        List<string> GetCategorieënVoorGraad(int graad);

        void SaveChanges();


        #endregion Methods
    }
}