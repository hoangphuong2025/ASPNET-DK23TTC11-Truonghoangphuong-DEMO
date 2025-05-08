using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_util;

namespace web_portal.vi.webcontrol
{
    public partial class banner : WebUserControl
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            BannerController bannerController = new BannerController();
            List<BannerInfo> vList = bannerController.GetSearch(" WHERE Indexs>0 Order by Indexs ASC");
            if (vList == null || vList.Count == 0)
            {
            }
            else
            {
                plistslide.DataSource = vList;
                plistslide.DataBind();

            }
            
        }
        
     
      
    }
}