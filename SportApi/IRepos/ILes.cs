using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.IRepos
{
    public interface ILes
    {
        #region Methods

        void Add(Les les);

        void Delete(Les les);

        //Les GeefVolgendeLes(DateTime now, Gebruiker lesgever);

        IEnumerable<Les> GetAll();

        Les GetBy(int id);

        void SaveChanges();

        void Update(Les les);

        #endregion Methods
    }
}
