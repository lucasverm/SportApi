using System;

namespace ProjectG05.Models.Domain
{
    public class Commentaar
    {
        #region Properties

        public int Id { get; set; }
        public string Tekst { get; set; }
        public Gebruiker Lid { get; set; }
        public DateTime Datum { get; set; }
        public TimeSpan TijdStip { get; set; }
        public Lesmateriaal Lesmateriaal { get; set; }

        #endregion Properties

        #region Constructors

        public Commentaar()
        {
        }

        public Commentaar(Gebruiker lid, Lesmateriaal lesmateriaal, string tekst = "")
        {
            Lid = lid;
            Tekst = tekst;
            Lesmateriaal = lesmateriaal;
            Datum = DateTime.Today;
            TijdStip = DateTime.Now.TimeOfDay;
        }

        #endregion Constructors
    }
}