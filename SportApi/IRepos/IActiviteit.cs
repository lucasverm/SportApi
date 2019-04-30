using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.IRepos
{
    public interface IActiviteit
    {
        #region Methods

        void Add(Activiteit activiteit);

        void Delete(Activiteit activiteit);

        //Activiteit GeefVolgendeActiviteit(DateTime now, Gebruiker activiteitgever);

        IEnumerable<Activiteit> GetAll();

        Activiteit GetBy(int id);

        void SaveChanges();

        void Update(Activiteit activiteit);

        #endregion Methods
    }
}
