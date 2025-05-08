
using System;
using System.Collections.Specialized;
using System.Reflection;
using System.Web;
using web_model;

namespace web_portal.App_Data
{
    

    public class CSContext
    {
        private Uri _currentUri;
        private HttpContext _httpContext;
        private NameValueCollection _queryString;
        private string _rawUrl;
        private string _siteUrl;
        private string baseUrl;
        private static string language = "vi";
        private static string sRootDir = "";
        private static string ulogin = null;
        private static UsersInfo userInfo;
        private static string userOnline;
        private static string userTotalOnline;

        private CSContext(HttpContext context)
        {
            this._httpContext = null;
            this._queryString = null;
            this._siteUrl = null;
            this._httpContext = context;
            this.Initialize(new NameValueCollection(context.Request.QueryString), context.Request.Url, context.Request.RawUrl, "");
        }

        public CSContext(HttpApplication appl, string applicationName, Assembly ass)
        {
            this._httpContext = null;
            this._queryString = null;
            this._siteUrl = null;
            this.baseUrl = applicationName;
            SRootDir = HttpContext.Current.Request.PhysicalApplicationPath;
        }

        private void Initialize(NameValueCollection qs, Uri uri, string rawUrl, string siteUrl)
        {
            this._queryString = qs;
            this._siteUrl = siteUrl;
            this._currentUri = uri;
            this._rawUrl = rawUrl;
        }

        public static string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
            }
        }

        public static string SRootDir
        {
            get
            {
                return sRootDir;
            }
            set
            {
                sRootDir = value;
            }
        }

        public static string Ulogin
        {
            get
            {
                return ulogin;
            }
            set
            {
                ulogin = value;
            }
        }

        public static UsersInfo UserInfo
        {
            get
            {
                return userInfo;
            }
            set
            {
                userInfo = value;
            }
        }

        public static string UserOnline
        {
            get
            {
                return userOnline;
            }
            set
            {
                userOnline = value;
            }
        }

        public static string UserTotalOnline
        {
            get
            {
                return userTotalOnline;
            }
            set
            {
                userTotalOnline = value;
            }
        }
    }
}

