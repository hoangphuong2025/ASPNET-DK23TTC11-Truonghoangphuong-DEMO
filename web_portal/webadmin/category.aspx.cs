using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial  class category : abcform
    {
        private string display;

        public string Display
        {
            get { return display; }
            set { display = value; }
        }
        protected void btnAdd_ckick(object sender, EventArgs e)
        {
           
            if (UsersInfo != null)
            {
                string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
                if (IsValid)
                {

                    PANNELLIST.Visible = false;
                    if (labelhiden.Text.Length == 0)
                    {
                        if (string.IsNullOrEmpty(lang) || lang.Equals("vi"))
                        {
                            lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        }
                        else
                        {
                            lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        }
                        CategoryController category = new CategoryController();
              
                        CategoryInfo categoryInfo = getCategoryInfo(UsersInfo.UserId, UsersInfo.CompanyId);
                        category.Insert(ref categoryInfo);
                        StringApp.setCssclass(lang,1,0,p_label);
                       
                        string str2 = getimg();
                        if (string.IsNullOrEmpty(str2))
                        {
                            ImgView1.Visible = false;
                            display = "none";
                            f_filename.Text = "";
                        }
                        else
                        {

                            display = "block";
                            ImgView1.ImageUrl = "./../resources/category/" + str2;
                            f_filename.Text = str2;
                        }
                        
                    }
                    else
                    {
                        Object obj = Session["CATEGORYSUBINFO"];
                        if (obj != null)
                        {
                            if (string.IsNullOrEmpty(lang) || lang.Equals("vi"))
                            {
                                lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                            }
                            else
                            {
                                lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                            }
                            CategoryController category = new CategoryController();
                            CategoryInfo categoryInfo = getCategoryInfoUpdate((CategoryInfo)obj);
                            categoryInfo.CategoryId = Util.convertToInt(labelhiden.Text, -1);
                            category.Update(categoryInfo);
                            StringApp.setCssclass(lang, 1, 1, p_label);
                            if (p_check.Checked)
                            {
                                display = "none";
                                PANNELFILE.Visible = false;
                            }
                            else
                            {
                                _logger.Info(" da vo day setup");
                                string str2 = getimg();
                                if (string.IsNullOrEmpty(str2))
                                {
                                    if (string.IsNullOrEmpty(f_filename.Text))
                                    {
                                        display = "none";
                                    }
                                    else
                                    {
                                        ImgView1.ImageUrl = "./../resources/category/" + f_filename.Text;
                                        display = "block";
                                    }
                                    //
                                }
                                else
                                {
                                    ImgView1.ImageUrl = "./../resources/category/" + str2;
                                    f_filename.Text = str2;
                                    display = "block";
                                }
                            }
                        }
                    }
                }
            }
        }
        private CategoryInfo getCategoryInfo(int userid, int companyid)
        {
            CategoryInfo info = new CategoryInfo();
            info.NameVi = p_namevi.Text;
            info.NameEn = p_nameen.Text;
            info.NameChi = "";
            info.Code =-1;
            info.Indexs = Util.convertToInt(p_index.Text, 0);
            info.ShortDesVi ="";
            info.ShortDesEn = "";
            info.ShortDesChi = "";
            info.DescriptionVi = "";
            info.DescriptionEn = "";
            info.DescriptionChi = "";
            info.UserId = userid;
            info.CompanyId = companyid;
            info.ProductGroupId =Util.convertToInt(plistgroup.SelectedValue);
            info.Edate = DateTime.Now;
            info.Mdate = DateTime.Now;
            info.CodeSub = -1;
            
            string str = StringApp.removeUnicode(File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
            if (string.IsNullOrEmpty(str))
            {
                if (string.IsNullOrEmpty(f_filename.Text))
                {
                    info.Picture = "";

                }
                else info.Picture = f_filename.Text;

            }
            else
                info.Picture = str;

            return info;
        }
        private CategoryInfo getCategoryInfoUpdate(CategoryInfo categoryInfo)
        {
            categoryInfo.NameVi = p_namevi.Text;
            categoryInfo.NameEn = p_nameen.Text;
            categoryInfo.Code = -1;
            categoryInfo.Indexs = Util.convertToInt(p_index.Text, 0);
            categoryInfo.Mdate = DateTime.Now;
            if (p_check.Checked)
            {
                categoryInfo.Picture = "";
            }
            else
            {


                string str =
                    StringApp.removeUnicode(
                        File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                if (string.IsNullOrEmpty(str))
                {
                    if (string.IsNullOrEmpty(f_filename.Text))
                    {
                        categoryInfo.Picture = "";

                    }
                    else categoryInfo.Picture = f_filename.Text;

                }
                else
                    categoryInfo.Picture = str;
            }
            categoryInfo.ProductGroupId = Util.convertToInt(plistgroup.SelectedValue); 
            return categoryInfo;
        }
      
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
              PANNELLIST.Visible = false;
            PANNELCREATE.Visible = true;
            lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
            load_ProductGroup("vi", plistgroup);
            //load_CategoryLevelRoot(lang, prootlist);

        }
        public List<ProductGroupInfo> load_ProductGroup(string lang, DropDownList dropDownList)
        {

            ProductGroupController sGroup = new ProductGroupController();
            List<ProductGroupInfo> list = sGroup.GetAll();
            if (lang.Equals("vi"))
            {

               
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "ProductGroupId";
            }
            else
            {
                
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "ProductGroupId";
            }
            if (list == null || list.Count == 0)
            {
                ProductGroupInfo info = new ProductGroupInfo();
                info.ProductGroupId = -1;
                info.NameVi = "Chọn Nhóm sản phẩm";
                list.Add(info);

            }
            else
            {

            }
            dropDownList.DataBind();
            return list;
        }
    
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UsersInfo info = getSession();
            if (info != null)
            {
                string[] values = Request.Params.GetValues("checkbtn");
                if ((values != null) && (values.Length != 0))
                {
                    string scondition = "(";
                    for (int i = 0; i < values.Length; i++)
                    {
                        scondition = scondition + values[i].Trim() + ",";
                    }
                    scondition = scondition.Substring(0, scondition.Length - 1) + ")";
                    CategoryController category = new CategoryController();
                    try
                    {
                        category.Delete(scondition);
                    }
                    catch (Exception)
                    {
                    }
                    sendDirect("category.aspx?pindex=1&n="+DateTime.Now.Ticks.ToString());
                }
            }
        }

       
        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
             string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                CategoryInfo dataItem = (CategoryInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Label labelrootnamevi = (Label)e.Item.FindControl("labelrootnamevi");
                    if (labelrootnamevi == null)
                    {
                        
                    }
                    else
                    {
                        string nameen = string.Empty;
                        labelrootnamevi.Text = GetCategoryName(lang, dataItem.Code,out nameen);
                        Label labelrootnameen = (Label)e.Item.FindControl("labelrootnameen");
                        if (labelrootnameen != null)
                        {
                            labelrootnameen.Text = nameen;
                        }
                       
                    }
                    Label labelgroupname = (Label)e.Item.FindControl("labelgroupname");
                    if (labelgroupname == null)
                    {
                        
                    }
                    else
                    {
                        labelgroupname.Text =StringApp.GetProductGroupName(dataItem.ProductGroupId);
                    }
                }
            }
        }
   
        private string GetCategoryName(string lang,int categoryid,out string nameen)
        {
            CategoryController controller = new CategoryController();
            CategoryInfo categoryInfo = controller.GetById(categoryid);
            if (categoryInfo == null)
            {
                nameen = "";
                return "";
            }
            else
            {
                if (lang.Equals("vi"))
                {
                    nameen = categoryInfo.NameEn;
                    return categoryInfo.NameVi;
                }
                else
                {
                    nameen = "";
                    return categoryInfo.NameEn;
                }
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
                if (UsersInfo != null)
                {
                    string str2 = Request["act"];
                    if (string.IsNullOrEmpty(str2))
                    {
                        labelhiden.Text = "";
                        lblTitle.Text = string.Empty;
                        if (lang.Equals("vi"))
                        {
                            lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
                        }
                        else
                        {
                            lblTitle.Text = StringApp.MSGLISTDANHMUC_EN;
                        }
                        PANNELCREATE.Visible = false;
                        CategoryController categoryController = new CategoryController();
                        IList<CategoryInfo> list = categoryController.GetAllSearch(" WHERE code=-1 Order by Indexs ASC");
                        if (list != null && list.Count != 0)
                        {

                            p_list.DataSource = list;
                            p_list.DataBind();
                            
                        }
                    }
                    else
                    {
                        load_ProductGroup("vi", plistgroup);
                        //view detail
                        if (lang.Equals("vi"))
                        {
                            btnAdd.Text= lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                            
                        }
                        else
                        {
                           btnAdd.Text= lblTitle.Text = StringApp.MSGUPDATEDANHMUC_EN;
                             
                        }
                        PANNELLIST.Visible = false;
                
                        string categoryid =Util.checkRequestStringConvertToInt(Request["pid"]);
                        if (string.IsNullOrEmpty(categoryid))
                        {
                        }
                        else
                        {
                            CategoryController categoryController = new CategoryController();
                            CategoryInfo info =categoryController.GetById(Util.convertToInt(categoryid,-1));
                            if (info != null)
                            {
                                Session["CATEGORYSUBINFO"] = info;
                                labelhiden.Text = info.CategoryId + "";
                                p_namevi.Text = info.NameVi;
                                p_nameen.Text = info.NameEn;
                                p_index.Text = info.Indexs + "";

                                StringApp.setSelectDropdown(plistgroup, info.ProductGroupId);
                                if (string.IsNullOrEmpty(info.Picture))
                                {

                                    display = "none";
                                }
                                else
                                {
                                    PANNELFILE.Visible = true;
                                    ImgView1.Visible = true;
                                    ImgView1.ImageUrl = "./../resources/category/" + info.Picture;
                                    f_filename.Text = info.Picture;
                                    display = "";
                                }
                            }
                        }
                    }
                }
            }
        }
        private string getimg()
        {
            Exception exception;
           
            try
            {
                Thumbnail thumbnail = new Thumbnail();
                string str = Server.MapPath("../resources/category/");
                if (File1.PostedFile != null)
                {
                    string fileName = StringApp.removeUnicode(File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                    int contentLength = File1.PostedFile.ContentLength;
                    if ((contentLength > 0) && (contentLength <= 0x300000))
                    {
                        if (((((contentLength <= 0) || (contentLength > 0x300000)) || ((fileName.IndexOf(".exe") > 0) || (fileName.IndexOf(".EXE") > 0))) || ((fileName.IndexOf(".msi") > 0) || (fileName.IndexOf(".js") > 0))) || (fileName.IndexOf(".JS") > 0))
                        {
                            _logger.Info("FILE SIZE LON QUA :");
                            return "";
                        }
                        File1.PostedFile.SaveAs(str + @"\" + fileName);
                        thumbnail.GenerateThumbnailCategory(fileName, "~/resources/category/", "300_" + fileName, 300);
                        thumbnail.GenerateThumbnailCategory(fileName, "~/resources/category/", "500_" + fileName, 500);
                        thumbnail.GenerateThumbnailCategory(fileName, "~/resources/category/", "540_" + fileName, 540);
                        

                        return fileName;
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                _logger.Info("EditProducts.ascx.cs " + exception.Message);
              
                return "";
            }
            return "";
        }
    }
}
