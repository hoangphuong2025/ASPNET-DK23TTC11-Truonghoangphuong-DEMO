using System;
using web_portal.App_Data;
using web_controls;
using web_model;

namespace web_portal.webadmin
{
    public partial class company : abcform
    {
       
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
            
                if (UsersInfo != null)
                {
                    CompanyController companycs = new CompanyController();
                    CompanyInfo ilist = companycs.GetById(UsersInfo.CompanyId);
                    if (ilist == null)
                    {
                        _logger.Info("khong tim thay company info");
                        btnSave.Text = StringApp.MSGCREATEOK_VI;
                        Session.Remove("ACTION");
                    }
                    else
                    {
                        _logger.Info("hienn thi thong tin tim thay company info");
                        txtName.Text = ilist.NameVi;
                        txtName_en.Text = ilist.NameEn;
                        txtaddress.Text = ilist.AddressVi;
                        txtAddress_en.Text = ilist.AddressEn;
                        txtemail.Text = ilist.Email;
                        txttele.Text = ilist.Tel;
                        txtfax.Text = ilist.Fax;
                        txtcalphone.Text = ilist.CellPhone;
                        txtwebsite.Text = ilist.WebSite;
                        txtgiamdoc.Text = ilist.Director;
                        p_copywriter.Text = ilist.Description;
                        pmap.Text = ilist.SiteMap;
                        Session["ACTION"] = ilist;
                    }
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
        
            if (UsersInfo != null)
            {
                long ilong;
                Object obj = Session["ACTION"];
                if (obj == null)
                {
                    CompanyInfo companyInfo = getCompanyInfo(UsersInfo.UserId);
                    CompanyController comp = new CompanyController();
                    comp.Insert(ref companyInfo);
                    StringApp.setCssclass(1, 0, Label1);
                }
                else
                {

                    CompanyController comp = new CompanyController();
                    CompanyInfo companyInfo = getCompanyUpdateInfo((CompanyInfo)obj);
                    comp.Update(companyInfo);
                    StringApp.setCssclass(1, 1, Label1);
                }

            }

        }
        private CompanyInfo getCompanyInfo(int userid)
        {
            CompanyInfo companyInfo = new CompanyInfo();
            companyInfo.UserId = userid;
            companyInfo.NameVi = txtName.Text;
            companyInfo.NameEn = txtName_en.Text;
            companyInfo.Description = p_copywriter.Text;
            companyInfo.AddressVi = txtaddress.Text;
            companyInfo.AddressEn = txtAddress_en.Text;
            companyInfo.Tel = txttele.Text;
            companyInfo.Fax = txtfax.Text;
            companyInfo.Email = txtemail.Text;
            companyInfo.CellPhone = txtcalphone.Text;
            companyInfo.WebSite = txtwebsite.Text;
            companyInfo.Director = txtgiamdoc.Text;
            companyInfo.Edate = DateTime.Now;
            companyInfo.Mdate = DateTime.Now;
            companyInfo.McId = userid;
            companyInfo.SiteMap = pmap.Text;
            return companyInfo;
        }
        private CompanyInfo getCompanyUpdateInfo(CompanyInfo companyInfo)
        {
            companyInfo.NameVi = txtName.Text;
            companyInfo.NameEn = txtName_en.Text;
            companyInfo.Description = p_copywriter.Text;
            companyInfo.AddressVi = txtaddress.Text;
            companyInfo.AddressEn = txtAddress_en.Text;
            companyInfo.Tel = txttele.Text;
            companyInfo.Fax = txtfax.Text;
            companyInfo.Email = txtemail.Text;
            companyInfo.CellPhone = txtcalphone.Text;
            companyInfo.WebSite = txtwebsite.Text;
            companyInfo.Director = txtgiamdoc.Text;
            companyInfo.Mdate = DateTime.Now;
            companyInfo.SiteMap = pmap.Text;
            return companyInfo;
        }
    }
}

