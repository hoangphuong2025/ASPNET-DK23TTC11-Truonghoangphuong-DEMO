using web_model.Base;

namespace web_model
{
    public class UserStatusInfo
    {
        #region Constructors
        public UserStatusInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string NameVi { get; set; }
        public string NameEn { get; set; }
        #endregion
    }
}

