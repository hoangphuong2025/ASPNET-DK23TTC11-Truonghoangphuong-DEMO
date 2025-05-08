using web_model.Base;

namespace web_model
{
    using System;

    [Serializable]
    public class IntroInfo
    {
        #region Constructors
        public IntroInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("IntroId")]
        public int IntroId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string TitleVi { get; set; }
        public string TitleEn { get; set; }
        public string ShortDesVi { get; set; }
        public string ShortDesEn { get; set; }
        public string DescriptionVi { get; set; }
        public string DescriptionEn { get; set; }
        public int IntroKindOfId { get; set; }
        public int IntroStatusId { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int Indexs { get; set; }
        public string Picture { get; set; }
        public string SourceText { get; set; }
        //not in table
        #endregion
        
    }
}

