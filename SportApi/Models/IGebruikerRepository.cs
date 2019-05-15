using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface IGebruikerRepository
    {
        #region Methods

        void Add(Gebruiker gebruiker);

        void Delete(Gebruiker gebruiker);

        void Replace(Gebruiker gebruiker);

        IEnumerable<Gebruiker> GetAll();

        IEnumerable<Gebruiker> GetAllLedenNietLeden();

        IEnumerable<Gebruiker> GetAllNietLeden();

        IEnumerable<Gebruiker> GetAllLeden();

        IEnumerable<Gebruiker> GetAllLesgevers();

        Gebruiker GetBy(int id);

        Gebruiker GetBy(string email);

        void SaveChanges();

        #endregion Methods
    }
}