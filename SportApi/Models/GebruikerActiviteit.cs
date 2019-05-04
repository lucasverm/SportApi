namespace ProjectG05.Models.Domain
{
    public class GebruikerActiviteit
    {
        #region Properties

        public int Id { get; set; }

        public Activiteit Activiteit { get; set; }

        public Gebruiker Gebruiker { get; set; }

        #endregion Properties

        #region Constructors

        public GebruikerActiviteit()
        {
        }

        public GebruikerActiviteit(Activiteit activiteit, Gebruiker gebruiker)
        {
            this.Activiteit = activiteit;
            this.Gebruiker = gebruiker;
        }



        #endregion Constructors
    }
}