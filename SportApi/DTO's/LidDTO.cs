using ProjectG05.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace SportApi.DTO_s
{
    public class LidDTO
    {

        public string Voornaam { get; set; }

        public string Naam { get; set; }

        public string StraatNaam { get; set; }

        public string Huisnummer { get; set; }

        public string Busnummer { get; set; }

        public string Postcode { get; set; }

        public string Stad { get; set; }

        public string TelefoonNummer { get; set; }

        public string Email { get; set; }
        public String Geb { get; set; }
        public String Nationaliteit { get; set; }
        public String EmailOuders { get; set; }

        public String RijksregisterNummer { get; set; }

        public String GeborenTe { get; set; }

        public string Geslacht { get; set; }

        public string InschrijvingsDatum { get; set; }

        public int Graad { get; set; }

        public Boolean AkkoordMetHuishoudelijkRegelement { get; set; }

        public Boolean ToestemmingAudioVisueelMateriaal { get; set; }

        public Boolean WenstInfoTeKrijgenOverClubAangelegenheden { get; set; }
        public Boolean WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties { get; set; }

        public string GeboorteDatum { get; set; }

        public string Type { get; set; }
    }
}