
using System;
using web_model.Base;

namespace web_model
{
    [Serializable]
    public class MenuRightInfo
    {
         #region Constructors
        public MenuRightInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("UserRightId")]
        public int UserRightId { get; set; }
        public int UserId { get; set; }
        public int MainId { get; set; }
        public int SubId { get; set; }
        public int Indexs { get; set; }
        public int CompanyId { get; set; }
        #endregion
     }
}
