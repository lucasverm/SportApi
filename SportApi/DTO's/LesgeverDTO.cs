using System;
using System.ComponentModel.DataAnnotations;

namespace SportApi.DTO_s
{
    public class LesgeverDTO
    {
        [Required]
        public string Voornaam { get; set; }

        [Required]
        public string Naam { get; set; }

        [Required]
        public string StraatNaam { get; set; }

        [Required]
        public string Huisnummer { get; set; }

        [Required]
        public string Busnummer { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Stad { get; set; }

        [Required]
        public string TelefoonNummer { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime GeboorteDatum { get; set; }

        [Required]
        public string Geslacht { get; set; }
    }
}