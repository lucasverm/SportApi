using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface ICommentaarRepository
    {
        #region Methods

        void Add(Commentaar commentaar);

        void Delete(Commentaar commentaar);

        IEnumerable<Commentaar> GetAll();

        Commentaar GetBy(DateTime datum, TimeSpan tijdstip);

        
        void SaveChanges();
        IEnumerable<Commentaar> GetById(int id);

        #endregion Methods
    }
}