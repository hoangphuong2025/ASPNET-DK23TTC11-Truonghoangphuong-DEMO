using System;
using web_model.Base;


namespace web_model 
{
	
	 public class FeedBackInfo
	{
        #region Constructors
         public FeedBackInfo() { }
        #endregion
        #region Public Properties
        [DBColumnNamePrimaryKey("FeedBackId")]
        public int FeedBackId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Contents { get; set; }
        public int StatusId { get; set; }
        public DateTime Edate { get; set; }
        public DateTime Mdate { get; set; }
        public int CompanyId { get; set; }
        #endregion
    }
} 