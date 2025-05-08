using web_model.Base;

namespace web_model
{
    using System;

    [Serializable]
    public class UsersInfo
    {
           #region Constructors
        public UsersInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("UserId")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserLogin { get; set; }
        public string UserPass { get; set; }
        public int UserKindOfId { get; set; }
        public int UserStatusId { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public string NickChat { get; set; }
        public string Tel { get; set; }
        public string Address { get; set; }
        public int KindofBusinessId { get; set; }
        public string Confirms { get; set; }
        public int CodeUserId { get; set; }
        public int CompanyId { get; set; }
        public string Picture { get; set; }
        public string NickSkyper { get; set; }
        
        //not in table

       
       
        #endregion
     
    }
}

