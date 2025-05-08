using System;
using System.Collections.Generic;
using System.Web.UI;
using web_controls;
using web_model;

namespace web_portal.vi
{
    public partial class intro : Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            IntroController newsController = new IntroController();
            List<IntroInfo> vList = newsController.GetAllSearch(" WHERE IntroStatusId >0 Order by Indexs ASC");
            plistintro.DataSource = vList;
            plistintro.DataBind();
            //set SEO
            if (vList.Count > 0)
            {
                IntroInfo info = vList[0];
                WebsiteDetailInfo websiteInfoDetail = new WebsiteDetailInfo();
                WebsiteInfo websiteInfo = GetwWebsiteInfo();
                if (Language.Equals("vi"))
                {
                    LiteralControl literalControl = new LiteralControl();
                    string pathpicture = WebSite + "/resources/products/" + info.Picture;
                    string logo = WebSite + "/styles/images/logo.png";
                    Title = info.TitleVi;
                   
                }
            }

        }
    }
}