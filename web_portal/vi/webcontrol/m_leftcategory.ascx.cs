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
    public partial class m_leftcategory : WebUserControl
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            CategoryController productController = new CategoryController();
            List<CategoryInfo> pList = productController.GetAllRoot();
            plistcategory.DataSource = pList;
            plistcategory.DataBind();
            ServiceProviderController spController = new ServiceProviderController();
            List<ServiceProviderInfo> pList2 = spController.GetAll();
            plistsp.DataSource = pList2;
            plistsp.DataBind();
        }
        private List<CategoryInfo> GetCategorySub(int codeSub)
        {
            CategoryController productController = new CategoryController();
            return productController.GetAllSearch(" WHERE Code=" + codeSub +" AND CodeSub=-1 Order By Indexs ASC");
           
        }
        protected void plistcategory_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
           
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                CategoryInfo dataItem = (CategoryInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Repeater repeater = (Repeater) e.Item.FindControl("plistsub");
                    if (repeater != null)
                    {
                        List<CategoryInfo> vMore = GetCategorySub(dataItem.CategoryId);
                        repeater.DataSource = vMore;
                        repeater.DataBind();

                    }
                }
            }
        }
    }
}