using System;
using System.Collections.Generic;
using web_controls;
using web_model;
using web_portal.App_Data;
using web_util;


namespace web_portal.webadmin
{
    public partial class website : abcform
    {
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            if (!IsPostBack)
            {
                if (UsersInfo!= null)
                {
                     string act = Request["act"];
                     WebsiteController newsKindOfController = new WebsiteController();
                    if (string.IsNullOrEmpty(act))
                    {
                        lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
                        PANNELCREATE.Visible = false;

                        IList<WebsiteInfo> ilist = newsKindOfController.GetAll();
                        if (ilist == null || ilist.Count == 0)
                        {
                            btnDelete.Visible = false;
                          
                        }
                        else
                        {
                            btnDelete.Visible = true;
                            p_list.DataSource = ilist;
                            p_list.DataBind();
                            btnAddList.Visible = false;
                        }
                    }
                    else
                    {
                        btnAddList.Visible = false;
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        btnAdd.Text = StringApp.MSGBUTTONUPDATE_VI;
                        string sid =Util.checkRequestStringConvertToInt(Request["pid"]);
                        if (string.IsNullOrEmpty(sid))
                        {
                        }
                        else
                        {
                            WebsiteInfo kindofinfo = newsKindOfController.GetById(Util.convertToInt(sid));
                            if (kindofinfo != null)
                            {
                                labelhiden.Text = kindofinfo.Id + "";
                                ptitle.Text = kindofinfo.TitleVi;
                                ptitle_en.Text = kindofinfo.TitleEn;
                                p_name.Text = kindofinfo.DesKeyWordVi;
                                p_nameen.Text = kindofinfo.DesKeyWordEn;
                                p_des.Text = kindofinfo.DesVi;
                                p_desen.Text = kindofinfo.DesEn;
                                p_website.Text = kindofinfo.WebSiteName;
                                p_postcode.Text = kindofinfo.PostCode;
                                p_postcodename.Text=kindofinfo.PostCodeName;
                                p_addressLocality.Text=kindofinfo.AddressLocality;
                                p_addressCountry.Text=kindofinfo.AddressCountry;
                                p_countryname.Text=kindofinfo.CountryName;
                                p_tel.Text=kindofinfo.Tel;
                            }
                        }
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
                    WebsiteController newsKindOfController = new WebsiteController();
                   
                    if (string.IsNullOrEmpty(labelhiden.Text))
                    {
                        lblTitle.Text = StringApp.MSGCREATEDANHMUC;

                        WebsiteInfo mNewsKindOfInfo = getParam();
                        newsKindOfController.Insert(ref mNewsKindOfInfo);
                        StringApp.setCssclass(mNewsKindOfInfo.Id, 0, p_label);
                    }
                    else
                    {
                        lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        WebsiteInfo mNewsKindOfInfo = getParamUpdate(newsKindOfController.GetById(Util.convertToInt(Request["pid"])));
                        newsKindOfController.Update(mNewsKindOfInfo);
                        StringApp.setCssclass(mNewsKindOfInfo.Id, 1, p_label);
                    }
                }
            }
        }
        private WebsiteInfo getParam()
        {
            WebsiteInfo newsKindOfInfo = new WebsiteInfo();
            newsKindOfInfo.TitleVi = ptitle.Text;
            newsKindOfInfo.TitleEn = ptitle_en.Text;
            newsKindOfInfo.DesKeyWordVi =p_name.Text;
            newsKindOfInfo.DesKeyWordEn =p_nameen.Text;
            newsKindOfInfo.DesVi =p_des.Text;
            newsKindOfInfo.DesEn =p_desen.Text;
            newsKindOfInfo.WebSiteName = p_website.Text;
            //update 27/09/2022
            newsKindOfInfo.PostCode = p_postcode.Text;
            newsKindOfInfo.PostCodeName = p_postcodename.Text;
            newsKindOfInfo.AddressLocality = p_addressLocality.Text;
            newsKindOfInfo.AddressCountry = p_addressCountry.Text;
            newsKindOfInfo.CountryName = p_countryname.Text;
            newsKindOfInfo.Tel = p_tel.Text;
            return newsKindOfInfo;
        }
        private WebsiteInfo getParamUpdate(WebsiteInfo newsKindOfInfo)
        {
            newsKindOfInfo.TitleVi = ptitle.Text;
            newsKindOfInfo.TitleEn = ptitle_en.Text;
            newsKindOfInfo.DesKeyWordVi = p_name.Text;
            newsKindOfInfo.DesKeyWordEn = p_nameen.Text;
            newsKindOfInfo.DesVi = p_des.Text;
            newsKindOfInfo.DesEn = p_desen.Text;
            newsKindOfInfo.WebSiteName = p_website.Text;
            newsKindOfInfo.PostCode = p_postcode.Text;
            newsKindOfInfo.PostCodeName = p_postcodename.Text;
            newsKindOfInfo.AddressLocality = p_addressLocality.Text;
            newsKindOfInfo.AddressCountry = p_addressCountry.Text;
            newsKindOfInfo.CountryName = p_countryname.Text;
            newsKindOfInfo.Tel = p_tel.Text;
            return newsKindOfInfo;
        }
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            PANNELLIST.Visible = false;
            PANNELCREATE.Visible = true;
            lblTitle.Text = StringApp.MSGCREATEDANHMUC_VI;
          
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Util.convertToInt(Request["pid"]);
            if (id > 0)
            {
                try
                {
                    WebsiteController newsKindOfController = new WebsiteController();
                    newsKindOfController.Delete("(" + id + ")");

                }
                catch (Exception ex)
                {

                }
                sendDirect("website.aspx?pindex=1&n=" + DateTime.Now.Ticks);
            }
           }
        }
    }


