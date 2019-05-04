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

        public string Nationaliteit {
            get {
                return this._nationaliteit;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Een lid moet een nationaliteit hebben.");
                Regex regEnkelLetters = new Regex(@"\D+");
                Match match = regEnkelLetters.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven nationaliteit bevat vreemde tekens.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven nationaliteit bevat vreemde tekens.");

                this._nationaliteit = value;
            }
        }

        public string EmailOuders {
            get {
                return this._emailOuders;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    this._emailOuders = value;
                else
                {
                    Regex emailReg = new Regex(@".*@\w*.\w");
                    Match match = emailReg.Match(value);
                    if (!match.Success)
                        throw new ArgumentException("email van ouders voldoet niet aan de norm.");
                    this._emailOuders = value;
                }
            }
        }

        public string Rijksregisternummer {
            get {
                return this._rijksregisternummer;
            }
            set {
                Regex rijksregnum = new Regex(@"(\d{2}).(\d{2}).(\d{2})-(\d{3}).(\d{2})");
                Match match = rijksregnum.Match(value);
                if (!match.Success)
                    throw new ArgumentException("Het rijksregisternummer is niet volgens de norm.");
                string year = value.Substring(0, 2);
                string month = value.Substring(3, 2);
                string day = value.Substring(6, 2);
                //  if (!this.Geboortedatum.Year.ToString().EndsWith(year)|| this.Geboortedatum.Month.ToString() != month || this.Geboortedatum.Day.ToString() != day)
                //     throw new ArgumentException("Het opgegeven rijksregisternummer klopt niet volgens uw geboortedatum");

                int rijksXY = int.Parse(value.Substring(13, 2));
                int gender;
                if (this.Geslacht == "X")
                {
                    gender = 0;
                }
                else if (this.Geslacht == "Y")
                {
                    gender = 1;
                }
                else
                {
                    this._rijksregisternummer = value;
                    return;
                }
                if (rijksXY % 2 != gender)
                    throw new ArgumentException("Het opgegeven rijksregisternummer klopt niet volgens uw geslacht");

                this._rijksregisternummer = value;
            }
        }

        public string GeborenTe {
            get {
                return this._geborenTe;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Gelieve u geboorte stad in te vullen.");
                Regex regEnkelLetters = new Regex(@"\D+");
                Match match = regEnkelLetters.Match(value);
                if (!match.Success)
                    throw new ArgumentException("De opgegeven geboortestad bevat vreemde tekens.");
                Regex regVreemdeTekens = new Regex(@"\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:");
                match = regVreemdeTekens.Match(value);
                if (match.Success)
                    throw new ArgumentException("De opgegeven geboortestad bevat vreemde tekens.");
                this._geborenTe = value;
            }
        }

        public Boolean AkkoordMetHuishoudelijkRegelement {
            get {
                return this._akkoordMetHuishoudelijkRegelement;
            }
            set {
                this._akkoordMetHuishoudelijkRegelement = value;
            }
        }

        public Boolean ToestemmingAudioVisueelMateriaal {
            get {
                return this._toestemmingAudioVisueelMateriaal;
            }
            set {
                this._toestemmingAudioVisueelMateriaal = value;
            }
        }

        public Boolean WenstInfoTeKrijgenOverClubAangelegenheden {
            get {
                return this._wenstInfoTeKrijgenOverClubAangelegenheden;
            }
            set {
                this._wenstInfoTeKrijgenOverClubAangelegenheden = value;
            }
        }

        public Boolean WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties {
            get {
                return this._wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties;
            }
            set {
                this._wenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = value;
            }
        }

        public int Graad { get; set; }

        #endregion Properties

        #region Constructors

        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, int graad = 1) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = false;
            ToestemmingAudioVisueelMateriaal = false;
            WenstInfoTeKrijgenOverClubAangelegenheden = false;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = false;
            InschrijvingsDatum = new DateTime();
            Graad = graad;
        }

        public Lid(string voornaam, string naam, string straatnaam, string huisnummer, string postcode, string stad, string telefoonnummer, string email, DateTime geboortedatum, string nationaleit, string emailOuders, string rijksregisternummer, string geborenTe, string geslacht, DateTime inschrijvingsDatum, int graad) : base(voornaam, naam, straatnaam, huisnummer, postcode, stad, telefoonnummer, email, geboortedatum, geslacht, "Lid")
        {
            Nationaliteit = nationaleit;
            EmailOuders = emailOuders;
            Rijksregisternummer = rijksregisternummer;
            GeborenTe = geborenTe;
            AkkoordMetHuishoudelijkRegelement = false;
            ToestemmingAudioVisueelMateriaal = false;
            WenstInfoTeKrijgenOverClubAangelegenheden = false;
            WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = false;
            InschrijvingsDatum = inschrijvingsDatum;
            Graad = graad;

        }

        public Lid()
        {
        }

        #endregion Constructors
    }
}