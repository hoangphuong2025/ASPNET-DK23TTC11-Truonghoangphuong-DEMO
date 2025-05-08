using System;
using web_model;
using web_util;

namespace web_portal.vi
{
    public partial class _default : Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
              
                WebsiteInfo websiteInfo = GetwWebsiteInfo();
                string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
                if (websiteInfo != null)
                {
                    WebsiteDetailInfo websiteInfoDetail = new WebsiteDetailInfo();
                    string pathpicture = websiteInfo.WebSiteName + "/styles/images/logo.png";
                    string postcode = websiteInfo.PostCode;
                    string postcodename = websiteInfo.PostCodeName;
                    string addressLocality = websiteInfo.AddressLocality;
                    string addressCountry = websiteInfo.AddressCountry;
                    string contryname = websiteInfo.CountryName;
                    string tel = websiteInfo.Tel;
                    string stitle = string.Empty;
                    if (lang.Equals("vi"))
                        stitle = websiteInfo.TitleVi;
                    else if (lang.Equals("en"))
                        stitle = websiteInfo.TitleEn;
                   
                  
            }
        }
    }
}
