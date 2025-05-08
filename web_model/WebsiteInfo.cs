using System;
using web_model.Base;

namespace web_model
{
    
    public class WebsiteInfo
    {
       #region Constructors
        public WebsiteInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("Id")]
         public int Id { get; set; }
         public string TitleVi { get; set; }
         public string TitleEn { get; set; }
         public string DesKeyWordVi { get; set; }
         public string DesKeyWordEn { get; set; }
         public string DesVi { get; set; }
         public string DesEn { get; set; }
         public string WebSiteName { get; set; }
         public string PostCode { get; set; }
         public string PostCodeName { get; set; }
         public string AddressLocality { get; set; }
         public string AddressCountry { get; set; }
         public string CountryName { get; set; }
         public string Tel { get; set; }

        #endregion

    }
}

