using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectG05.Models.Domain
{
    public class Lesmateriaal
    {
        #region Properties

        public int Id { get; set; }

        public int Graad { get; set; }

        public string Naam { get; set; }
        public string Categorie { get; set; }

        public string OefeningUitlegTekst { get; set; }

        public List<Afbeelding> Afbeeldingen { get; set; }

        public List<Video> Videos { get; set; }

        public List<Raadpleging> Raadplegingen { get; set; }

        public List<Commentaar> Commentaren { get; set; }

        #endregion Properties

        #region Constructors

        public Lesmateriaal()
        {
        }

        public Lesmateriaal(int graad)
        {
            Graad = graad;
        }

        public Lesmateriaal(int graad, string naam, string oefeningUitlegTekst, string categorie) : this(graad)
        {
            Naam = naam;
            OefeningUitlegTekst = oefeningUitlegTekst;
            Categorie = categorie;
        }

        public Lesmateriaal(int graad, string naam, string oefeningUitlegTekst, string categorie, List<Afbeelding> afbeeldingen, List<Video> videos) : this(graad, naam, oefeningUitlegTekst, categorie)
        {
            Afbeeldingen = afbeeldingen;
            Videos = videos;
        }

        public Lesmateriaal(int graad, string naam, string oefeningUitlegTekst, string categorie, List<Afbeelding> afbeeldingen, List<Video> videos, List<Commentaar> commentaren) : this(graad, naam, oefeningUitlegTekst, categorie, afbeeldingen, videos)
        {
            Commentaren = commentaren;
        }

        #endregion Constructors
    }
}