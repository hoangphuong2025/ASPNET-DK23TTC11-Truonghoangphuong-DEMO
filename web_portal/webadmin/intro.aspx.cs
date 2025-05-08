using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial  class intro : abcform
    {
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            
            if (UsersInfo != null)
            {
                if (string.IsNullOrEmpty(labelhiden.Text))
                {
                    IntroController introController = new IntroController();
                    IntroInfo introInfo = getParam(UsersInfo.UserId, UsersInfo.CompanyId);
                    introController.Insert(ref introInfo);
                    StringApp.setCssclass(Language,introInfo.IntroId, 0, p_label);
                }
                else
                {
                    Object obj = Session["INTROINFO"];
                    if (obj == null)
                    {

                    }
                    else
                    {
                        IntroController introController = new IntroController();
                        IntroInfo introInfo = GetParamUpdate((IntroInfo)obj);
                        introController.Update(introInfo);
                        StringApp.setCssclass(Language,introInfo.IntroId, 1, p_label);
                    }
                 }
            }
        }

        protected void btnAddList_Click(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
                PANNELCREATE.Visible = true;
                PANNELLIST.Visible = false;
                p_label.Text = "";
                p_error.Text = "";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string[] values = Request.Params.GetValues("checkbtn");
            if ((values != null) && (values.Length != 0))
            {
                string scondition = "(";
                for (int i = 0; i < values.Length; i++)
                {
                    scondition = scondition + "'" + values[i].Trim() + "',";
                }
                scondition = scondition.Substring(0, scondition.Length - 1) + ")";
                try
                {
                    new IntroController().Delete(scondition);
                }
                catch (Exception exception)
                {
                    _logger.Info("Buton delete error" + exception.Message);
                }
            }
            sendDirect("intro.aspx?menuid=4&n=" + DateTime.Now.Ticks);
        }

        private IntroInfo getByID(int introd)
        {
            IntroController introController = new IntroController();
            IntroInfo list = introController.GetById(introd);
            if ((list == null))
            {
                return null;
            }
            return list;
        }

        private IntroInfo getParam(int mcid, int companyid)
        {
            IntroInfo introInfo = new IntroInfo();

            introInfo.UserId =mcid;
            introInfo.CompanyId=companyid;
            introInfo.TitleVi =p_title.Text;
            introInfo.TitleEn = ptitle_en.Text;
            introInfo.ShortDesVi = TextFreecode3.TextData;
            introInfo.ShortDesEn="";
            introInfo.DescriptionVi = TextFreecode1.TextData;
            introInfo.DescriptionEn= TextFreecode2.TextData;
            introInfo.Indexs = Util.convertToInt(p_index.Text);
            introInfo.IntroKindOfId = Util.convertToInt(pkindof.SelectedValue);
            introInfo.IntroStatusId =Util.convertToInt(p_status.SelectedValue);
            introInfo.Edate=introInfo.Mdate =DateTime.Now;
            introInfo.SourceText = "";
            introInfo.Picture = "";
            return introInfo;
        }

        private IntroInfo GetParamUpdate(IntroInfo introInfo)
        {
            introInfo.TitleVi = p_title.Text;
            introInfo.TitleEn = ptitle_en.Text;
            introInfo.ShortDesVi = TextFreecode3.TextData;
            introInfo.DescriptionVi = TextFreecode1.TextData;
            introInfo.DescriptionEn = TextFreecode2.TextData;
            introInfo.Indexs = Util.convertToInt(p_index.Text);
            introInfo.IntroStatusId = Util.convertToInt(p_status.SelectedValue);
            introInfo.IntroKindOfId = Util.convertToInt(pkindof.SelectedValue);
            introInfo.Mdate = DateTime.Now;
            
            return introInfo;
        }

        private static string getStatusName(string lang, int statusid)
        {
            if (statusid == 1)
            {
                if (lang.Equals("vi"))
                {
                    return "hiển thị";
                }
                return "display";
            }
            if (lang.Equals("vi"))
            {
                return "kh\x00f4ng hiển thị";
            }

            return "not display";
        }

        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            IntroInfo dataItem = (IntroInfo)e.Item.DataItem;
            if (dataItem != null)
            {
                Label label = (Label)e.Item.FindControl("p_statusname");
                if (label == null)
                {
                    
                }
                else
                {
                    label.Text = getStatusName(lang, dataItem.IntroStatusId);
                }
                Label labelcategory = (Label)e.Item.FindControl("labelcategory");

                if (labelcategory != null)
                {
                    ListItem item  = pkindof.Items.FindByValue(dataItem.IntroKindOfId.ToString());
                    if (item != null)
                        labelcategory.Text = item.Text;
                }
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                
                if (UsersInfo != null)
                {
                    string str = Request["act"];
                    if (string.IsNullOrEmpty(str))
                    {
                        Session.Remove("INTROINFO");
                        IntroController introController = new IntroController();
                        PANNELLIST.Visible = true;
                        PANNELCREATE.Visible = false;
                        IList<IntroInfo> list = introController.GetAllSearch(" Order by Indexs ASC");
                        if(list==null||list.Count==0)
                        {
                            
                        }
                        else 
                        {
                            p_list.DataSource = list;
                            p_list.DataBind();
                            
                        }
                    }
                    else if (str.Equals("view"))
                    {
                        btnAdd.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        IntroInfo info2 = getByID(Util.convertToInt(Request["pid"]));
                        if (info2 != null)
                        {
                            lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                            labelhiden.Text = info2.IntroId.ToString();
                            p_title.Text = info2.TitleVi;
                            ptitle_en.Text = info2.TitleEn;
                            TextFreecode1.TextData = info2.DescriptionVi;
                            TextFreecode2.TextData = info2.DescriptionEn;
                            TextFreecode3.TextData = info2.ShortDesVi;

                            p_index.Text = info2.Indexs.ToString();
                            StringApp.setSelectDropdown(p_status,info2.IntroStatusId);
                            StringApp.setSelectDropdown(pkindof, info2.IntroKindOfId);
                            Session["INTROINFO"] = info2;
                        }
                        
                    }
                }
            }
        }
    }
}
