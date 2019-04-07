using System;
using System.Collections.Generic;

namespace ProjectG05.Models.Domain
{
    public class Les
    {
        #region Properties

        public TimeSpan Duur { get; set; }

        public int Id { get; set; }

        public List<Lid> LedenVoorLes { get; set; }

        public Gebruiker Lesgever { get; set; }

        public TimeSpan StartUur { get; set; }

        public DayOfWeek Weekdag { get; set; }

        #endregion Properties

        #region Constructors

        public Les()
        {
        }

        public Les(Gebruiker leraar, TimeSpan startUur, TimeSpan duur, DayOfWeek weekdag, List<Lid> leden)
        {
            Lesgever = leraar;
            StartUur = startUur;
            Duur = duur;
            Weekdag = weekdag;
            LedenVoorLes = leden;
        }

        #endregion Constructors
    }
}