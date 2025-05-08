using System;
using System.Collections.Generic;
using System.Threading;
using web_model;
using web_portal.App_Data;
using web_util;

namespace web_portal.vi
{
    public partial class contact :Webabc
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender,e);
            if (!IsPostBack)
            {
                CompanyInfo companyInfo = GetCompanyInfo();
                if (companyInfo != null)
                {
                    List<CompanyInfo> vList = new List<CompanyInfo>();
                    vList.Add(companyInfo);
                    plistintro.DataSource = vList;
                    plistintro.DataBind();
                    //ShowGetCategoryRoot(plistcate);
                }
                WebsiteInfo websiteInfo = GetwWebsiteInfo();
                string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
                if (websiteInfo != null)
                {
                    WebsiteDetailInfo websiteInfoDetail = new WebsiteDetailInfo();
                    string pathpicture = websiteInfo.WebSiteName + "/styles/images/logo.png";
                    string postcode = websiteInfo.PostCode;
                    string postcodename = websiteInfo.PostCodeName;
                    string addressLocality = websiteInfo.AddressLocality;
                    string addressCountry = websiteInfo.AddressCountry;
                    string contryname = websiteInfo.CountryName;
                    string tel = websiteInfo.Tel;
                    string stitle = string.Empty;
                    if (lang.Equals("vi"))
                        stitle = websiteInfo.TitleVi;
                    else if (lang.Equals("en"))
                        stitle = websiteInfo.TitleEn;

                    }
                
            }
           
        }

        protected void psend_Click(object sender, EventArgs e)
        {
            
               
            
        }
       

     
        private string getCustomerInfo(FeedBackInfo feedBackInfo)
        {
            string s = "<table  border=\"0\" width=\"100%\"><tr><td align=\"left\">" +
                       "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" style=\"line-height:180%;\" width=\"100%\">" +
                        "<tr>" +
                         "<td colspan=\"2\"  style=\"font-weight:bold;text-transform:capitalize\">Thông tin liên lạc</td>" +
                        "</tr>" +
                        "<tr>" +
                         "<td align=\"left\">Họ và tên</td><td align=\"left\">" + feedBackInfo.Name + "</td>" +
                        "</tr>" +
                        "<tr>" +
                          "<td colspan=\"2\" style=\"border-bottom:dotted 1px #cccccc;\"></td>" +
                        "</tr>" +
                        "<tr>" +
                         "<td align=\"left\">Địa chỉ</td><td align=\"left\">" + feedBackInfo.Address + "</td>" +
                        "</tr>" +
                        "<tr>" +
                          "<td colspan=\"2\" style=\"border-bottom:dotted 1px #cccccc;\"></td>" +
                        "</tr>" +
                         "<tr>" +
                         "<td align=\"left\" >Điện thoại</td><td align=\"left\">" + feedBackInfo.Tel + "</td>" +
                        "</tr>" +
                          "<tr>" +
                          "<td colspan=\"2\" style=\"border-bottom:dotted 1px #cccccc;\"></td>" +
                        "</tr>" +
                         "<tr>" +
                         "<td align=\"left\" >Email</td><td align=\"left\">" + feedBackInfo.Email + "</td>" +
                        "</tr>" +
                         "<tr>" +
                          "<td colspan=\"2\" style=\"border-bottom:dotted 1px #cccccc;\"></td>" +
                        "</tr>" +
                        "<tr>" +
                         "<td align=\"left\" >Tiêu đề</td><td align=\"left\">" + feedBackInfo.Subject + "</td>" +
                        "</tr>" +
                         "<tr>" +
                          "<td colspan=\"2\" style=\"border-bottom:dotted 1px #cccccc;\"></td>" +
                        "</tr>" +
                        "<tr>" +
                         "<td align=\"left\" width=\"170\" >Nội dung</td><td align=\"left\">" + feedBackInfo.Contents + "</td>" +
                        "</tr>" +
                        "</table></td></tr></table>";

            return s;
        }

        
        protected void btnOk_OnClick(object sender, EventArgs e)
        {

            //FeedBackController controller = new FeedBackController();
            //FeedBackInfo feedBackInfo = new FeedBackInfo();
            //feedBackInfo.Name = Util.checkRequestStringInput(ptextname.Text, "Full name");
            ////feedBackInfo.Company = Util.checkRequestStringInput(txt_company.Text, "Company name");
            ////feedBackInfo.Address = Util.checkRequestStringInput(e.Text, "Address");
            //feedBackInfo.Tel = Util.checkRequestStringInput(ptel.Text, "Tel");
            //feedBackInfo.Email = pemail.Text;
            //feedBackInfo.Subject = Util.checkRequestStringInput("SuSu", "Subject");
            //feedBackInfo.Edate = feedBackInfo.Mdate = DateTime.Now;
            //feedBackInfo.Contents = Util.checkRequestStringInput(ptextsend.Text, "Contents");
            //controller.Insert(ref feedBackInfo);
            //StringApp.setCssclass(feedBackInfo.FeedBackId, 0, plabel, StringApp.MSGFEEDBACKOK, StringApp.MSGFEEDBACKERROR);
            //btnOk.Visible = false;
            //sendemail
            // SendEmail(feedBackInfo);
            _logger.Info("Send Email Ok");
        }
    }
}