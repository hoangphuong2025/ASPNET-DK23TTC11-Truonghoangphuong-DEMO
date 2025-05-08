using System;

using web_model.Base;

namespace web_model
{
    
    public class ViewProductInfo
    {
       #region Constructors
        public ViewProductInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string NameChi { get; set; }
        public double Price { get; set; }
        public double PriceSales { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string BrunchId { get; set; }
        public int UnitId { get; set; }
        public double Weight { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductCode { get; set; }
        public string StatusId { get; set; }
        public int ServiceProviderId { get; set; }
        public string ShortDesVi { get; set; }
        public string ShortDesEn { get; set; }
        public string ShortDesChi { get; set; }
        public string DescriptionVi { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionChi { get; set; }
        public int CompanyId { get; set; }
        public int StoreId { get; set; }
        public int Indexs { get; set; }
        public string Picture { get; set; }
        public int SubCategorySubId { get; set; }
        public int StyleId { get; set; }
        public int TypeId { get; set; }
        public int CollectionId { get; set; }
        public string ColorId { get; set; }
        public string DescriptionGuide { get; set; }
        public string DescriptionVideo { get; set; }
       
    




        #endregion

    }
}

