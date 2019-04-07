using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public class Raadpleging
    {
        #region Properties

        public DateTime Datum { get; set; }

        public Lesmateriaal Lesmateriaal { get; set; }

        public Lid Lid { get; set; }

        public TimeSpan TijdStip { get; set; }

        #endregion Properties

        #region Constructors

        public Raadpleging()
        {
        }

        public Raadpleging(Lid lid, Lesmateriaal lm)
        {
            Lid = lid;
            Datum = DateTime.Today;
            TijdStip = DateTime.Now.TimeOfDay;
            Lesmateriaal = lm;
        }

        #endregion Constructors
    }
}