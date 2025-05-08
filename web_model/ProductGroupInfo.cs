using web_model.Base;

namespace web_model
{
    using System;

    [Serializable]
    public class ProductGroupInfo
    {
         #region Constructors
        public ProductGroupInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("ProductGroupId")]
        public int ProductGroupId { get; set; }
        public int CompanyId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string NameChi { get; set; }
        public int Indexs { get; set; }
        public int UserId { get; set; }
        #endregion
     
      
    }
}

