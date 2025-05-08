using System;
using System.Collections;
using System.Collections.Generic;
using NLog;
using web_portal.App_Data;
using web_connection;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial class servicesprovider : abcform
    {
        private string display;

        public string Display
        {
            get { return display; }
            set { display = value; }
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
             base.Page_Load(sender, e);
             if (!IsPostBack)
             {
                 UsersInfo UserInfo = getSession();
                 if (UserInfo!= null)
                 {
                     display = "none";
                     string act = Request["act"];
                     if (string.IsNullOrEmpty(act))
                     {
                         ServiceProviderController cs = new ServiceProviderController();
                         IList<ServiceProviderInfo> ilist = cs.GetAll();
                         if (ilist == null || ilist.Count == 0)
                         {
                             PANNELLIST.Visible = false;
                             PANNELCREATE.Visible = true;
                         }
                         else
                         {
                             PANNELLIST.Visible = true;
                             PANNELCREATE.Visible = false;
                             p_list.DataSource = ilist;
                             p_list.DataBind();
                             Session["VLIST"] = ilist;
                         }
                     }
                     else if (act.Equals("view"))
                     {
                         lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
                         btnAdd.Text = StringApp.MSGUPDATEDANHMUC_VI;
                         PANNELLIST.Visible = false;
                         PANNELCREATE.Visible = true;
                         string sid =Util.checkRequestStringConvertToInt(Request["pid"]);
                         if (string.IsNullOrEmpty(sid))
                         {
                         }
                         else
                         {
                             ServiceProviderInfo info = getByID(Util.convertToInt(sid,-1));
                             if (info == null)
                             {
                             }
                             else
                             {
                                 labelhidden.Text = info.ServiceProviderId + "";
                                 p_name_vi.Text = info.NameVi;
                                 p_name_en.Text = info.NameEn;
                                 p_company_vi.Text = info.CompanyNameVi;
                                 p_company_en.Text = info.CompanyNameEn;
                                 p_address_vi.Text = info.AddressVi;
                                 p_address_en.Text = info.AddressEn;
                                 p_tel.Text = info.Tel;
                                 p_email.Text = info.Email;
                                 p_website.Text = info.Website;
                                 p_indexs.Text = info.Indexs + "";
                                 TextFreecode1.TextData = info.ShortDesVi;
                                 TextFreecode2.TextData = info.ShortDesEn;
                                 Session["SERVICEPROVIDER"] = info;

                                 if (string.IsNullOrEmpty(info.Picture))
                                 {
                                     PANNELFILE.Visible = false;
                                     display = "none";
                                 }
                                 else
                                 {
                                     PANNELFILE.Visible = true;
                                     ImgView1.ImageUrl = "./../resources/serviceprovider/" + info.Picture;
                                     f_filename.Text = info.Picture;
                                     display = "block";
                                 }
                             }
                         }
                     }
                 }
             }
        }
        private ServiceProviderInfo getByID(int serviceproviderid)
        {
            ServiceProviderController cs = new ServiceProviderController();
            ServiceProviderInfo ilist = cs.GetById(serviceproviderid);
            if (ilist == null)
            {
                return null;
            }
            else return ilist;
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
                try
                {
                   ServiceProviderController serviceProviderController =new ServiceProviderController();
                    serviceProviderController.Delete(scondition);
                }
                catch (Exception exception)
                {
                    _logger.Info("Delete ......." + exception.Message);
                }
            }
           sendDirect("servicesprovider.aspx?n=" + DateTime.Now.Ticks);
        }
       
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            PANNELCREATE.Visible = true;
            PANNELLIST.Visible = false;
            lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
            display = "none";
          
        }
        protected void btnAdd_ckick(object sender, EventArgs e)
        {

            if (IsValid)
            {
              
                if (UsersInfo != null)
                {
                    PANNELLIST.Visible = false;
                    ServiceProviderController cs = new ServiceProviderController();
               
                    if (string.IsNullOrEmpty(labelhidden.Text))
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
                        ServiceProviderInfo serviceProviderInfo = getParam(UsersInfo.CompanyId);
                        cs.Insert(ref serviceProviderInfo);
                        StringApp.setCssclass(serviceProviderInfo.ServiceProviderId, 0, p_label);
                        if (serviceProviderInfo.ServiceProviderId > 0)
                        {
                            PANNELFILE.Visible = true;
                            string str2 = getimg();
                            ImgView1.ImageUrl = "./../resources/serviceprovider/" + str2;
                            f_filename.Text = str2;
                            display = "block";
                        }
                    }
                    else
                    {
                        string str2;
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        Object obj = Session["SERVICEPROVIDER"];
                        if(obj!=null)
                        {
                            ServiceProviderInfo serviceProviderInfo = getParamUpdate((ServiceProviderInfo)obj);
                            cs.Update(serviceProviderInfo);
                            StringApp.setCssclass(serviceProviderInfo.ServiceProviderId, 1, p_label);
                            if (serviceProviderInfo.ServiceProviderId > 0)
                            {
                                if (p_check.Checked)
                                {
                                    display = "none";
                                    PANNELFILE.Visible = false;

                                }
                                else
                                {
                                    _logger.Info(" da vo day setup");
                                    str2 = getimg();
                                    if (string.IsNullOrEmpty(str2))
                                    {
                                        if (string.IsNullOrEmpty(f_filename.Text))
                                        {
                                            display = "none";
                                        }
                                        else
                                        {
                                            ImgView1.ImageUrl = "./../resources/serviceprovider/" + f_filename.Text;
                                            display = "block";
                                        }
                                        //
                                    }
                                    else
                                    {
                                        ImgView1.ImageUrl = "./../resources/serviceprovider/" + str2;
                                        f_filename.Text = str2;
                                        display = "block";
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        private string getimg()
        {
            try
            {
                Thumbnail thumbnail = new Thumbnail();
                string str = Server.MapPath("../resources/serviceprovider");
                if (File1.PostedFile != null)
                {
                    string fileName = StringApp.removeUnicode(File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                    int contentLength = File1.PostedFile.ContentLength;
                    if ((contentLength > 0) && (contentLength <= 0x300000))
                    {
                        if (((((contentLength <= 0) || (contentLength > 0x300000)) || ((fileName.IndexOf(".exe") > 0) || (fileName.IndexOf(".EXE") > 0))) || ((fileName.IndexOf(".msi") > 0) || (fileName.IndexOf(".js") > 0))) || (fileName.IndexOf(".JS") > 0))
                        {
                            _logger.Info("FILE SIZE LON QUA :");
                            p_label.Text = "StringApp.MSGUPLOADFILE";
                            return "";
                        }
                        File1.PostedFile.SaveAs(str + @"\" + fileName);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "2161_" + fileName, 2161);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "300_" + fileName, 300);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "500_" + fileName, 500);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "510_" + fileName, 510);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "768_" + fileName, 768);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "1024_" + fileName, 1024);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "1536_" + fileName, 1536);
                        thumbnail.GenerateThumbnailServicePr(fileName, "~/resources/serviceprovider/", "2048_" + fileName, 2048);
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
                _logger.Info("EditProducts.ascx.cs " + exception3.Message);
                p_label.Text = exception3.Message;
                return "";
            }
            return "";
        }
        private ServiceProviderInfo  getParam(int companyid)
        {
            ServiceProviderInfo serviceProviderInfo = new ServiceProviderInfo();
            serviceProviderInfo.CompanyNameVi = p_company_vi.Text;
            serviceProviderInfo.CompanyNameEn = p_company_en.Text;
            serviceProviderInfo.NameVi = p_name_vi.Text;
            serviceProviderInfo.NameEn = p_name_en.Text;
            serviceProviderInfo.AddressVi = p_address_vi.Text;
            serviceProviderInfo.AddressEn = p_address_en.Text;
            serviceProviderInfo.Tel = p_tel.Text;
            serviceProviderInfo.Fax = "";
            serviceProviderInfo.Website = p_website.Text;
            serviceProviderInfo.Email = p_email.Text;
          
            //picture
            try
            {
                string str =
                    StringApp.removeUnicode(
                        File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                if (string.IsNullOrEmpty(str))
                {
                    if (string.IsNullOrEmpty(f_filename.Text))
                    {
                        serviceProviderInfo.Picture="";
                    }
                    else
                    {
                        serviceProviderInfo.Picture=f_filename.Text;
                    }
                }
                else
                {
                    serviceProviderInfo.Picture=str;
                }
            }
            catch(Exception ex)
            {
                serviceProviderInfo.Picture="";
            }
            serviceProviderInfo.StatusId = 1;
            serviceProviderInfo.Edate = DateTime.Now;
            serviceProviderInfo.Mdate = DateTime.Now;
            serviceProviderInfo.Indexs = Util.convertToInt(p_indexs.Text, 100);
            serviceProviderInfo.CompanyId = companyid;
            return serviceProviderInfo;
        }
        private ServiceProviderInfo getParamUpdate(ServiceProviderInfo serviceProviderInfo)
        {
            
            serviceProviderInfo.CompanyNameVi = p_company_vi.Text;
            serviceProviderInfo.CompanyNameEn = p_company_en.Text;
            serviceProviderInfo.NameVi = p_name_vi.Text;
            serviceProviderInfo.NameEn = p_name_en.Text;
            serviceProviderInfo.AddressVi = p_address_vi.Text;
            serviceProviderInfo.AddressEn = p_address_en.Text;
            serviceProviderInfo.Tel = p_tel.Text;
            serviceProviderInfo.Fax = "";
            serviceProviderInfo.Website = p_website.Text;
            serviceProviderInfo.Email = p_email.Text;

            //picture
            try
            {
                string str =
                    StringApp.removeUnicode(
                        File1.PostedFile.FileName.Substring(File1.PostedFile.FileName.LastIndexOf(@"\") + 1));
                if (string.IsNullOrEmpty(str))
                {
                    if (string.IsNullOrEmpty(f_filename.Text))
                    {
                        serviceProviderInfo.Picture = "";
                    }
                    else
                    {
                        serviceProviderInfo.Picture = f_filename.Text;
                    }
                }
                else
                {
                    serviceProviderInfo.Picture = str;
                }
            }
            catch (Exception ex)
            {
                serviceProviderInfo.Picture = "";
            }
            serviceProviderInfo.StatusId = 1;
            serviceProviderInfo.Mdate = DateTime.Now;
            serviceProviderInfo.Indexs = Util.convertToInt(p_indexs.Text, 100);
            return serviceProviderInfo;
            
        }
    }
}
