using web_model.Base;

namespace web_model
{

    public class KindOfTradeInfo
    {
        #region Constructors

        public KindOfTradeInfo()
        {
        }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public int Indexs { get; set; }
        public string ShortDesVi { get; set; }
        public string ShortDesEn { get; set; }
        public string DesVi { get; set; }
        public string DesEn { get; set; }
        public string ColorCode { get; set; }
        public string IconImg { get; set; }
        public string Picture { get; set; }
        //not in table
        #endregion


    }
}