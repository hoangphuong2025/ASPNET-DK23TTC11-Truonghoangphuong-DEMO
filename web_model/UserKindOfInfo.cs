using System;
using web_model.Base;

namespace web_model
{
    public class UserKindOfInfo
    {
        #region Constructors
        public UserKindOfInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        public int Indexs { get; set; }
        #endregion
    }
}
