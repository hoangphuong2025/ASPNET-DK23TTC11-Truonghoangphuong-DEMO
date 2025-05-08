using System;
using web_model.Base;

namespace web_model
{
    [Serializable]
    public class UnitsInfo
    {
        #region Constructors
        public UnitsInfo() { }
        #endregion
        #region Public Properties
         [DBColumnNamePrimaryKey("Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int CompanyId { get; set; }
       
        #endregion
    }
}
