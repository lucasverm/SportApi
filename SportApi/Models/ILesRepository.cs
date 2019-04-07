using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface ILesRepository
    {
        #region Methods

        void Add(Les les);

        void Delete(Les les);

        Les GeefVolgendeLes(DateTime now, Gebruiker lesgever);

        IEnumerable<Les> GetAll();

        Les GetBy(int id);

        void SaveChanges();

        #endregion Methods
    }
}