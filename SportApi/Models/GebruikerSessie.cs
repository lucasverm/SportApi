namespace ProjectG05.Models.Domain
{
    public class GebruikerSessie
    {
        public int Id { get; set; }
        public Sessie Sessie { get; set; }
        public Gebruiker Gebruiker { get; set; }

        public GebruikerSessie(Sessie sessie, Gebruiker gebruiker)
        {
            Sessie = sessie;
            Gebruiker = gebruiker;
        }

        public GebruikerSessie()
        {
        }
    }
}