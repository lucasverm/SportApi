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

        public String Email {
            get {
                return this._email;
            }
            set {
                Regex emailReg = new Regex(@".+@\w+.\w+");
                Match match = emailReg.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Het gegeven e-mailadres voldoet niet aan de norm.");
                this._email = value;
            }
        }

        public string Geslacht {
            get {
                return this._geslacht;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw geslacht in.");
                this._geslacht = value;
            }
        }

        public int Id { get; set; }

        public String Naam {
            get { return this._name; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw familienaam in.");
                Regex regEnkelLetters = new Regex(@"\D+");
                Match match = regEnkelLetters.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven familienaam bevat vreemde tekens.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven familienaam bevat vreemde tekens.");
                this._name = value;
            }
        }

        public String Telefoonnummer {
            get { return this._telefoonnummer; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw telefoon/gsmnummer in.");
                if (value.Length < 10)
                    throw new ArgumentException("Het opgegeven telefoon/gsmnummer is te kort.");
                Regex regNummersEnPlusLandCode = new Regex(@"\+?\d+");
                Match match = regNummersEnPlusLandCode.Match(value);
                if (!match.Success)
                    throw new ArgumentException("het opgegeven telefoon/gsmnummer voldoet niet aan de normen");

                this._telefoonnummer = value;
            }
        }

        public List<Sessie> Sessies { get; set; }

        public String Voornaam {
            get { return this._voornaam; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw voornaam in.");
                Regex regEnkelLetters = new Regex(@"\D+");
                Match match = regEnkelLetters.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven voornaam bevat vreemde tekens.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven voornaam bevat vreemde tekens.");
                this._voornaam = value;
            }
        }

        public DateTime GeboorteDatum {
            get { return this._geboorteDatum; }
            set {
                if (string.IsNullOrWhiteSpace(value.ToString()))
                    throw new ArgumentException("Vul uw geboortedatum in.");
                if (DateTime.Now < value)
                    throw new ArgumentException("Kies een mogelijke geboortedatum.");
                this._geboorteDatum = value;
            }
        }

        public string Straatnaam {
            get {
                return this._straatnaam;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw straatnaam in.");
                Regex straatReg = new Regex(@"\D+");
                Match match = straatReg.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven straat voldoet niet aan de norm.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven straat bevat vreemde tekens.");
                this._straatnaam = value;
            }
        }

        public string Huisnummer {
            get {
                return this._huisnummer;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw huisnummer in.");
                Regex huisnmrReg = new Regex(@"\d+\w?");
                Match match = huisnmrReg.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Het opgegeven huisnummer voldoet niet aan de norm.");
                this._huisnummer = value;
            }
        }

        public String Busnummer { get; set; }

        public string Postcode {
            get {
                return this._postcode;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw postcode in.");
                if (value.Length > 4)
                    throw new ArgumentException("De opgegeven postcode voldoet niet aan de norm.");
                Regex postcodeReg = new Regex(@"\d{4}");
                Match match = postcodeReg.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven postcode voldoet niet aan de norm.");
                this._postcode = value;
            }
        }

        public String Type { get; set; }

        public string Stad {
            get {
                return this._stad;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Vul uw stad in.");
                Regex stadReg = new Regex(@"\D+");
                Match match = stadReg.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven stad voldoet niet aan de norm.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven stad bevat vreemde tekens.");
                this._stad = value;
            }
        }

        #endregion Properties

        #region Constructors

        public Gebruiker()
        {
        }

        public Gebruiker(string voornaam, string naam, string straatnaam, string huisnummer, string busnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string geslacht, string type)
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