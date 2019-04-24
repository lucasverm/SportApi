﻿using System;

namespace ProjectG05.Models.Domain
{
    public class Beheerder : Gebruiker
    {
        #region Constructors

        public Beheerder()
        {
        }

        public Beheerder(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Beheerder")
        {
        }


        #endregion Constructors
    }
}