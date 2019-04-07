using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectG05.Models.Domain
{
    public class Sessie
    {
        #region Properties

        public int Id { get; set; }

        public DateTime Datum { get; set; }

        public TimeSpan Duur { get; set; }

        public List<Lid> LedenVoorLes { get; set; }

        public Gebruiker Lesgever { get; set; }

        public TimeSpan StartUur { get; set; }

        public DayOfWeek Weekdag { get; set; }
        public List<Gebruiker> Aanwezigen { get; set; }

        public Boolean Bezig { get; set; }

        #endregion Properties

        #region Constructors

        public Sessie()
        {
        }

        public Sessie(Lesgever leraar, DateTime datum, TimeSpan duur, TimeSpan startUur, DayOfWeek weekdag, List<Lid> leden)
        {
            Lesgever = leraar;
            Datum = datum;
            StartUur = startUur;
            Weekdag = weekdag;
            LedenVoorLes = leden;
            Duur = Duur;
            Aanwezigen = new List<Gebruiker>();
            Bezig = false;
        }

        #endregion Constructors

        #region Methods

        public void StartSessieVanLes(Les les)
        {
            Aanwezigen = new List<Gebruiker>();
            LedenVoorLes = les.LedenVoorLes;
            Weekdag = les.Weekdag;
            Duur = les.Duur;
            StartUur = les.StartUur;
            Lesgever = les.Lesgever;
            Datum = DateTime.Now.AddDays(DateTime.Now.DayOfWeek - les.Weekdag);
            Bezig = true;
        }

        public override string ToString()
        {
            string aanwezigen = "";
            Aanwezigen.ForEach(t => aanwezigen += t.Naam + ",");
            string leden = "";
            LedenVoorLes.ForEach(t => leden += t.Naam + ",");
            return $"{this.Id};{this.Lesgever};{this.LedenVoorLes};{this.StartUur};{aanwezigen};";
        }

        public bool IsHelftLesVoorbij()
        {
            TimeSpan huidigUur = DateTime.Now.TimeOfDay;
            TimeSpan startUur = this.StartUur;
            if (huidigUur > startUur && huidigUur - startUur > new TimeSpan(1, 0, 0) && huidigUur - startUur < new TimeSpan(2, 0, 0))
            //ervan uitgaande dat een les 2uur duurt
            {
                return true;
            }

            return false;
        }

        #endregion Methods
    }
}