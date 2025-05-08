using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using web_controls;
using web_portal.App_Data;
using web_model;
using web_util;


namespace web_portal.vi
{
    public partial class Webabc : System.Web.UI.Page
    {
        private string sFormat;
        public string SFormat
        {
            get { return sFormat; }
            set { sFormat = value; }
        }
        private CompanyInfo companyInfo;

        public CompanyInfo CompanyInfo
        {
            get { return companyInfo; }
            set { companyInfo = value; }
        }
        //private string connectionstring = StringApp.DATABASELOCAL;
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        private string langcultureInfo = Util.getCultureInfo();
        public string WebSite = "http://localhost/webcafe";
        private string language;
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
        public string LangcultureInfo
        {
            get { return langcultureInfo; }
            set { langcultureInfo = value; }
        }
     
        public int _companyId;

        public int CompanyId
        {
            get { return Convert.ToInt32(StringApp.getCompannyID()); }
            set { _companyId = value; }
        }
        public void sendDirect(string url)
        {
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url);
        }
        private string connectionstring = StringApp.DATABASELOCAL;

        public string Connectionstring
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public void ShowProductCondition(Repeater repeater)
        {
            ProductController productController = new ProductController();
            List<ProductInfo> pList = productController.GetBySearch(" WHERE StatusId not like '0'");
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            language = getLang(Request.Url.PathAndQuery.ToString());
           
            sFormat = Util.getCultureInfoLang(language);
            companyInfo = GetCompanyInfo();
        }
       
