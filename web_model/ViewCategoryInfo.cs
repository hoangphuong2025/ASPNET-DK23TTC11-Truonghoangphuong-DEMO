using System;
using web_model.Base;

namespace web_model
{
    
    public class ViewCategoryInfo
    {
        #region Constructors
        public ViewCategoryInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("CategoryId")]
        public int CategoryId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string NameChi { get; set; }
        public int Code { get; set; }
        public int Indexs { get; set; }
        public string ShortDesVi { get; set; }
        public string ShortDesEn { get; set; }
        public string ShortDesChi { get; set; }
        public string DescriptionVi { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionChi { get; set; }
        public int UserId { get; set; }
        public int ProductGroupId { get; set; }
        public int CompanyId { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int CodeSub { get; set; }
        public string Picture { get; set; }
        public string RootVi { get; set; }
        public string RootEn { get; set; }
        //not in table

       
       
        #endregion
    
        
    }
}

