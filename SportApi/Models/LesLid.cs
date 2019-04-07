namespace ProjectG05.Models.Domain
{
    public class LesLid
    {
        #region Properties

        public int Id { get; set; }

        public Les Les { get; set; }

        public Lid Lid { get; set; }

        #endregion Properties

        #region Constructors

        public LesLid()
        {
        }

        public LesLid(Les les, Lid lid)
        {
            Les = les;
            Lid = lid;
        }

        #endregion Constructors
    }
}