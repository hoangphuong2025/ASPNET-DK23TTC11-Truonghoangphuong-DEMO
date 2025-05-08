
using System;
using web_model.Base;

namespace web_model
{
    [Serializable]
    public class ServiceProviderInfo
    {
        #region Constructors
        public ServiceProviderInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("ServiceProviderId")]
        public int ServiceProviderId { get; set; }
        public string CompanyNameVi { get; set; }
        public string CompanyNameEn { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string AddressVi { get; set; }
        public string AddressEn { get; set; }
        public string Tel { get; set; }
        public string Website { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string ShortDesVi { get; set; }
        public string ShortDesEn { get; set; }
        public string DescriptionVi { get; set; }
        public string DescriptionEn { get; set; }
        public string Picture { get; set; }
        public int StatusId { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int Indexs { get; set; }
        public int CompanyId { get; set; }

      #endregion
        
    }
}
