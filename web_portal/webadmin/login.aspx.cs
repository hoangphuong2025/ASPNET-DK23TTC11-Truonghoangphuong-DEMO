using System;
using System.Collections.Generic;
using System.Web.UI;
using NLog;
using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial class login : Page
    {
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblErr.Text = "";
            lbPrompt.Text = "";
            Session.RemoveAll();
            string text = txtNickSMS.Text;
            string pwd = txtPassWord.Text.Trim();
            _logger.Info("btnLogin_Click");
            if (Util.checkRequestString(text) == null || Util.checkRequestString(pwd) == null)
            {
                
            }
            else 
            {
                try
                {
                    Session["HEIGHTCURRENT"] = idscreen.Value;
                    UserController users = new UserController();
                    string pass = StringApp.CreatePasswordHash(pwd);
                    IList<UsersInfo> list = users.CheckByLoginId(text, pass);
                    if ((list == null) || (list.Count == 0))
                    {
                    
                        lblErr.Text = "User Or Password not found";
                    }
                    else
                    {
                        Session["ADMIN"] = list[0];
                        UsersInfo usersInfo = list[0];
                        usersInfo.Mdate = DateTime.Now;
                        UserController userController = new UserController();
                        userController.Update(usersInfo);
                        if (pselect.SelectedValue.IndexOf("webadmin_en/login")>=0)
                        {
                            _logger.Info("Session is ok");
                            sendDirect("../webadmin/admin.aspx?n=" + DateTime.Now.Ticks);
                          
                           
                            
                            //Response.Redirect(,true);
                        }
                        else
                        {
                            sendDirect("../webadmin/admin.aspx?n=" + DateTime.Now.Ticks);
                        }
                    }
                }
                catch (Exception exception)
                {
                    _logger.Info("Error Load login ............." + exception.Message);
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                string str = Request["act"];
                if(string.IsNullOrEmpty(str))
                {
                    
                }
                else 
                {
                    Session.RemoveAll();
                    sendDirect("login.aspx?n=" + DateTime.Now.Ticks);
                }
            }
        }
        public void sendDirect(string url)
        {
            Response.Status = "301 Moved Permanently";
            Response.AddHeader("Location", url);
        }

        protected void pselect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
    }
}


