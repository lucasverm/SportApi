using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DTO_s
{
    public class ActiviteitDTO
    {
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int MaxAantalGebruikers { get; set; }
        public string StartDatum { get; set; }
        public string EindDatum { get; set; }

        public string Start { get; set; }
        public string Eind { get; set; }

        [Required]
        public DayOfWeek Weekdag { get; set; }

        public List<int> GebruikersVoorActiviteit { get; set; }

        public String Straat { get; set; }

        public String Huisnr { get; set; }
        public String Postcode { get; set; }
        public String Stad { get; set; }
        public String Startuur { get; set; }

        public String Email { get; set; }

        public String Telefoonnummer { get; set; }
    }

   
}