using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_portal.App_Data;
using web_util;


namespace web_portal.webadmin
{
    public partial class banner : abcform
    {
        private string display;
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
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            if (!IsPostBack)
            {
                
                if (UsersInfo!= null)
                {
                     string act = Request["act"];
                     BannerController newsKindOfController = new BannerController();
                    if (string.IsNullOrEmpty(act))
                    {
                        ImgView1.Visible = false;
                        
                        PANNELCREATE.Visible = false;

                        IList<BannerInfo> ilist = newsKindOfController.GetSearch(" WHERE CategoryId=1");
                        if (ilist == null || ilist.Count == 0)
                        {
                            btnDelete.Visible = false;
                          
                        }
                        else
                        {
                            btnDelete.Visible = true;
                            p_list.DataSource = ilist;
                            p_list.DataBind();
                          
                        }
                    }
                    else
                    {
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        btnAdd.Text = StringApp.MSGBUTTONUPDATE_VI;
                        PANNELLIST.Visible = false;
                        string sid =Util.checkRequestStringConvertToInt(Request["pid"]);
                        if (string.IsNullOrEmpty(sid))
                        {
                        }
                        else
                        {

                            BannerInfo bannerInfo = newsKindOfController.GetById(Util.convertToInt(sid));
                            if (bannerInfo != null)
                            {
                                labelhiden.Text = bannerInfo.Id + "";
                                txt_namevi.Text = bannerInfo.NameVi;
                                txt_nameen.Text = bannerInfo.NameEn;
                                txt_desvi.Text = bannerInfo.DescriptionVi;
                                txt_desen.Text = bannerInfo.DescriptionEn;
                                txt_index.Text = bannerInfo.Indexs+"";
                                if (string.IsNullOrEmpty(bannerInfo.Picture))
                                {
                                    display = "none";
                                    PANNELFILE.Visible = false;
                                }
                                else
                                {
                                    PANNELFILE.Visible = true;
                                    ImgView1.Visible = true;
                                    ImgView1.ImageUrl = "./../resources/slides/" + bannerInfo.Picture;
                                    f_filename.Text = bannerInfo.Picture;
                                    display = "";
                                }
                            }
                        }
                    }
                }
            }
        }
        protected void plistpic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

           
        }
        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                BannerInfo dataItem = (BannerInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Label labelkindof = (Label)e.Item.FindControl("labelkindof");
                    if (labelkindof != null)
                    {
                       
                        
                    }
                  

                }
            }
        }
        protected void btnAddMore_ckick(object sender, EventArgs e)
        {
           
        }
        protected void btndelepic_Click(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
                
            }
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {
            
            
        }
        private string getimgthem(HtmlInputFile filepic)
        {
            _logger.Info("GET IMAGES");
            Exception exception;
            try
            {
                _logger.Info("GET IMAGES 1");
                string str = Server.MapPath("../resources/slides");
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
        protected void btnreturn_Click(object sender, EventArgs e)
        {
            PANNELCREATE.Visible = true;
            PANELPIC.Visible = false;
        }
        
        

        protected void btnAdd_ckick(object sender, EventArgs e)
        {
            if (IsValid)
            {
              
                if (UsersInfo != null)
                {
                    PANNELLIST.Visible = false;
                    BannerController bannerController = new BannerController();
                   
                    if (string.IsNullOrEmpty(labelhiden.Text))
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC;
                        BannerInfo bannerInfo = getParam();
                        string str2 = getimg(File1);
                        bannerInfo.Picture =str2;
                        bannerController.Insert(ref bannerInfo);
                        StringApp.setCssclass(bannerInfo.Id, 0, p_label);
                        if (bannerInfo.Id > 0)
                        {
                            ImgView1.ImageUrl = "./../resources/slides/" + str2;
                            f_filename.Text = str2;
                        }
                    }
                    else
                    {
                        BannerInfo bannerInfo = bannerController.GetById(Util.convertToInt(labelhiden.Text));
                        bannerInfo = getParamUpdate(bannerInfo);
                        string str2 = getimg(File1);
                        if (string.IsNullOrEmpty(str2))
                        {
                            _logger.Info("string.IsNullOrEmpty(str2)");
                            if (string.IsNullOrEmpty(f_filename.Text))
                            {
                                //display = "none";
                                bannerInfo.Picture = "";
                                _logger.Info("productInfo.Picture =");
                            }
                            else
                            {
                                _logger.Info("productInfo.Picture co hinh");
                                ImgView1.ImageUrl = "./../resources/slides/" + f_filename.Text;
                                display = "block";
                                bannerInfo.Picture = f_filename.Text;
                            }
                        }
                        else
                        {
                            _logger.Info("str2 co hinh");
                            ImgView1.ImageUrl = "./../resources/slides/" + str2;
                            f_filename.Text = str2;
                            display = "block";
                            bannerInfo.Picture = str2;

                        }
                        
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;

                        bannerController.Update(bannerInfo);
                        StringApp.setCssclass(Language,bannerInfo.Id, 1, p_label);
                    }
                }
            }
        }
   
        private BannerInfo getParam()
        {
            BannerInfo bannerInfo = new BannerInfo();
            bannerInfo.NameVi = txt_namevi.Text;
            bannerInfo.NameEn = txt_nameen.Text;
            bannerInfo.DescriptionVi = txt_desvi.Text;
            bannerInfo.DescriptionEn = txt_desen.Text;
            bannerInfo.Indexs = Util.convertToInt(txt_namevi.Text,1);
            bannerInfo.CategoryId = 1;
            return bannerInfo;
        }

        private BannerInfo getParamUpdate(BannerInfo bannerInfo)
        {
            bannerInfo.NameVi = txt_namevi.Text;
            bannerInfo.NameEn = txt_nameen.Text;
            bannerInfo.DescriptionVi = txt_desvi.Text;
            bannerInfo.DescriptionEn = txt_desen.Text;
            bannerInfo.Indexs = Util.convertToInt(txt_index.Text, 1);
            bannerInfo.CategoryId = 1;
            return bannerInfo;
        }


        protected void btnAddList_Click(object sender, EventArgs e)
        {
            ImgView1.Visible = false;
            PANNELLIST.Visible = false;
            PANNELCREATE.Visible = true;
            lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
          
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] vparam = Request.Params.GetValues("checkbtn");
            if (vparam == null || vparam.Length == 0)
            {
            }
            else
            {
                string result = "(";
                for (int i = 0; i < vparam.Length; i++)
                {
                    result += vparam[i].Trim() + ",";
                }
                result = result.Substring(0, result.Length - 1);
                result += ")";

                try
                {
                    BannerController newsKindOfController = new BannerController();
                    newsKindOfController.Delete(result);
                    
                }
                catch (Exception ex)
                {
                }
                sendDirect("banner.aspx?pindex=1&n="+DateTime.Now.Ticks);
            }
        }
      
        private string getimg(HtmlInputFile filepic)
        {
            _logger.Info("GET IMAGES");
            Exception exception;

            try
            {
                Thumbnail thumbnail = new Thumbnail();
                _logger.Info("GET IMAGES 1");
                string str = Server.MapPath("../resources/slides");
                if (filepic.PostedFile != null)
                {
                    string fileName = StringApp.removeUnicode(filepic.PostedFile.FileName.Substring(filepic.PostedFile.FileName.LastIndexOf(@"\") + 1));
                    int contentLength = filepic.PostedFile.ContentLength;
                    if ((contentLength > 0) && (contentLength <= 0x300000))
                    {
                        if (((((contentLength <= 0) || (contentLength > 0x300000)) || ((fileName.IndexOf(".exe") > 0) || (fileName.IndexOf(".EXE") > 0))) || ((fileName.IndexOf(".msi") > 0) || (fileName.IndexOf(".js") > 0))) || (fileName.IndexOf(".JS") > 0))
                        {
                            _logger.Info("FILE SIZE LON QUA :");
                            return "";
                        }
                        filepic.PostedFile.SaveAs(str + @"\" + fileName);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","2161_"+fileName, 2161);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","300_" + fileName, 300);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","500_" + fileName, 500);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","768_" + fileName, 768);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","1024_" + fileName, 1024);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","1536_" + fileName, 1536);
                        thumbnail.GenerateThumbnailSlides(fileName, "~/resources/slides/","2048_" + fileName, 2048);
                        return fileName;
                    }
                }
                else
                {
                    _logger.Info("PostedFile nulll");
                    return "";
                }
            }
            catch (Exception exception3)
            {

                _logger.Info("Error images :" + exception3.Message);

                return "";
            }
            return "";
        }
    }
}

