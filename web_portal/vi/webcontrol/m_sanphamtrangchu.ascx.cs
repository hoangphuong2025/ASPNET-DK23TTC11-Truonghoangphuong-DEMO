using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_controls;
using web_model;

namespace web_portal.vi.webcontrol
{
    public partial class m_sanphamtrangchu : WebUserControl
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ProductController productController = new ProductController();
            List<ProductInfo> pList= productController.GetAllSearchTop("TOP 8"," WHERE StatusId not like '0'");
            plistpro.DataSource = pList;
            plistpro.DataBind();
        }
    }
}