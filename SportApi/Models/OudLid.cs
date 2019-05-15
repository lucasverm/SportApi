using System;

namespace ProjectG05.Models.Domain
{
    public class OudLid : Gebruiker
    {
        #region Properties

        public DateTime UitschrijvingsDatum { get; set; }
        public int Graad { get; set; }

        #endregion Properties

        #region Constructors

        public OudLid()
        {
            UitschrijvingsDatum = DateTime.Today;
        }

        public OudLid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Oudlid")
        {
            UitschrijvingsDatum = DateTime.Today;
        }

        #endregion Constructors
    }
}