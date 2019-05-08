using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface IGebruiker
    {
        #region Methods

        IEnumerable<Gebruiker> GetAllLesgevers();

        IEnumerable<Gebruiker> GetAllBeheerders();

        void Add(Gebruiker gebruiker);

        void Delete(Gebruiker gebruiker);

        IEnumerable<Gebruiker> GetAll();

        IEnumerable<Gebruiker> GetAllLedenNietLeden();

        IEnumerable<Gebruiker> GetAllNietLeden();

        IEnumerable<Gebruiker> GetAllLeden();

        Gebruiker GetBy(int id);

        Gebruiker GetBy(string email);

        void SaveChanges();

        void Update(Gebruiker gebruiker);

        #endregion Methods
    }
}