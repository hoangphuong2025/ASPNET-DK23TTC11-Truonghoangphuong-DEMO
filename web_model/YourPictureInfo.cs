using web_model.Base;


namespace web_model
{

    public class YourPictureInfo
    {
       #region Constructors
        public YourPictureInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public string DescriptionVi { get; set; }
        public string DescriptionEn { get; set; }
        public string Picture { get; set; }
        public int Indexs { get; set; }
        public string UrlString { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        #endregion

    }
}

