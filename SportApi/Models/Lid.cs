using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectG05.Models.Domain
{
    public class Lid : Gebruiker
    {
        #region Fields

        private string _nationaliteit;
        private string _emailOuders;
        private string _rijksregisternummer;
        private string _geborenTe;
        private Boolean _akkoordMetHuishoudelijkRegelement;
        private Boolean _toestemmingAudioVisueelMateriaal;
        private Boolean _wenstInfoTeKrijgenOverClubAangelegenheden;
        private Boolean _wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;

        #endregion Fields

        #region Properties

        public DateTime InschrijvingsDatum { get; set; }
        public List<Les> LessenVanLid { get; set; }

        public string Nationaliteit { get; set; }

        public string EmailOuders { get; set; }

        public string Rijksregisternummer { get; set; }

        public string GeborenTe { get; set; }

        public Boolean AkkoordMetHuishoudelijkRegelement { get; set; }

        public Boolean ToestemmingAudioVisueelMateriaal { get; set; }

        public Boolean WenstInfoTeKrijgenOverClubAangelegenheden { get; set;}

        public Boolean WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties { get; set; }

        public int Graad { get; set; }

        #endregion Properties

        #region Constructors
        //Datainitializer
        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = true;
            ToestemmingAudioVisueelMateriaal = false;
            WenstInfoTeKrijgenOverClubAangelegenheden = false;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = false;
            InschrijvingsDatum = new DateTime();
            Graad = graad;
        }
        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = true;
            ToestemmingAudioVisueelMateriaal = false;
            WenstInfoTeKrijgenOverClubAangelegenheden = false;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = false;
            InschrijvingsDatum = new DateTime();
            Graad = graad;
        }
        //Lesrepo
        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, DateTime inschrijvingsDatum, int graad) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = true;
            ToestemmingAudioVisueelMateriaal = false;
            WenstInfoTeKrijgenOverClubAangelegenheden = false;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = false;
            InschrijvingsDatum = inschrijvingsDatum;
            Graad = graad;
        }
        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, Boolean akkoordMetHuishoudelijkRegelement, Boolean toestemmingAudioVisueelMateriaal, Boolean wenstInfoTeKrijgenOverClubAangelegenheden, Boolean wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = akkoordMetHuishoudelijkRegelement;
            ToestemmingAudioVisueelMateriaal = toestemmingAudioVisueelMateriaal;
            WenstInfoTeKrijgenOverClubAangelegenheden = wenstInfoTeKrijgenOverClubAangelegenheden;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;
            InschrijvingsDatum = new DateTime();
            Graad = graad;
        }

        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, DateTime inschrijvingsDatum, Boolean akkoordMetHuishoudelijkRegelement, Boolean toestemmingAudioVisueelMateriaal, Boolean wenstInfoTeKrijgenOverClubAangelegenheden, Boolean wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties, int graad) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = akkoordMetHuishoudelijkRegelement;
            ToestemmingAudioVisueelMateriaal = toestemmingAudioVisueelMateriaal;
            WenstInfoTeKrijgenOverClubAangelegenheden = wenstInfoTeKrijgenOverClubAangelegenheden;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;
            InschrijvingsDatum = inschrijvingsDatum;
            Graad = graad;
        }

        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht) : base(voornaam, naam, straatnaam, huisnummer, busnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
        }
        public Lid()
        {
        }

        #endregion Constructors
    }
}