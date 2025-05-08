using web_model.Base;

namespace web_model
{
    public class ProductPicInfo
    {
        #region Constructors
        public ProductPicInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public string CodeColor { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public int Indexs { get; set; }
        public string Picture { get; set; }
        public string PictureColor { get; set; }
        #endregion
    }
}
