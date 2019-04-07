namespace ProjectG05.Models.Domain
{
    public class Afbeelding
    {
        public string Adres { get; set; }
        public int LesmateriaalId { get; set; }
        public int Id { get; set; }

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