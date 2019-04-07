namespace ProjectG05.Models.Domain
{
    public class Video
    {
        public string Adres { get; set; }
        public int LesmateriaalId { get; set; }
        public int Id { get; set; }

        #region Constructors

        public Video()
        {

        }
        public Video(int lesmateriaalId, string adres)
        {
            LesmateriaalId = lesmateriaalId;
            Adres = adres;
        }

        #endregion Constructors

    }
}