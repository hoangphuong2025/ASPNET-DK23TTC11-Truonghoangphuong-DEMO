using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_util;

namespace web_portal.vi
{
    public partial class products : Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            List<ProductInfo> vList = GetByAll();
            CollectionPager1.DataSource = vList;
            CollectionPager1.BindToControl = plistproducts;
            plistproducts.DataSource = CollectionPager1.DataSourcePaged;

            WebsiteInfo websiteInfo = GetwWebsiteInfo();
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if (websiteInfo != null)
            {
               Title = websiteInfo.TitleVi;
            }

        }
        private List<ProductInfo> GetByAll()
        {
            ProductController controller = new ProductController();
            return  controller.GetBySearch(" Where StatusId not like '%0%' " +
                                           " Order By Indexs ASC");

        }


        private List<ProductInfo> GetByCategoryId(int categoryid)
        {
            int sizemax = 0;
            List<ProductInfo> vResult =new List<ProductInfo>();
            List<ProductInfo> vList = GetAllProduct(out sizemax);
            if (sizemax <= 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < sizemax; i++)
                {
                    ProductInfo productInfo = vList[i];
                    if (productInfo.CategoryId == categoryid)
                    {
                        vResult.Add(productInfo);
                    }
                }
                return vResult;
            }

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