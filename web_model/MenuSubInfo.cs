
using System;
using web_model.Base;

namespace web_model
{
    [Serializable]
    public class MenuSubInfo
    {
       
        #region Constructors
        public MenuSubInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("SubId")]
        public int SubId { get; set; }
        public int MainId { get; set; }
        public int UserId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public int Indexs { get; set; }
        public string Url { get; set; }
        public int CompanyId { get; set; }
        public int StatusId { get; set; }
        public string Target { get; set; }
        public string IconString { get; set; }
        
        #endregion
    }
}
