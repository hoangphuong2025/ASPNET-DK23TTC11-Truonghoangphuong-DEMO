using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using web_controls;
using web_portal.App_Data;
using web_model;
using web_util;

namespace web_portal.webadmin
{
    public partial class abcform : Page
    {
        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        public static Logger _logger = LogManager.GetCurrentClassLogger();

        private UsersInfo usersInfo;

        public UsersInfo UsersInfo
        {
            get { return usersInfo; }
            set { usersInfo = value; }
        }
        public UsersInfo getSession()
        {
            Object obj=  Session["ADMIN"];
            if (obj == null)
            {
                _logger.Info("Session is null");
                sendDirect("login.aspx?n=" + DateTime.Now.Ticks.ToString());
                return null;
            }
            else
            {
                _logger.Info("Session is ok");
                return (UsersInfo)obj;
            }
        }
        public string getLang(string surl)
        {
            string lang = "vi";

            if (string.IsNullOrEmpty(surl))
            {
                return "en";
            }
            else
                if (surl.IndexOf("/en/") >= 0)
                {
                    lang = "en";
                }
                else
                    if (surl.IndexOf("/vi/") >= 0)
                        lang = "vi";
            return lang;
        }

        public void printopen(string url)
        {
            //dung kieu moi
            StringBuilder sb = new StringBuilder();
            sb.Append("<script>");
            sb.Append("window.open('" + url + "', '', '');");
            sb.Append("</script>");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "open", sb.ToString());
        }
        public UsersInfo getSession(string name)
        {
            Object obj = Session[name];
            if (obj == null)
            {
                sendDirect("login.aspx?n=" + DateTime.Now.Ticks.ToString());
                return null;

            }
            else
            {
                return (UsersInfo)obj;
            }
        }
        private List<CategoryInfo> GetCategoryRoot(int productgroupid)
        {
            List<CategoryInfo> vReList = new List<CategoryInfo>();
            int size = 0;
            List<CategoryInfo> vList = getAllCategoryInfos(out size);
            if (vList == null || vList.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    CategoryInfo categoryInfo = vList[i];
                    if (categoryInfo.Code == -1 && categoryInfo.ProductGroupId == productgroupid)
                    {
                        vReList.Add(categoryInfo);
                    }
                }
            }
            return vReList;
        }
        private List<CategoryInfo> getAllCategoryInfos(out int totalcount)
        {
            CategoryController controller = new CategoryController();
            List<CategoryInfo> vList = controller.GetAllSearch(" Order by Indexs ASC, NameVi ASC");
            if (vList == null || vList.Count == 0)
            {
                totalcount = 0;
                return null;
            }
            else
            {
                Session["CATEGORY"] = vList;
                totalcount = vList.Count;
                return vList;
            }
        }
        private List<CategoryInfo> GetCategoryLevelSub(int productgroupid, int categoryid)
        {
            List<CategoryInfo> vReList = new List<CategoryInfo>();
            int size = 0;
            List<CategoryInfo> vList = getAllCategoryInfos(out size);
            if (vList == null || vList.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    CategoryInfo categoryInfo = vList[i];
                    if (categoryInfo.Code == categoryid && categoryInfo.ProductGroupId == productgroupid)
                    {
                        vReList.Add(categoryInfo);
                    }
                }
            }
            return vReList;
        }
        public void LoadCategoryRoot(string lang, DropDownList dropDownList, int productgroupid)
        {
            IList<CategoryInfo> list = GetCategoryRoot(productgroupid);
            if (lang.Equals("vi"))
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "CategoryId";
            }
            else
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "CategoryId";
            }
            dropDownList.DataBind();

        }
        public void LoadCategoryRootSub(string lang, DropDownList dropDownList, int productgroupid, int categoryid)
        {
            IList<CategoryInfo> list = GetCategoryLevelSub(productgroupid, categoryid);
            if (lang.Equals("vi"))
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "CategoryId";
            }
            else
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "CategoryId";
            }
            dropDownList.DataBind();

        }
        public List<StatusInfo> load_ProductStatus(string lang, DropDownList dropDownList)
        {
            List<StatusInfo> list = new List<StatusInfo>();
            StatusController sGroup = new StatusController();
            Object obj = Session["STATUS"];
            if (obj == null)
            {
                list = sGroup.GetAll();
                if (list == null || list.Count == 0)
                {

                }
                else
                {
                    Session["STATUS"] = list;
                }
            }
            else
            {
                list = (List<StatusInfo>)obj;
            }

            if (lang.Equals("vi"))
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "Id";
            }
            else
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "Id";
            }
            dropDownList.DataBind();
            return list;
        }
        public List<ServiceProviderInfo> load_ServiceProvider(string lang, DropDownList dropDownList)
        {
            ServiceProviderController sGroup = new ServiceProviderController();
            List<ServiceProviderInfo> list = new List<ServiceProviderInfo>();
            ServiceProviderInfo info;
            Object obj = Session["PROVIDER"];
            if (obj == null)
            {
                list = sGroup.GetAll();
                Session["PROVIDER"] = list;
            }
            else
            {
                list = (List<ServiceProviderInfo>)obj;
            }

            if (lang.Equals("vi"))
            {
                info = new ServiceProviderInfo();
                info.ServiceProviderId = -1;
                info.NameVi = "Chọn Nhà cung cấp";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "ServiceProviderId";
            }
            else
            {
                info = new ServiceProviderInfo();
                info.ServiceProviderId = -1;
                info.NameEn = "Select ServiceProvider";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "ServiceProviderId";
            }
            dropDownList.DataBind();
            return list;
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Title =StringApp.setTitle("vi","");
            usersInfo = getSession();
            language = Util.getLangAdmin(Request.Url.PathAndQuery.ToString());
            sFormat = Util.getCultureInfoLang(language);
        }

        public string LangcultureInfo
        {
            get { return Util.getCultureInfo(); }

        }
        private string sFormat;
        public string SFormat
        {
            get { return sFormat; }
            set { sFormat = value; }
        }
        private string connectionstring = StringApp.getConnetionString();

        public string Connectionstring
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public void sendDirect(string url)
        {
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url);
        }

        public int _companyId;

        public int CompanyId
        {
            get { return getcompanyId(); }
            set { _companyId = value; }
        }

        public int getcompanyId()
        {
            Object obj = Session["ADMIN"];
            if (obj == null)
            {
               
                return -1;
            }
            else
            {
               
                return ((UsersInfo)obj).CompanyId;
            }
        }
       
    
    }
}

