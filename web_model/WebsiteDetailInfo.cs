using System;
using web_model.Base;

namespace web_model
{
    
    public class WebsiteDetailInfo
    {
       #region Constructors
        public WebsiteDetailInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("Id")]
         public int Id { get; set; }
         public string TitleVi { get; set; }
         public string TitleEn { get; set; }
         public string TitleChi { get; set; }
         public string TitleRus { get; set; }
         public string DesKeyWordVi { get; set; }
         public string DesKeyWordEn { get; set; }
         public string DesKeyWordChi { get; set; }
         public string DesKeyWordRus { get; set; }
         public string DesVi { get; set; }
         public string DesEn { get; set; }
         public string DesChi { get; set; }
         public string DesRus { get; set; }
         public string WebSiteName { get; set; }
         public string Picture { get; set; }
         public string UrlString { get; set; }

        #endregion

    }
}

