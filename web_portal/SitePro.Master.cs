using System;
using System.Collections.Generic;
using web_model;
using web_portal.vi;

namespace web_portal
{
    public partial class SitePro : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Webabc webabc = new Webabc();
            CompanyInfo companyInfo = webabc.GetCompanyInfo();
            if (companyInfo != null)
            {
                //List<CompanyInfo> vList = new List<CompanyInfo>();
                //vList.Add(companyInfo);
                //plistcall.DataSource = vList;
                //plistcall.DataBind();


            }
        }
    }
}
