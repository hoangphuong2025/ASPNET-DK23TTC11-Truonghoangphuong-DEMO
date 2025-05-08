
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_portal.App_Data;
using web_controls;
using web_model;


namespace web_portal.webadmin
{
    public partial  class changepass : abcform
    {
        protected void btnChange_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (UsersInfo != null)
                {
                    UserController userController = new UserController();
                    string text = txtUsername.Text;
                    string pass = StringApp.CreatePasswordHash(txtOldpassword.Text);
                    IList<UsersInfo> list = userController.CheckByLoginId(text, pass);
                    if ((list == null) || (list.Count == 0))
                    {
                        lblErr.CssClass = "err";
                        lblErr.Text = "StringApp.MSGLOGIN";
                    }
                    else
                    {
                        UsersInfo usersInfo = list[0];
                        usersInfo.UserPass = StringApp.CreatePasswordHash(txtPass.Text);
                        userController.Update(usersInfo);
                        if(usersInfo.UserId>0)
                        {
                            lblErr.Text = "StringApp.MSGCHANGEPASSOK";
                            lblErr.CssClass = "msg_ok";
                            txtPass.TextMode = TextBoxMode.SingleLine;
                            txtPass.Text = "********";
                            txtPass.ReadOnly = true;
                            txtConfirm.TextMode = TextBoxMode.SingleLine;
                            txtConfirm.Text = "********";
                            txtConfirm.ReadOnly = true;
                            txtOldpassword.TextMode = TextBoxMode.SingleLine;
                            txtOldpassword.Text = "********";
                            btnChange.Visible = false;
                        }
                        else
                        {
                            lblErr.Text = "StringApp.MSGCHANGEPASSERROR";
                            lblErr.CssClass = "msg_error";
                        }
                    }
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
                    UserController userController = new UserController();
                    string str = Request["id"];
                    txtUsername.Text = UsersInfo.UserLogin;
                    if (string.IsNullOrEmpty(str))
                    {
                        UsersInfo list = userController.GetById(UsersInfo.UserId);
                        if (list != null)
                        {
                            txtUsername.Text = list.UserLogin;
                            txtUsername.ReadOnly = true;
                        }
                    }
                    
                }
            }
        }
    }
}
