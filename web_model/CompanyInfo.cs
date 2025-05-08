using System;
using web_model.Base;


namespace web_model 
{
	
	 public class CompanyInfo
	{
        #region Constructors
         public CompanyInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("CompanyId")]
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string NameChi { get; set; }
        public string Description { get; set; }
        public string AddressVi { get; set; }
        public string AddressEn { get; set; }
        public string AddressChi { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string WebSite { get; set; }
        public string Director { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int McId { get; set; }
        public string SiteMap { get; set; }
        #endregion
    }
} 