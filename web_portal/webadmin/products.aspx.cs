using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial  class products : abcform
    {
        private string display;
        ProductController productController = new ProductController();
        protected void btnAdd_ckick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (UsersInfo != null)
                {
                    string str2;
                    PANNELLIST.Visible = false;
                    
                    long ilong = 1;
                    if (string.IsNullOrEmpty(labelhiden.Text))
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        ProductInfo productInfo = getProductInfo(UsersInfo.UserId, UsersInfo.CompanyId);
                        productController.Insert(ref productInfo);
                        StringApp.setCssclass(Language,productInfo.Id, 0, p_label);
                        if (ilong > 0)
                        {
                            str2 = getimg(File1);
                            ImgView1.ImageUrl = "./../resources/products/" + str2;
                            f_filename.Text = str2;
                        }
                    }
                    else
                    {
                        ProductInfo productInfo = GetById(Util.convertToInt(labelhiden.Text));
                        if (productInfo != null)
                        {
                            productInfo = getProductInfoUpdate(productInfo);
                            if (p_check.Checked)
                            {
                                display = "none";
                                PANNELFILE.Visible = false;
                            }
                            else
                            {

                                str2 = getimg(File1);
                                if (string.IsNullOrEmpty(str2))
                                {

                                    if (string.IsNullOrEmpty(f_filename.Text))
                                    {
                                        display = "none";
                                        productInfo.Picture = "";

                                    }
                                    else
                                    {

                                        ImgView1.ImageUrl = "./../resources/products/" + f_filename.Text;
                                        display = "block";
                                        productInfo.Picture = f_filename.Text;
                                    }
                                }
                                else
                                {
                                    _logger.Info("str2 co hinh");
                                    ImgView1.ImageUrl = "./../resources/products/" + str2;
                                    f_filename.Text = str2;
                                    display = "block";
                                    productInfo.Picture = str2;
                                }
                            }
                            PANNELLIST.Visible = false;
                            PANNELFILE.Visible = true;
                            lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                            productInfo.Id = Util.convertToInt(labelhiden.Text, 0);
                            productController.Update(productInfo);
                            StringApp.setCssclass(Language,productInfo.Id, 1, p_label);
                        }
                    }
                }
            }
        }
        
  
        private ProductInfo getProductInfo(int userid, int companyid)
        {
            ProductInfo productInfo = new ProductInfo();
            productInfo.UserId = userid;
            productInfo.NameVi = p_name.Text;
            productInfo.NameEn = p_nameen.Text;
            productInfo.NameChi = "";
            productInfo.Price = Util.convertDouble(p_price.Text);
            productInfo.PriceSales = Util.convertDouble(p_pricediscount.Text); 
            productInfo.Edate = DateTime.Now;
            productInfo.Mdate = DateTime.Now;
            productInfo.CategoryId = Util.convertToInt(plistcategory.SelectedValue, -1);
            productInfo.SubCategoryId = Util.convertToInt(plistcategorysub.SelectedValue, -1); ;
            productInfo.BrunchId = "-1";
            productInfo.UnitId = -1;
            productInfo.Weight = -1;
            productInfo.ProductGroupId=-1;
            productInfo.ProductCode = p_productcode.Text;
            productInfo.StatusId = p_stattus.SelectedValue;
            productInfo.ServiceProviderId = Util.convertToInt(pservice.SelectedValue, -1);
            productInfo.ShortDesVi = TextFreecode1.TextData;
            productInfo.ShortDesEn = TextFreecode2.TextData;
            productInfo.ShortDesChi = "";
            productInfo.DescriptionVi = TextFreecode3.TextData;
            productInfo.SpecificationVi = TextFreecode4.TextData;
            productInfo.AccesoriesVi = TextFreecode5.TextData;
            productInfo.DescriptionEn = TextFreecode6.TextData;
            productInfo.SpecificationEn = TextFreecode7.TextData;
            productInfo.AccesoriesEn = TextFreecode8.TextData;

           // productInfo.DescriptionGuide = TextFreecode4.TextData;

           
            productInfo.CompanyId = companyid;
            productInfo.StoreId = -1;
            productInfo.Indexs = Util.convertToInt(p_index.Text, 100);
            productInfo.Picture = getPictureName();
            productInfo.SubCategorySubId = -1;
            productInfo.StyleId = Util.convertToInt(p_pricelist.SelectedValue,-1);//pricelist
            productInfo.TypeId = -1;
           
            productInfo.ColorId = -1;
           // productInfo.DescriptionVideo = TextFreecode6.TextData;
          
           
         
            return productInfo;
        }
        private ProductInfo getProductInfoUpdate(ProductInfo productInfo)
        {
       
            productInfo.NameVi = p_name.Text;
            productInfo.NameEn = p_nameen.Text;
            productInfo.NameChi = "";
            productInfo.Price = Util.convertDouble(p_price.Text);
            productInfo.PriceSales = Util.convertDouble(p_pricediscount.Text);
            productInfo.Mdate = DateTime.Now;
            productInfo.CategoryId = Util.convertToInt(plistcategory.SelectedValue, -1);
            productInfo.SubCategoryId = Util.convertToInt(plistcategorysub.SelectedValue, -1); ;
            productInfo.BrunchId = "-1";
            productInfo.UnitId = -1;
            productInfo.Weight = -1;
            productInfo.ProductGroupId = -1;
            productInfo.ProductCode = p_productcode.Text;
            productInfo.StatusId = p_stattus.SelectedValue;
            productInfo.ServiceProviderId = Util.convertToInt(pservice.SelectedValue, -1);
            productInfo.ShortDesVi = TextFreecode1.TextData;
            productInfo.ShortDesEn = TextFreecode2.TextData;
            productInfo.ShortDesChi = "";
            productInfo.DescriptionVi = TextFreecode3.TextData;
            productInfo.SpecificationVi = TextFreecode4.TextData;
            productInfo.AccesoriesVi = TextFreecode5.TextData;
            productInfo.DescriptionEn = TextFreecode6.TextData;
            productInfo.SpecificationEn = TextFreecode7.TextData;
            productInfo.AccesoriesEn = TextFreecode8.TextData;
            
            productInfo.StoreId = -1;
            productInfo.Indexs = Util.convertToInt(p_index.Text, 100);
            productInfo.Picture = getPictureName();
            productInfo.SubCategorySubId = -1;
            productInfo.StyleId = Util.convertToInt(p_pricelist.SelectedValue, -1);//pricelist
            productInfo.TypeId = -1;

            productInfo.ColorId = -1;
        
            return productInfo;
        }
        private string getPictureName()
        {
             try
            {
                string str = StringApp.removeUnicode(File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                if (string.IsNullOrEmpty(str))
                {
                    if (string.IsNullOrEmpty(f_filename.Text))
                    {
                        return "";

                    }
                    else return f_filename.Text;

                }
                else
                    return str;
            }
            catch (Exception)
            {
                return "";
            }
        }
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            string lang = Util.getLangAdmin(Request.Url.PathAndQuery.ToString());
            PANNELCREATE.Visible = true;
            PANNELLIST.Visible = false;
            PANELCATEGORY.Visible = false;
            lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
            display = "none";
            ImgView1.Visible = false;
            load_ProductStatus(lang, p_stattus);
            load_ServiceProvider(lang, pservice);
            LoadCategoryRoot(lang, plistcategory);
            LoadCategoryRootSub(lang, plistcategorysub, Util.convertToInt(plistcategory.SelectedValue));
            LoadCategoryRootSubSub(lang, plistcategorysub_sub, Util.convertToInt(plistcategorysub.SelectedValue));
        }
        private List<ProductStatusInfo> load_ProductStatus(string lang, DropDownList dropDownList)
        {
            List<ProductStatusInfo> list = new List<ProductStatusInfo>();
            ProductStatusController sGroup = new ProductStatusController();
            Object obj = Session["STATUS"];
            if (obj == null)
            {
                list = sGroup.GetAll();
                if (list == null || list.Count == 0)
                {
                    
                }
                else
                {
                    Session["STATUS"] = list;
                }
            }
            else
            {
                list = (List<ProductStatusInfo>)obj;
            }
            
            if (lang.Equals("vi"))
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "Id";
            }
            else
            {

                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "Id";
            }
            dropDownList.DataBind();
            return list;
        }
        private List<ServiceProviderInfo> load_ServiceProvider(string lang, DropDownList dropDownList)
        {
            ServiceProviderController sGroup = new ServiceProviderController();
            List<ServiceProviderInfo> list =new List<ServiceProviderInfo>();
            ServiceProviderInfo info;
            list = sGroup.GetAll();
            if (lang.Equals("vi"))
            {
                info = new ServiceProviderInfo();
                info.ServiceProviderId = -1;
                info.CompanyNameVi = "Chọn Nhà cung cấp";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "CompanyNameVi";
                dropDownList.DataValueField = "ServiceProviderId";
            }
            else
            {
                info = new ServiceProviderInfo();
                info.ServiceProviderId = -1;
                info.CompanyNameVi = "Select ServiceProvider";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "CompanyNameVi";
                dropDownList.DataValueField = "ServiceProviderId";
            }
            dropDownList.DataBind();
            return list;
        }
        protected void btndeteleone_ckick(object sender, EventArgs e)
        {
            string scondition = "(";
            scondition = scondition + "" + labelhiden.Text + ",";
            ProductController productController = new ProductController();
            scondition = scondition.Substring(0, scondition.Length - 1) + ")";
            try
            {
                productController.Delete(scondition);
            }
            catch (Exception)
            {

            }
           sendDirect("products.aspx?n=" + DateTime.Now.Ticks);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
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
                ProductController controller = new ProductController();
                controller.Delete(scondition);
                Session.Remove("ALLPRODUCT");
                sendDirect("products.aspx?n=" + DateTime.Now.Ticks);
            }
            
        }
       
        private string getimg(HtmlInputFile filepic)
        {
            _logger.Info("GET IMAGES");
            Exception exception;
            Thumbnail thumbnail = new Thumbnail();
            try
            {
                _logger.Info("GET IMAGES 1");
                string str = Server.MapPath("../resources/products");
                if (filepic.PostedFile != null)
                {
                    string fileName = StringApp.removeUnicode(filepic.PostedFile.FileName.Substring(filepic.PostedFile.FileName.LastIndexOf(@"\") + 1));
                    int contentLength = filepic.PostedFile.ContentLength;//10 MB
                    if ((contentLength > 0) && (contentLength <= 0x300000))
                    {
                        if (((((contentLength <= 0) || (contentLength > 0x300000)) ||
                              ((fileName.IndexOf(".exe") > 0) || (fileName.IndexOf(".EXE") > 0))) ||
                             ((fileName.IndexOf(".msi") > 0) || (fileName.IndexOf(".js") > 0))) ||
                            (fileName.IndexOf(".JS") > 0))
                        {
                            _logger.Info("FILE SIZE LON QUA :");
                            return "";
                        }
                        else
                        {

                            filepic.PostedFile.SaveAs(str + @"\" + fileName);
                            //510
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "100_" + fileName, 100);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "150_" + fileName, 150);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "300_" + fileName, 300); 
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "500_" + fileName, 500);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "600_" + fileName, 600);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "768_" + fileName, 600);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "1280_" + fileName,1280);
                        
                            return fileName;
                        }
                    }
                }
                else
                {
                    _logger.Info("GET IMAGES 1");
                    return "";
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                _logger.Info("exception3 EditProducts.ascx.cs " + exception.Message);
             
                return "";
            }
            return "";
        }

        private string getimgthem(HtmlInputFile filepic)
        {
           
            Exception exception;
            Thumbnail thumbnail = new Thumbnail();
            try
            {
              
                string str = Server.MapPath("../resources/products");
                if (filepic.PostedFile != null)
                {
                    string fileName = StringApp.removeUnicode(filepic.PostedFile.FileName.Substring(filepic.PostedFile.FileName.LastIndexOf(@"\") + 1));
                    int contentLength = filepic.PostedFile.ContentLength;
                    if ((contentLength > 0) && (contentLength <= 0x300000))
                    {
                        if (((((contentLength <= 0) || (contentLength > 0x300000)) ||
                              ((fileName.IndexOf(".exe") > 0) || (fileName.IndexOf(".EXE") > 0))) ||
                             ((fileName.IndexOf(".msi") > 0) || (fileName.IndexOf(".js") > 0))) ||
                            (fileName.IndexOf(".JS") > 0))
                        {
                            _logger.Info("FILE SIZE LON QUA :");
                            return "";
                        }
                        else
                        {
                            filepic.PostedFile.SaveAs(str + @"\" + fileName);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "100_" + fileName, 100);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "150_" + fileName, 150);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "300_" + fileName, 300);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "500_" + fileName, 500);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "600_" + fileName, 600);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "768_" + fileName, 600);
                            thumbnail.GenerateThumbnailProduct(fileName, "~/resources/products/", "1280_" + fileName, 1280);
                        
                            return fileName;
                        }
                    }
                }
                else
                {
                    _logger.Info("GET IMAGES 1");
                    return "";
                }
            }
            catch (Exception exception3)
            {
                exception = exception3;
                _logger.Info("exception3 EditProducts.ascx.cs " + exception.Message);

                return "";
            }
            return "";
        }
     

        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductInfo dataItem = (ProductInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Label pcategory = (Label)e.Item.FindControl("pcategory");

                    if (pcategory == null)
                    {
                        
                    }
                    else

                    {
                        pcategory.Text = getCategory(Language,dataItem);
                    }
                    Label labelprice = (Label)e.Item.FindControl("labelprice");
                    if (labelprice != null)
                    {
                        labelprice.Text = Util.FormatNumber(dataItem.Price);
                    }
                    else
                    {
                        
                    }
                    Label labelstatus = (Label)e.Item.FindControl("labelstatus");
                    if (labelstatus != null)
                    {
                        labelstatus.Text = GetProductStatusName(Language, Util.convertToInt(dataItem.StatusId, 0));
                    }
                    
                }
            }
        }
        public static string GetProductStatusName(string lang, int statusid)
        {
            ProductStatusController cs = new ProductStatusController();
            ProductStatusInfo vList = cs.GetById(statusid);
            if (vList == null)
            {
                return "";
            }
            else
            {
                if (lang.Equals("vi"))
                    return vList.NameVi;
                else return vList.NameEn;
            }
        }
        private string getCategory(string lang,ProductInfo info)
        {
            string strResult=string.Empty;
            if (info.CategoryId > 0)
            {
                strResult += GetCategoryName(lang, info.CategoryId);
                if (info.SubCategoryId > 0)
                {
                    strResult += " - "+GetCategoryName(lang, info.SubCategoryId);
                }
            }
            return strResult;
        }

        string GetCategoryName(string lang, int categoryid)
        {
            CategoryController controller = new CategoryController();
            CategoryInfo categoryInfo = controller.GetById(categoryid);
            if (categoryInfo == null)
            {
                return "undefined";
            }
            else
            {
                if (lang.Equals("vi"))
                    return categoryInfo.NameVi;
                else return categoryInfo.NameEn;
            }
        }
        public void load_Color(RadioButtonList radioButtonList)
        {

            
            
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                string lang = Util.getLangAdmin(Request.Url.PathAndQuery.ToString());
                if (UsersInfo != null)
                {
                    string str = Request["act"];
                    if (string.IsNullOrEmpty(str))
                    {
                        Session.Remove("ALLPRODUCT");
                        List<ProductInfo> list =new List<ProductInfo>();
                        Object obj = Session["ALLPRODUCT"];
                        if (obj == null)
                        {
                            list = productController.GetAllSearch(" Order by Indexs ASC,CategoryId ASC,NameVi ASC");
                            
                        }
                        else
                        {
                            list = (List<ProductInfo>) obj;
                        }

                        if (list == null || list.Count == 0)
                        {

                        }
                        else
                        {
                            LoadCategoryRoot(lang, plistcategorysearch);
                            PANELCATEGORY.Visible = true;
                            PANNELLIST.Visible = true;
                            PANNELCREATE.Visible = false;
                            CollectionPager1.DataSource = list;
                            CollectionPager1.BindToControl = p_list;
                            p_list.DataSource = CollectionPager1.DataSourcePaged;
                            Session["ALLPRODUCT"] = list;

                        }
                    }
                    else if (str.Equals("view"))
                    {
                 
                        lblTitle.Text = StringApp.MSGBUTTONUPDATE_VI;
                        btnAdd.Text = StringApp.MSGBUTTONUPDATE_VI;
                        PANNELLIST.Visible = false;
                        PANNELCREATE.Visible = true;
                        string id = Util.checkRequestStringConvertToInt(Request["pid"]);
                        if (string.IsNullOrEmpty(id))
                        {

                        }
                        else
                        {
                            btnmulti.Visible = true;
                            ProductInfo productInfo = GetById(Util.convertToInt(id, -1));
                            if (productInfo != null)
                            {
                                //Session["PRODUCTINFO"] = productInfo;
                                labelhiden.Text = productInfo.Id + "";
                                p_name.Text = productInfo.NameVi;
                                p_nameen.Text = productInfo.NameEn;

                                p_productcode.Text = productInfo.ProductCode;
                                TextFreecode1.TextData = productInfo.ShortDesVi;
                                TextFreecode2.TextData = productInfo.ShortDesEn;

                                TextFreecode3.TextData = productInfo.DescriptionVi;
                                TextFreecode4.TextData = productInfo.SpecificationVi;
                                TextFreecode5.TextData = productInfo.AccesoriesVi;
                                TextFreecode6.TextData = productInfo.DescriptionEn;
                                TextFreecode7.TextData = productInfo.SpecificationEn;
                                TextFreecode8.TextData = productInfo.AccesoriesEn;

                                p_index.Text = productInfo.Indexs + "";
                                p_price.Text = productInfo.Price+"";
                                p_pricediscount.Text = productInfo.PriceSales + "";
                                //load_ProductStatus(lang, p_stattus);
                                StringApp.setSelectDropdown(p_stattus, productInfo.StatusId);

                                load_ServiceProvider(lang, pservice);
                                StringApp.setSelectDropdown(pservice, productInfo.ServiceProviderId);
                                ////cap 1
                                LoadCategoryRoot(lang, plistcategory);
                                StringApp.setSelectDropdown(plistcategory, productInfo.CategoryId);
                                LoadCategoryRootSub(lang, plistcategorysub,Util.convertToInt(plistcategory.SelectedValue));
                               StringApp.setSelectDropdown(plistcategorysub, productInfo.SubCategoryId);
                             ////danh muc cap 2 Code=@code  AND Code_Sub=-1 AND Code_SubFour=-1
                                if (string.IsNullOrEmpty(productInfo.Picture))
                                {
                                    display = "none";
                                }
                                else
                                {
                                    PANNELFILE.Visible = true;
                                    ImgView1.Visible = true;
                                    ImgView1.ImageUrl = "./../resources/products/" + productInfo.Picture;
                                    f_filename.Text = productInfo.Picture;
                                    display = "";
                                }
                            }
                        }
                    }
                    else if(str.Equals("status"))
                    {
                        PANELCATEGORY.Visible = true;
                        LoadCategoryRoot(lang, plistcategorysearch);
                        string statusid = Util.checkRequestStringAdmin(Request["pid"]);
                        List<ProductInfo> vProductInfos = getSearchStatusId(statusid);
                        if (vProductInfos == null || vProductInfos.Count == 0)
                        {
                            CollectionPager1.Visible = false;
                        }
                        else
                        {
                            CollectionPager1.Visible = true;
                            CollectionPager1.DataSource = vProductInfos;
                            CollectionPager1.BindToControl = p_list;
                            p_list.DataSource = CollectionPager1.DataSourcePaged;
                        }
                    }
                    else if (str.Equals("code"))
                    {
                        PANELCATEGORY.Visible = true;
                        StringApp.load_ProductGroup(lang, plistgroupsearch);
                        LoadCategoryRoot(lang, plistcategorysearch, Util.convertToInt(plistgroupsearch.SelectedValue));
                        
                        string code = Request["code"];
                        List<ProductInfo> vProductInfos = getSearchListCode(code);
                        if (vProductInfos == null || vProductInfos.Count == 0)
                        {
                            CollectionPager1.Visible = false;
                        }
                        else
                        {
                            CollectionPager1.Visible = true;
                            CollectionPager1.DataSource = vProductInfos;
                            CollectionPager1.BindToControl = p_list;
                            p_list.DataSource = CollectionPager1.DataSourcePaged;
                        }
                    }
                }
            }
        }
        private List<CategoryInfo> getAllCategoryInfos(out int totalcount)
        {
            CategoryController controller =new CategoryController();
            List<CategoryInfo> vList = controller.GetAllSearch(" Order by Indexs ASC, NameVi ASC");
            if (vList == null || vList.Count == 0)
            {
                totalcount = 0;
                return null;
            }
            else
            {
                Session["CATEGORY"] = vList;
                totalcount = vList.Count;
                return vList;
            }
        }

        private void LoadCategoryRoot(string lang, DropDownList dropDownList)
        {
           
            IList<CategoryInfo> list = GetCategoryRoot();
            if (lang.Equals("vi"))
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "CategoryId";
            }
            else
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "CategoryId";
            }
           dropDownList.DataBind();
          
        }
        private void LoadCategoryRootSubSub(string lang, DropDownList dropDownList,int categoryid)
        {

            IList<CategoryInfo> list = GetCategoryLevelSubSub(categoryid);
            if (lang.Equals("vi"))
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "CategoryId";
            }
            else
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "CategoryId";
            }
            dropDownList.DataBind();

        }
        private void LoadCategoryRootSub(string lang, DropDownList dropDownList, int categoryid)
        {

            IList<CategoryInfo> list = GetCategoryLevelSub(categoryid);
            if (lang.Equals("vi"))
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "CategoryId";
            }
            else
            {
                if (list == null || list.Count == 0)
                {
                    list = new List<CategoryInfo>();
                    CategoryInfo categoryInfo = new CategoryInfo();
                    categoryInfo.CategoryId = -1;
                    categoryInfo.NameVi = "Select Item";
                    list.Add(categoryInfo);
                }
                else
                {

                }
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "CategoryId";
            }
            dropDownList.DataBind();

        }
        private List<CategoryInfo> GetCategoryRoot()
        {
            List<CategoryInfo> vReList =new List<CategoryInfo>();
            int size = 0;
            List<CategoryInfo> vList = getAllCategoryInfos(out size);
            if (vList == null || vList.Count == 0)
            {
                _logger.Info("khong tim thay all category");
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    CategoryInfo categoryInfo = vList[i];
                    if (categoryInfo.Code == -1)
                    {
                        vReList.Add(categoryInfo);
                    }
                }
            }
            return vReList;
        }
        private List<CategoryInfo> GetCategoryLevelSub(int categoryid)
        {
            List<CategoryInfo> vReList = new List<CategoryInfo>();
            int size = 0;
            List<CategoryInfo> vList = getAllCategoryInfos(out size);
            if (vList == null || vList.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    CategoryInfo categoryInfo = vList[i];
                    if (categoryInfo.Code == categoryid && categoryInfo.CodeSub==-1)
                    {
                        vReList.Add(categoryInfo);
                    }
                }
            }
            return vReList;
        }
        private List<CategoryInfo> GetCategoryLevelSubSub(int categoryid)
        {
            CategoryController categoryController =new CategoryController();
            return categoryController.GetAllSearch(" WHERE Code !=-1 AND CodeSub!=-1 AND CodeSub=" + categoryid);
        }
        private ProductInfo GetById(int productid)
        {
            Object obj = Session["ALLPRODUCT"];
            if (obj != null)
            {
                List<ProductInfo> vList = (List<ProductInfo>) obj;
                int size = vList.Count;
                for (int i = 0; i < size; i++)
                {
                    if (vList[i].Id == productid)
                    {
                        return vList[i];
                    }
                }
            }
            return null;
        }

        protected void plistgroupsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            LoadCategoryRoot(lang, plistcategorysearch, Util.convertToInt(plistgroupsearch.SelectedValue));
        }
      
        protected void plistprogroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImgView1.Visible = false;
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            LoadCategoryRoot(lang, plistcategory);
            LoadCategoryRootSub(lang, plistcategorysub, Util.convertToInt(plistcategory.SelectedValue));

        }

      
        protected void plistcategorysub_SelectedIndexChanged(object sender, EventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            LoadCategoryRootSubSub(lang, plistcategorysub_sub, Util.convertToInt(plistcategorysub.SelectedValue));
        }
       
        private List<ProductInfo> getSearchCategory(int categoryid)
        {
            List<ProductInfo> vreInfos = new List<ProductInfo>();
            List<ProductInfo> list =new List<ProductInfo>();
            ProductController productController = new ProductController();
            Object obj = Session["ALLPRODUCT"];
            if (obj == null)
            {
                list = productController.GetAllSearch(" Order by Indexs ASC,CategoryId ASC,NameVi ASC");
                Session["ALLPRODUCT"] = list;
            }
            else
            {
                list = (List<ProductInfo>) obj;
            }
            if (list != null && list.Count > 0)
            {
                int size = list.Count;
                for (int i = 0; i < size; i++)
                {
                    if (list[i].CategoryId == categoryid)
                    {
                        vreInfos.Add(list[i]);
                    }
                }
            }
            return vreInfos;
        }
        private List<ProductInfo> getSearchStatusId(string statusid)
        {
            List<ProductInfo> vreInfos = new List<ProductInfo>();
            List<ProductInfo> list = new List<ProductInfo>();
            ProductController productController = new ProductController();
            Object obj = Session["ALLPRODUCT"];
            if (obj == null)
            {
                list = productController.GetAllSearch(" Order by Indexs ASC,CategoryId ASC,NameVi ASC");
                Session["ALLPRODUCT"] = list;
            }
            else
            {
                list = (List<ProductInfo>)obj;
            }
            if (list != null && list.Count > 0)
            {
                int size = list.Count;
                for (int i = 0; i < size; i++)
                {
                    if (list[i].StatusId.IndexOf(statusid)>=0)
                    {
                        vreInfos.Add(list[i]);
                    }
                }
            }
            return vreInfos;
        }
        private List<ProductInfo> getSearchListCode(string code)
        {
            List<ProductInfo> vreInfos = new List<ProductInfo>();
            List<ProductInfo> list = new List<ProductInfo>();
            ProductController productController = new ProductController();
            Object obj = Session["ALLPRODUCT"];
            if (obj == null)
            {
                list = productController.GetAllSearch("  Order by Indexs ASC,CategoryId ASC,NameVi ASC");
                Session["ALLPRODUCT"] = list;
            }
            else
            {
                list = (List<ProductInfo>)obj;
            }
            if (list != null && list.Count > 0)
            {
                int size = list.Count;
                for (int i = 0; i < size; i++)
                {
                    string scode = list[i].ProductCode;
                    if (string.IsNullOrEmpty(scode))
                    {
                        
                    }
                    else
                    {
                        
                        if (string.IsNullOrEmpty(code))
                        {
                            vreInfos.Add(list[i]);
                        }
                        else
                        {
                            scode = scode.ToLower();
                            if (scode.IndexOf(code.ToLower()) >= 0)
                            {
                                vreInfos.Add(list[i]);
                            }
                        }
                    }
                    
                }
            }
            return vreInfos;
        }
       
        protected void plistcategorysearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
                string category = plistcategorysearch.SelectedValue;
                IList<ProductInfo> ilist = getSearchCategory(Util.convertToInt(category));
                p_list.DataSource = ilist;
                p_list.DataBind();
            }
        }
        protected void btnsearch_Click(object sender, EventArgs e)
        {
            string id = ptext_id.Text;

            string sid = Util.checkRequestStringAdmin(id);
            if (string.IsNullOrEmpty(sid))
            {
                //tim theo danh muc
            }
            else
            {
                sendDirect("products.aspx?act=code&code=" + sid + "&n=" + DateTime.Now.Ticks.ToString());

            }
        }

        public string Display
        {
            get
            {
                return display;
            }
            set
            {
                display = value;
            }
        }

        protected void btndelepic_Click(object sender, EventArgs e)
        {
            string[] values = Request.Params.GetValues("checkbtnpic");
            if ((values != null) && (values.Length != 0))
            {
                string scondition = "(";
                for (int i = 0; i < values.Length; i++)
                {
                    scondition = scondition + values[i].Trim() + ",";
                }
                scondition = scondition.Substring(0, scondition.Length - 1) + ") AND ProductID=" + labelhiden.Text + "";
                try
                {
                    PictureController cs = new PictureController();
                    cs.Delete(scondition);
                    plistpic.DataSource = cs.GetAllByProductId(Util.convertToInt(labelhiden.Text));
                    plistpic.DataBind();
                }
                catch (Exception)
                {

                }
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            string filenamecheck = StringApp.removeUnicode(File2.PostedFile.FileName.Substring(File2.PostedFile.FileName.LastIndexOf(@"\") + 1));
            if (string.IsNullOrEmpty(filenamecheck))
            {
             
            }
            else
            {
                //tao moi 
                string filename = getimgthem(File2);
                if (string.IsNullOrEmpty(filename))
                {
                    _logger.Info("ko uploaddc hinh");
                }
                else
                {
                    ProductPicInfo productPicInfo = getParamPic(filename);
                    PictureController cs = new PictureController();
                    cs.Insert(ref productPicInfo);
                    IList<ProductPicInfo> vPictureInfos = cs.GetAllByProductId(Util.convertToInt(Request["pid"]));
                    plistpic.DataSource = vPictureInfos;
                    plistpic.DataBind();
                }
            }
        }
        private ProductPicInfo getParamPic(string picture)
        {
            ProductPicInfo productPic = new ProductPicInfo();
            productPic.ProductId = Util.convertToInt(labelhiden.Text);
            productPic.Picture = picture;
            productPic.ColorId = 1;
            productPic.CodeColor = "#111111";
            productPic.NameVi = "";
            productPic.NameEn = "";
            productPic.Indexs = 1;
            return productPic;


        }
        protected void btnmulti_ckick(object sender, EventArgs e)
        {
            //load_Color(plistcolor);
            PANNELLIST.Visible = false;
            PANNELCREATE.Visible = false;
            PANELPIC.Visible = true;
            PictureController cs = new PictureController();
            plistpic.DataSource = cs.GetAllByProductId(Util.convertToInt(Request["pid"]));
            plistpic.DataBind();
            
        }

        protected void btnreturn_Click(object sender, EventArgs e)
        {
            PANNELCREATE.Visible = true;
            PANELPIC.Visible = false;
        }

        protected void plistcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            LoadCategoryRootSub("vi", plistcategorysub,Util.convertToInt(plistcategory.SelectedValue));
            LoadCategoryRootSubSub("vi", plistcategorysub_sub, Util.convertToInt(plistcategorysub.SelectedValue,0));
        }


        protected void btndeleteall_OnClick(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
                ProductController productController =new ProductController();
                productController.DeleteAll(" WHERE CompanyId=" + UsersInfo.CompanyId);
            }
        }

      
    }
}
