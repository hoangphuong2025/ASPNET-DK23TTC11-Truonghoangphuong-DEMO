using System;
using web_model;
using web_util;


namespace web_portal
{
    public partial class admin : System.Web.UI.MasterPage
    {
        private string stringUrl;
        public string StringUrl
        {
            get { return stringUrl; }
            set { stringUrl = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string s = Request.Url.PathAndQuery.ToString();
                StringUrl = s.Replace("/", "@@");
                StringUrl = StringUrl.Replace("&", "$");
                UsersInfo trunkinfo = getSession();
                if (trunkinfo != null)
                {
                    labbeluser.Text = trunkinfo.Name;
                    labeltimelogin.Text = Util.setDayLong(trunkinfo.Mdate);
                }
            }
        }
        private UsersInfo getSession()
        {
            Object obj = Session["ADMIN"];
            if (obj == null)
                return null;
            else return ((UsersInfo)obj);
        }
    }
}
