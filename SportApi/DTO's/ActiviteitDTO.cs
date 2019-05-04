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

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public DayOfWeek Weekdag { get; set; }

        [Required]
        public List<int> GebruikerIds { get; set; }
    }

   
}