using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface IRaadplegingRepository
    {
        #region Methods

        void Add(Raadpleging raadpleging);

        void Delete(Raadpleging raadpleging);

        IEnumerable<Raadpleging> GetAll();

        Raadpleging GetBy(DateTime datum, TimeSpan tijdstip);
        void SaveChanges();

        #endregion Methods
    }
}