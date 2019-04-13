using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public interface ICommentaar
    {
        #region Methods
        void Update(Commentaar commentaar);
        void Add(Commentaar commentaar);

        void Delete(Commentaar commentaar);

        IEnumerable<Commentaar> GetAll();

        Commentaar GetBy(DateTime datum, TimeSpan tijdstip);
        void SaveChanges();
        Commentaar GetBy(int id);

        #endregion Methods
    }
}