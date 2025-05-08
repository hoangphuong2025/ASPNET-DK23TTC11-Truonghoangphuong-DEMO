using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_controls;
using web_model;
using web_portal.App_Data;
using web_util;


namespace web_portal.webadmin
{
    public partial class product_status : abcform
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
                     ProductStatusController newsKindOfController = new ProductStatusController();
                    if (string.IsNullOrEmpty(act))
                    {
                        ImgView1.Visible = false;
                        IList<ProductStatusInfo> ilist = newsKindOfController.GetAll();
                        if (ilist == null || ilist.Count == 0)
                        {
                            btnDelete.Visible = false;
                            PANNELCREATE.Visible = true;
                        }
                        else
                        {
                        
                            PANNELCREATE.Visible = false;
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

                            ProductStatusInfo socialInfo = newsKindOfController.GetById(Util.convertToInt(sid));
                            if (socialInfo != null)
                            {
                                labelhiden.Text = socialInfo.Id + "";
                                txt_namevi.Text = socialInfo.NameVi;
                                txt_nameen.Text = socialInfo.NameEn;
                                txt_index.Text = socialInfo.Indexs+"";
                                if (string.IsNullOrEmpty(socialInfo.Picture))
                                {
                                    display = "none";
                                    PANNELFILE.Visible = false;
                                }
                                else
                                {
                                    PANNELFILE.Visible = true;
                                    ImgView1.Visible = true;
                                    ImgView1.ImageUrl = "./../resources/status/" + socialInfo.Picture;
                                    f_filename.Text = socialInfo.Picture;
                                    display = "";
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                ProductStatusInfo dataItem = (ProductStatusInfo)e.Item.DataItem;
                if (dataItem != null)
                {
                    Label labelkindof = (Label)e.Item.FindControl("labelkindof");
                    if (labelkindof != null)
                    {
                       
                        
                    }
                  

                }
            }
        }
        protected void btnAdd_ckick(object sender, EventArgs e)
        {
            if (IsValid)
            {
              
                if (UsersInfo != null)
                {
                    PANNELLIST.Visible = false;
                    ProductStatusController socialController = new ProductStatusController();
                   
                    if (string.IsNullOrEmpty(labelhiden.Text))
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC;
                        ProductStatusInfo socialInfo = getParam(UsersInfo);
                        string str2 = getimg(File1);
                        socialInfo.Picture = str2;
                        socialController.Insert(ref socialInfo);
                        StringApp.setCssclass(socialInfo.Id, 0, p_label);
                        if (socialInfo.Id > 0)
                        {
                            ImgView1.ImageUrl = "./../resources/status/" + str2;
                            f_filename.Text = str2;
                        }
                    }
                    else
                    {
                        ProductStatusInfo socialInfo = socialController.GetById(Util.convertToInt(labelhiden.Text));
                        socialInfo = getParamUpdate(socialInfo);
                        string str2 = getimg(File1);
                        if (string.IsNullOrEmpty(str2))
                        {
                            _logger.Info("string.IsNullOrEmpty(str2)");
                            if (string.IsNullOrEmpty(f_filename.Text))
                            {
                                display = "none";
                                socialInfo.Picture = "";
                                _logger.Info("productInfo.Picture =");
                            }
                            else
                            {
                                _logger.Info("productInfo.Picture co hinh");
                                ImgView1.ImageUrl = "./../resources/status/" + f_filename.Text;
                                display = "block";
                                socialInfo.Picture = f_filename.Text;
                            }
                        }
                        else
                        {
                            _logger.Info("str2 co hinh");
                            ImgView1.ImageUrl = "./../resources/status/" + str2;
                            f_filename.Text = str2;
                            display = "block";
                            socialInfo.Picture = str2;

                        }
                        
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        socialController.Update(socialInfo);
                        StringApp.setCssclass(socialInfo.Id, 1, p_label);
                    }
                }
            }
        }

        private ProductStatusInfo getParam(UsersInfo usersInfo)
        {
            ProductStatusInfo socialInfo = new ProductStatusInfo();
            socialInfo.CompanyId = usersInfo.CompanyId;
            socialInfo.NameVi = txt_namevi.Text;
            socialInfo.NameEn = txt_nameen.Text;
            socialInfo.Indexs = Util.convertToInt(txt_index.Text, 1);
            socialInfo.Picture = "";
            return socialInfo;
        }

        private ProductStatusInfo getParamUpdate(ProductStatusInfo socialInfo)
        {
            socialInfo.NameVi = txt_namevi.Text;
            socialInfo.NameEn = txt_nameen.Text;
            socialInfo.Indexs = Util.convertToInt(txt_index.Text, 1);
            socialInfo.Picture = "";
            return socialInfo;
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
                    ProductStatusController newsKindOfController = new ProductStatusController();
                    newsKindOfController.Delete(result);
                    
                }
                catch (Exception ex)
                {
                }
                sendDirect("product_status.aspx?pindex=1&n="+DateTime.Now.Ticks);
            }
        }
        private void GenerateThumbnails(double scaleFactor, string sourpath, string fileName, string fileas)
        {
            Stream streamsource = File.OpenRead(sourpath + @"\" + fileName);
            _logger.Info("GenerateThumbnails sourpath:" + sourpath + @"\" + fileName);
            string targetPath = Server.MapPath("~/styles/slides/thumb/") + @"\" + fileas;
            _logger.Info("GenerateThumbnails targetPath:" + targetPath);
            using (var image = System.Drawing.Image.FromStream(streamsource))
            {
                _logger.Info("Width old:" +  (int)(image.Width));
                var newWidth = (int)(image.Width * scaleFactor);
                _logger.Info("GenerateThumbnails 1 newWidth:" + newWidth);
                var newHeight = (int)(image.Height * scaleFactor);
                _logger.Info("GenerateThumbnails 1 newHeight:" + newHeight);
                var thumbnailImg = new Bitmap(newWidth, newHeight);
                _logger.Info("GenerateThumbnails 2");
                var thumbGraph = Graphics.FromImage(thumbnailImg);
                _logger.Info("GenerateThumbnails 3");
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                _logger.Info("GenerateThumbnails 4");
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                _logger.Info("GenerateThumbnails 5");
                var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                _logger.Info("GenerateThumbnails 6");
                thumbGraph.DrawImage(image, imageRectangle);
                thumbnailImg.Save(targetPath, image.RawFormat);
            }
        }
        private string getimg(HtmlInputFile filepic)
        {
            _logger.Info("GET IMAGES");
            Exception exception;

            try
            {
                _logger.Info("GET IMAGES 1");
                string str = Server.MapPath("../resources/status");
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
                       // GenerateThumbnails(0.175, str, fileName,fileName);
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

