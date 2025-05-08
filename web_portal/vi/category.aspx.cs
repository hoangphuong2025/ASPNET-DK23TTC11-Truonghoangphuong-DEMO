using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_util;

namespace web_portal.vi
{
    public partial class category : Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                List<ProductInfo> vList = GetByCategoryId(Util.convertToInt(Request["pid"]));
                CollectionPager1.DataSource = vList;
                CollectionPager1.BindToControl = plistproducts;
                plistproducts.DataSource = CollectionPager1.DataSourcePaged;
            }
        }

        private List<ProductInfo> GetByCategoryId(int categoryid)
        {

            ProductController controller = new ProductController();
            return controller.GetBySearch(" Where StatusId not like '%0%' AND CategoryId=" + categoryid);
          

        }
        protected void plistpro_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductInfo dataItem = (ProductInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Panel panelprice = (Panel)e.Item.FindControl("panelprice");
                    if (panelprice == null)
                    {

                    }
                    else
                    {
                        if (dataItem.Price <= 0)
                        {
                            panelprice.Visible = false;
                            Panel panelnoprice = (Panel)e.Item.FindControl("panelnoprice");
                            if (panelnoprice != null)
                            {
                                panelnoprice.Visible = true;

                            }
                        }
                        else
                        {
                            Label labelprice = (Label)e.Item.FindControl("labelprice");
                            if (labelprice == null)
                            {

                            }
                            else
                            {
                                labelprice.Text = Util.FormatNumber(dataItem.Price, "");
                            }
                            Label labelpricesales = (Label)e.Item.FindControl("labelpricesales");
                            if (labelpricesales == null)
                            {

                            }
                            else
                            {
                                labelpricesales.Text = Util.FormatNumber(dataItem.PriceSales, "");
                            }
                            panelprice.Visible = true;
                        }

                    }
                }
            }
        }
    }
}