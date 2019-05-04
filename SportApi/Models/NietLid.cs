using System;

namespace ProjectG05.Models.Domain
{
    public class NietLid : Gebruiker
    {
        #region Properties
        public int Graad { get; set; }
        #endregion Properties
        #region Constructors



        public NietLid()
        {
            Graad = 1;
        }

        public NietLid(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "NietLid")
        {
            Graad = 1;
        }



        #endregion Constructors
    }
}