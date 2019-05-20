using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProjectG05.Models.Domain
{
    public class Gebruiker
    {
        #region Fields

        private string _name;
        private DateTime _geboorteDatum;
        private string _voornaam;
        private string _telefoonnummer;
        private string _straatnaam;
        private string _huisnummer;
        private string _postcode;
        private string _stad;
        private string _email;
        private string _geslacht;

        #endregion Fields

        #region Properties

        public int Graad { get; set; }

        public String Email { get; set; }

        public string Geslacht { get; set; }

        public int Id { get; set; }

        public String Naam { get; set; }

        public String Telefoonnummer { get; set; }

        public List<Sessie> Sessies { get; set; }

        public String Voornaam { get; set; }

        public DateTime GeboorteDatum { get; set; }

        public string Straatnaam { get; set; }

        public string Huisnummer { get; set; }

        public String Busnummer { get; set; }

        public string Postcode { get; set; }

        public String Type { get; set; }

        public string Stad { get; set; }

        public int IdApi { get; set; }

        #endregion Properties

        #region Constructors

        public Gebruiker()
        {
        }

        public Gebruiker(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht, string type, int graad=1)
        {
            Voornaam = voornaam;
            Naam = naam;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Stad = stad;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Sessies = new List<Sessie>();
            GeboorteDatum = geboortedatum;
            Geslacht = geslacht;
            Type = type;
            Busnummer = busnummer;

            Graad = graad;
        }

        public Gebruiker(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht, string type, int graad = 1)
        {
            Voornaam = voornaam;
            Naam = naam;
            Straatnaam = straatnaam;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Stad = stad;
            Telefoonnummer = telefoonnummer;
            Email = email;
            Sessies = new List<Sessie>();
            GeboorteDatum = geboortedatum;
            Geslacht = geslacht;
            Type = type;
            Graad = graad;
        }

        public override string ToString()
        {
            return this.Email;
        }

        #endregion Constructors

        private DateTime stringToDateTimeConverter(string value)
        {
            string[] date = value.Split("-");
            return new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2]));
        }
    }
}