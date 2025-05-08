
using System;
using web_model.Base;

namespace web_model
{
    [Serializable]
    public class MenuMainInfo
    {
        #region Constructors
        public MenuMainInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("MainId")]
        public int MainId { get; set; }
        public int UserId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public int Indexs { get; set; }
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        #endregion
        
    }
}
