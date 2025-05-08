using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_util;

namespace web_portal.vi.webcontrol
{
    public partial class m_header : WebUserControl
    {
        private string _stringActiveHome;
        private string _stringActivePro;
        private string _stringActiveLienHe;

        public string StringActiveHome
        {
            get { return _stringActiveHome; }
            set { _stringActiveHome = value; }
        }

        public string StringActivePro
        {
            get { return _stringActivePro; }
            set { _stringActivePro = value; }
        }

        public string StringActiveLienHe
        {
            get { return _stringActiveLienHe; }
            set { _stringActiveLienHe = value; }
        }

        public void Refresh()
        {

            Object obj = Session["YOURCART"];
            if (obj == null)
            {
                panelcount.Visible = false;
                labeldes.Text = "";
            }
            else
            {
                
            }
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
           base.Page_Load(sender,e);
           Refresh();
            string urlString = Request.Url.PathAndQuery.ToString();
            if (string.IsNullOrWhiteSpace(urlString))
            {
                    
            }
            else
            {
                if (urlString.IndexOf("contact") >= 0 || urlString.IndexOf("contact.aspx") >= 0)
                {
                    _stringActiveLienHe = "active";
                    _stringActivePro = "";
                    _stringActiveHome = "";
                }
                else if (urlString.IndexOf("product") >= 0 || urlString.IndexOf("category") >= 0)
                {
                    _stringActiveLienHe = "";
                    _stringActivePro = "active";
                    _stringActiveHome = "";
                }
                else
                {
                    _stringActiveLienHe = "";
                    _stringActivePro = "";
                    _stringActiveHome = "active";
                }
            }
            //ShowGetCategoryRoot(plistsub);
            ShowProductGroup(plistgroup);
            CompanyInfo info = ShowCompanyInfo();
            if (info != null)
            {
                labelhottel.Text = info.Description;
                labelemail.Text = info.Email;
                labeltel.Text = info.Tel;
            }
        }
        public List<CategoryInfo> ShowGetCategoryRoot(int groupid)
        {
            CategoryController productController = new CategoryController();
            return  productController.GetAllSearch(" WHERE Code=-1 AND ProductGroupId="+groupid);
            
        }
        public List<CategoryInfo> GetCategorySub(int categoryid)
        {
            CategoryController productController = new CategoryController();
            return productController.GetAllSearch(" WHERE CodeSub =-1 AND Code=" + categoryid);

        }
        protected void plistgroup_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductGroupInfo dataItem = (ProductGroupInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Repeater plistsub = (Repeater)e.Item.FindControl("plistsub");
                    if (plistsub != null)
                    {
                        List<CategoryInfo> vList= ShowGetCategoryRoot(dataItem.ProductGroupId);
                        plistsub.DataSource = vList;
                        plistsub.DataBind();
                    }
                   
                }
            }
        }

        protected void plistsub_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                CategoryInfo dataItem = (CategoryInfo)e.Item.DataItem;
                if (dataItem != null)
                {

                    DataList plistsubsub = (DataList)e.Item.FindControl("plistsubsub");
                    if (plistsubsub != null)
                    {
                        List<CategoryInfo> vList = GetCategorySub(dataItem.CategoryId);
                        plistsubsub.DataSource = vList;
                        plistsubsub.DataBind();
                    }

                }
            }
        }
    }
}