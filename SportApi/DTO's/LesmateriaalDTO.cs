using ProjectG05.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportApi.DTO_s
{
    public class LesmateriaalDTO
    {
        [Required]
        public int Graad { get; set; }

        public string Naam { get; set; }

        public string OefeningUitlegTekst { get; set; }

        public string Categorie { get; set; }

        public List<Afbeelding> Afbeeldingen { get; set; }

        public List<Video> Videos { get; set; }

        public List<Commentaar> Commentaren { get; set; }

    }
}