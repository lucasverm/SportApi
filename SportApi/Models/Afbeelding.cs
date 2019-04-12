namespace ProjectG05.Models.Domain
{
    public class Afbeelding
    {
        public int Id { get; set; }
        public int LesmateriaalId { get; set; }
        public string Adres { get; set; }

        #region Constructors

        public Afbeelding()
        {
        }

        public Afbeelding(int lesmateriaalId, string adres)
        {
            LesmateriaalId = lesmateriaalId;
            Adres = adres;
        }

        #endregion Constructors
    }
}