using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;

namespace web_portal.webadmin
{
    public partial class productgroup : abcform
    {
       
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                if (UsersInfo != null)
                {
                    string act = Request ["act"];
                    if (string.IsNullOrEmpty(act))
                    {
                        ProductGroupController cs = new ProductGroupController();
                        IList<ProductGroupInfo> ilist = cs.GetAll();
                        if (ilist == null || ilist.Count == 0)
                        {
                            PANNELCREATE.Visible = true;
                            btnDelete.Visible = false;
                            load_User(UsersInfo.CompanyId, plistuser);
                        }
                        else
                        {
                            PANNELLIST.Visible = true;
                            btnAddList.Visible = true;
                            PANNELCREATE.Visible = false;
                            btnDelete.Visible = true;
                            p_list.DataSource = ilist;
                            p_list.DataBind ();
                        }
                    }
                    else
                    {
                        btnAdd.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        PANNELLIST.Visible = false;
                        string sid = Request ["pid"];
                        if (string.IsNullOrEmpty(sid))
                        {
                            labelhiden.Text = "";
                        }
                        else
                        {
                            ProductGroupInfo info = getByID (Util.convertToInt(sid,-1));
                            if (info == null)
                            {
                                Session.Remove("ProductGroupInfo");
                            }
                            else
                            {
                                p_name.Text = info.NameVi;
                                p_nameen.Text = info.NameEn;
                                p_index.Text = info.Indexs + "";
                                labelhiden.Text = info.ProductGroupId + "";
                                load_User(info.CompanyId, plistuser);
                                StringApp.setSelectDropdown(plistuser, info.UserId);
                                Session["ProductGroupInfo"] = info;
                            }
                        }
                    }
                }
            }
        }
        private void load_User(int companyid, DropDownList dropdownlist)
        {
            UserController userController =new UserController();
            IList<UsersInfo> list = userController.GetLiveContact();
            if (list == null || list.Count == 0)
            {
                IList<UsersInfo> ilistnect = new List<UsersInfo>();
                UsersInfo item = new UsersInfo();
                item.UserId = -1;
                item.Name = "Select user";
                ilistnect.Add(item);
                dropdownlist.DataSource = ilistnect;
                dropdownlist.DataTextField = "Name";
                dropdownlist.DataValueField = "UserId";
                dropdownlist.DataBind();
            }
            else
            {
               
               
                dropdownlist.DataSource = list;
                dropdownlist.DataTextField = "Name";
                dropdownlist.DataValueField = "UserId";
                dropdownlist.DataBind();
            }
        }
        private static ProductGroupInfo getByID(int productgroupid)
        {
            ProductGroupController cs = new ProductGroupController();
            ProductGroupInfo ilist = cs.GetById(productgroupid);
            if(ilist==null)
            {
                return null;
            }
            else return ilist;
        }

        protected void btnAdd_ckick(object sender, EventArgs e)
        {
            
            if (IsValid)
            {
                
                if (UsersInfo != null)
                {
                    PANNELLIST.Visible = false;
                    ProductGroupController productGroupController = new ProductGroupController();
                    long ilong;
                    if (labelhiden == null || labelhiden.Text.Length == 0)
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        ProductGroupInfo productGroupInfo = getParam(UsersInfo.CompanyId,
                                                                     Util.convertToInt(plistuser.SelectedValue, -1));
                        productGroupController.Insert(ref productGroupInfo);

                        StringApp.setCssclass(productGroupInfo.ProductGroupId, 0, p_label);
                    }
                    else
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        ProductGroupInfo productGroupInfo;
                        Object obj = Session["ProductGroupInfo"];
                        if (obj == null)
                        {

                        }
                        else
                        {
                        
                          productGroupInfo =getParamUpdate( (ProductGroupInfo)obj);
                          productGroupController.Update(productGroupInfo);
                           StringApp.setCssclass(productGroupInfo.ProductGroupId, 1, p_label);
                        }
                   }
                }
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UsersInfo UserInfo = getSession();
            if (IsValid)
            {
                if(UserInfo!=null)
                {
                    string[] vparam = Request.Params.GetValues ("checkbtn");
                    if (vparam == null)
                    {
                    }
                    else
                    {
                        string result = "(";
                        for (int i = 0; i < vparam.Length; i++)
                        {
                            result += "" + vparam [i].Trim () + ",";
                        }
                        result = result.Substring (0, result.Length - 1);
                        result += ")";
                        ProductGroupController groupController = new ProductGroupController();
                        try
                        {
                            groupController.Delete(result);
                        }
                        catch (Exception ex)
                        {
                        }
                        sendDirect("productgroup.aspx?pindex=1&n="+DateTime.Now.Ticks);
                    }
               }
            }
        }
        private ProductGroupInfo getParam(int companyid,int userid)
        {
            ProductGroupInfo vparam = new ProductGroupInfo();
            vparam.NameVi = p_name.Text;
            vparam.NameEn = p_nameen.Text;
            vparam.CompanyId = companyid;
            vparam.UserId = userid;
            vparam.Indexs = Util.convertToInt(p_index.Text, -1);
            return vparam;


        }
        private ProductGroupInfo getParamUpdate(ProductGroupInfo productGroupInfo)
        {
            productGroupInfo.NameVi =p_name.Text;
            productGroupInfo.NameEn = p_nameen.Text;
            productGroupInfo.Indexs= Util.convertToInt(p_index.Text,-1);
            return productGroupInfo;

        }
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
                PANNELLIST.Visible = false;
                PANNELCREATE.Visible = true;
                btnDelete.Visible = true;
                btnAddList.Visible = true;
                load_User(UsersInfo.CompanyId, plistuser);  
            }
        }
        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductGroupInfo dataItem = (ProductGroupInfo)e.Item.DataItem;
                if (dataItem == null)
                {
                }
                else
                {
                    Label labeluser = (Label)e.Item.FindControl("labeluser");
                    if (labeluser == null)
                     {

                     }
                     else
                     {
                         labeluser.Text = StringApp.GetUserName(dataItem.UserId);
                     }
                }
            }
        }
    }
}




