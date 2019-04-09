using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface IGebruiker
    {
        #region Methods

        void Add(Gebruiker gebruiker);

        void Delete(Gebruiker gebruiker);

        IEnumerable<Gebruiker> GetAll();

        IEnumerable<Gebruiker> GetAllLedenNietLeden();

        IEnumerable<Gebruiker> GetAllNietLeden();

        IEnumerable<Gebruiker> GetAllLeden();

        Gebruiker GetBy(int id);

        Gebruiker GetBy(string email);

        void SaveChanges();

        #endregion Methods
    }
}