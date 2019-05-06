using System;

namespace ProjectG05.Models.Domain
{
    public class Lesgever : Gebruiker
    {
        #region Constructors

        public Lesgever()
        {
        }

        public Lesgever(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lesgever")
        {
        }

        public override string ToString()
        {
            return this.Naam;
        }

        #endregion Constructors
    }
}