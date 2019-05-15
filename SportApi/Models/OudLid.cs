using System;

namespace ProjectG05.Models.Domain
{
    public class OudLid : Gebruiker
    {
        #region Properties

        //public DateTime UitschrijvingsDatum { get; set; }
        public int Graad { get; set; }

        #endregion Properties

        #region Constructors

        public OudLid()
        {
        }

        public OudLid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "OudLid")
        {
        }

        public OudLid(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "OudLid")
        {
        }

        #endregion Constructors
    }
}