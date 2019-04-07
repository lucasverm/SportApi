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

        public Lesmateriaal(int id, int graad, string naam, string oefeningUitlegTekst, string catecategorie) : this(id)
        {
            Graad = graad;
            Naam = naam;
            OefeningUitlegTekst = oefeningUitlegTekst;
            Categorie = catecategorie;
        }

        public Lesmateriaal(int id, int graad, string naam, string oefeningUitlegTekst, List<Afbeelding> afbeeldingen, List<Video> videos, string catecategorie) : this(id, graad, naam, oefeningUitlegTekst, catecategorie)
        {
            Afbeeldingen = afbeeldingen;
            Videos = videos;
        }

        public Lesmateriaal(int id, int graad, string naam, string categorie, string oefeningUitlegTekst, List<Commentaar> commentaren) : this(id, graad, naam, categorie, oefeningUitlegTekst)
        {
            Commentaren = commentaren;
        }






        #endregion Constructors


    }
}