using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public class Activiteit
    {
        #region Properties
        public List<int> GebruikersVoorActiviteit { get; set; }
        public List<Gebruiker> GebruikersApi { get; set; }
        public DateTime StartDatum { get; set; }

        public int Id { get; set; }
        public DateTime EindDatum { get; set; }

        public String Naam { get; set; }

        public String Type { get; set; }
        public int MaxAantalGebruikers { get; set; }
        #endregion Properties

        #region Constructors

        public Activiteit()
        {
        }

        public Activiteit(DateTime startDatum, List<Gebruiker> gebruikersApi, DateTime eindDatum, string naam, string type, int maxAantalGebruikers)
        {
            StartDatum = startDatum;
            GebruikersApi = gebruikersApi;
            EindDatum = eindDatum;
            Naam = naam;
            Type = type;
            MaxAantalGebruikers = maxAantalGebruikers;
        }

        public Activiteit(DateTime startDatum, DateTime eindDatum, string naam, string type, int maxAantalGebruikers)
        {
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Naam = naam;
            Type = type;
            MaxAantalGebruikers = maxAantalGebruikers;
        }



        #endregion Constructors
    }
}