        public string getLang(string surl)
        {
            //_logger.Info(surl);
            string lang = "vi";

            if (string.IsNullOrEmpty(surl))
            {
                return "vi";
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
        public void ShowGetCategoryRoot(Repeater repeater)
        {
            CategoryController productController = new CategoryController();
            List<CategoryInfo> pList = productController.GetAllRoot();
            repeater.DataSource = pList;
            repeater.DataBind();
        }
        /* GET ALL PRODUCT */
        public List<ProductInfo> GetAllProduct(out int sizes)
        {
            List<ProductInfo> vList = new List<ProductInfo>();
            Object obj = Session["WEBALLPRODUCT"];
            if (obj == null)
            {
                ProductController controller = new ProductController();
                vList = controller.GetBySearch(" Where StatusId not like '%0%' Order By Indexs ASC");
                if (vList == null || vList.Count == 0)
                {
                    sizes = 0;
                }
                else
                {


                    Session["WEBALLPRODUCT"] = vList;
                    Session.Timeout = 120;
                    sizes = vList.Count;
                }
            }
            else
            {
                vList = (List<ProductInfo>)obj;
                sizes = vList.Count;
            }
            return vList;
        }
        public List<ProductInfo> GetAllProvider(int spid,out int  sizes)
        {
            List<ProductInfo> vList = new List<ProductInfo>();
            Object obj = Session["WEBALLPRODUCT"];
            if (obj == null)
            {
                ProductController controller = new ProductController();
                vList = controller.GetBySearch(" Where StatusId not like '%0%' Order By Indexs ASC");
                if (vList == null || vList.Count == 0)
                {
                    sizes = 0;
                }
                else
                {


                    Session["WEBALLPRODUCT"] = vList;
                    Session.Timeout = 120;
                    sizes = vList.Count;
                }
            }
            else
            {
                vList = (List<ProductInfo>)obj;
                sizes = vList.Count;
            }
            return vList;
        }

      
        
        public CompanyInfo GetCompanyInfo()
        {
            Object obj = Session["COMPANYINFO"];
            if(obj==null)
            {
                CompanyController controller = new CompanyController();
                CompanyInfo companyInfo = controller.GetById(CompanyId);
                if (companyInfo == null)
                {
                    return null;
                }
                else
                {
                    Session["COMPANYINFO"] = companyInfo;
                    return companyInfo;
                }
            }
            else
            {
                return (CompanyInfo)obj;
            }
            
        }
        
        public List<CategoryInfo> GetAllCategory()
        {
            _logger.Info("GetAllCategory");
            List<CategoryInfo> vList = new List<CategoryInfo>();
            Object obj = Session["WEBALLCATEGORY"];
            if (obj == null)
            {
                CategoryController controller = new CategoryController();
                vList = controller.GetAllSearch(" Order by Indexs ASC");
                Session["WEBALLCATEGORY"] = vList;
                _logger.Info("GetAllCategory luu session WEBALLCATEGORY");
            }
            else
            {
                vList = (List<CategoryInfo>)obj;
                _logger.Info("GetAllCategory lay tu  session WEBALLCATEGORY");
            }
            return vList;
        }
        public List<IntroInfo> getAllIntro()
        {
            List<IntroInfo> vList = new List<IntroInfo>();
            Object obj = Session["ALLINTRO"];
            if (obj == null)
            {
                IntroController controller = new IntroController();
                vList = controller.GetAll();
                Session["ALLINTRO"] = vList;
            }
            else
            {
                vList = (List<IntroInfo>)obj;
            }
            return vList;
        }
        public CompanyInfo GetCompannyInfo()
        {
            Object obj = Session["COMPANYINFO"];
            if (obj == null)
            {
                CompanyController companyController = new CompanyController();
                CompanyInfo companyInfo = companyController.GetById(CompanyId);
                if (companyInfo == null)
                {
                    return null;
                }
                else
                {
                    Session["COMPANYINFO"] = companyInfo;
                    return companyInfo;
                }
            }
            else
            {
                return (CompanyInfo) obj;
            }

        }
        public string GetCategoryname(string lang, int categoryid)
        {
            
            CategoryController cs = new CategoryController();
            CategoryInfo ilist = cs.GetById(categoryid);
            if (ilist == null)
            {
                return "";
            }
            else
            {
                if (lang.Equals("vi"))
                    return ilist.NameVi;
                else
                    return ilist.NameEn;
            }

        }
        public ServiceProviderInfo GetSpInfo(int _serviceid)
        {

            ServiceProviderController cs = new ServiceProviderController();
            ServiceProviderInfo info = cs.GetById(_serviceid);
            return info;

        }
        public WebsiteInfo GetwWebsiteInfo()
        {
          
                WebsiteController controller = new WebsiteController();
                WebsiteInfo websiteInfo = controller.GetById(1);
                if (websiteInfo == null)
                {
                  
                    WebsiteInfo siteInfo = new WebsiteInfo();
                    siteInfo.TitleVi = StringApp.TITLEHOME;
                    siteInfo.DesKeyWordVi = "";
                    siteInfo.DesVi = "";
                    return siteInfo;
                }
                else
                {
               
                    return websiteInfo;
                }

           

        }

      
        public string DescriptionReplace(string s, int maxlen)
        {
            if (string.IsNullOrEmpty(s))
            {
                return "";
            }
            else
            {
                string str = s.Replace("<div>", "");
                str = str.Replace("</div>", "");
                str = str.Replace("<font>", "");
                str = str.Replace("</font>", "");
                str = str.Replace("<br/>", "");
                str = str.Replace("<br>", "");
                str = str.Replace("<span style=\"white-space: pre-wrap;\">", "");
                str = str.Replace("<span>", "");
                str = str.Replace("</span>", "");
                str = str.Replace("\"", "");
                int len = str.Length;
                if (maxlen < len)
                {

                    str = str.Substring(0, maxlen);
                }
                return str;
            }
        }
       
     
       
      
        public class MessageBox
        {
            public static void Show(Page Page, String Message)
            {
                Page.ClientScript.RegisterStartupScript(
                   Page.GetType(),
                   "MessageBox",
                   "<script language='javascript'>alert('" + Message + "');</script>"
                );
            }
        }
      
    }
}