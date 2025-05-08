using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_portal.App_Data;
using web_util;

namespace web_portal.vi
{
    public partial class detail : Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            int productid =Util.convertToInt(Request["pid"],0);
            if (productid > 0)
            {

                LiteralControl literalControl = null;
                ProductController pro= new ProductController();
                ProductInfo info = pro.GetById(productid);
                if (info != null)
                {
                    Page.Title = info.NameVi;
                    
                    List<ProductInfo> vList =new List<ProductInfo>();
                    vList.Add(info);
                    plistinfo.DataSource = vList;
                    plistinfo.DataBind();
                   
                   
                }
            }
        }

    
        private List<ProductInfo> GetProductSearchTop(string top ,string condion)
        {
            ProductController productController = new ProductController();
            return productController.GetAllSearchTop(top,condion);
        }
        private List<ProductInfo> GetProductSearch(string condion)
        {
            ProductController productController = new ProductController();
            return productController.GetBySearch(condion);
        }
        private List<ProductPicInfo> GetProductPicSearch(int productid)
        {
            PictureController productController = new PictureController();
            return productController.GetAllByProductId(productid);
        }
        protected void plistinfo_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductInfo dataItem = (ProductInfo) e.Item.DataItem;
                if (dataItem != null)
                {
                    Repeater plistfocus = (Repeater)e.Item.FindControl("plistfocus");
                    if (plistfocus != null)
                    {
                        plistfocus.DataSource = GetProductSearchTop(" TOP 12 "," WHERE StatusId not like '0' ANd Id != " + dataItem.Id);
                        plistfocus.DataBind();
                    }
                    else
                    {
                        
                    }
                    Repeater repslide = (Repeater)e.Item.FindControl("plistslide");
                    if (repslide != null)
                    {
                        List<ProductPicInfo> vMore = GetProductPicSearch(dataItem.Id);
                        repslide.DataSource = vMore;
                        repslide.DataBind();
                        Repeater plistmore = (Repeater)e.Item.FindControl("plistmore");
                        if (plistmore != null)
                        {
                            plistmore.DataSource = vMore;
                            plistmore.DataBind();
                        }
                    }
                    Repeater plistsame = (Repeater)e.Item.FindControl("plistsame");
                    if (plistsame != null)
                    {
                        plistsame.DataSource = GetProductSearch(" WHERE CategoryId="+dataItem.CategoryId+" AND  StatusId not like '0' ANd Id != " + dataItem.Id);
                        plistsame.DataBind();
                    }
                    else
                    {
                        
                    }
                    /* info  */
                    Label labelcategory = (Label)e.Item.FindControl("labelcategory");
                    if (labelcategory != null)
                    {
                        labelcategory.Text = GetCategoryname("vi", dataItem.CategoryId);
                    }
                    CompanyInfo info = GetCompanyInfo();
                    Label labelhottel = (Label)e.Item.FindControl("labelhottel");
                    if (labelhottel != null)
                    {
                        
                        if (info != null)
                        {
                            labelhottel.Text = info.Description;
                        }

                    }
                    Label labelemail = (Label)e.Item.FindControl("labelemail");
                    if (labelemail != null)
                    {
                        if (info != null)
                        {
                            labelemail.Text = info.Email;
                        }

                    }

                    Repeater plistsp = (Repeater)e.Item.FindControl("plistsp");
                    if (plistsp != null)
                    {
                        ServiceProviderInfo serviceProviderInfo = GetSpInfo(dataItem.ServiceProviderId);
                        if (serviceProviderInfo != null)
                        {
                            List<ServiceProviderInfo> ilList =new List<ServiceProviderInfo>();
                            ilList.Add(serviceProviderInfo);
                            plistsp.DataSource = ilList;
                            plistsp.DataBind();
                        }
                    }
                   
                }
            }
        }
    }
}