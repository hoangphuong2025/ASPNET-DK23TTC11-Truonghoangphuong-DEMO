
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using web_portal.App_Data;
using web_controls;
using web_model;
using web_util;


namespace web_portal.webadmin
{
    public partial class listusers : abcform
    {
    
        private string display;
        private string strHeight;
        public string Display
        {
            get { return display; }
            set { display = value; }
        }

        public string StrHeight
        {
            get { return strHeight; }
            set { strHeight = value; }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                Object ebjheight = Session["HEIGHTCURRENT"];
                if (ebjheight == null)
                {
                    StrHeight = "style=\"height:300px\"";
                }
                else
                {
                    try
                    {
                        int iheight = Convert.ToInt32(ebjheight.ToString());
                        StrHeight = "style=\"height:" + iheight/2 + "px\"";
                    }
                    catch 
                    {
                        StrHeight = "style=\"height:" + 300 + "px\"";
                    }

                }

                if (UsersInfo != null)
                {
                    string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
                    string act = Request ["act"];
                    if (string.IsNullOrEmpty(act))
                    {

                        UserController cscus = new UserController();
                        IList<UsersInfo> ilist = cscus.GetAll(UsersInfo.CompanyId);
                        if (ilist == null || ilist.Count == 0)
                        {
                        }
                        else
                        {
                            p_list.DataSource = ilist;
                            p_list.DataBind ();
                        }
                        //
                    }
                    else if (act.Equals ("view"))
                    {
                        
                        if (lang.Equals("vi"))
                            lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        else lblTitle.Text = StringApp.MSGUPDATEDANHMUC_VI;

                        pmcid.Text = "";
                        pchangepass.Visible = true;
                        PANNELCREATE.Visible = true;
                        PANNELLIST.Visible = false;
                        btnAdd.Text = StringApp.MSGUPDATEDANHMUC_VI;
                        showCombo(UsersInfo, StringApp.getConnetionString());

                        string customerid = Request["pid"];
                        if (string.IsNullOrEmpty(customerid))
                        {

                        }
                        else
                        {
                            UserController cscustomer = new UserController();
                            UsersInfo ilistinfo = cscustomer.GetById(Util.convertToInt(customerid));
                            if (ilistinfo == null )
                            {
                                Session.Remove ("ADMINUSER");
                            }
                            else
                            {
                                showData (ilistinfo);
                                showRightMenu();
                                Session ["ADMINUSER"] = ilistinfo;
                            }
                        }
                    }
                }
            }
        }
      
        private void showRightMenu()
        {
            MainMenuController csmenu = new MainMenuController();
            IList<MenuMainInfo> ilistmenu =
                csmenu.GetAllActive();
            if (ilistmenu == null || ilistmenu.Count == 0)
            {
            }
            else
            {
                plistmain.DataSource = ilistmenu;
                plistmain.DataBind();
            }
        }
        private void showCombo(UsersInfo trunkinfo,string connectionstr)
        {
            
                load_KindofBusiness(trunkinfo.CompanyId, p_kindofbusiness, connectionstr);
                load_UserStatus(trunkinfo.CompanyId, plist_status, connectionstr);
                if (trunkinfo.UserKindOfId == 0)
                {
                    load_UserKindof( plist_group, " WHERE Id>=0");
                }
                else
                {
                    load_UserKindof(plist_group, " WHERE Id>0");
                   
                }
            
           
        }
        // item hien thi danh sach cac user
        protected void p_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label panel = (Label) e.Item.FindControl ("pnamestatus");
                if (panel == null)
                {
                }
                else
                {
                    UsersInfo row = (UsersInfo) e.Item.DataItem;
                    if (row != null)
                    {
                        panel.Text = getStatusUserName(lang,row.UserStatusId,row.CompanyId);
                    }
                }
                Label pgroup = (Label) e.Item.FindControl ("pgroup");
                if (pgroup == null)
                {
                }
                else
                {
                    UsersInfo row = (UsersInfo) e.Item.DataItem;
                    if (row != null)
                    {
                        pgroup.Text = getNameKindofGroup(row.UserKindOfId);
                    }
                }
            }
        }
        private string getStatusUserName(string lang, int id, int companyid)
        {
            UserStatusController userStatus = new UserStatusController();
            UserStatusInfo userStatusInfo = userStatus.GetById(id);
            if (userStatusInfo == null)
            {
                return "undefined";
            }
            else
            {
                if (lang.Equals("vi"))
                {
                    return userStatusInfo.NameVi;
                }
                else return userStatusInfo.NameEn;
            }
        }
        private string  getNameKindofGroup(int id)
        {

            UserKindOfController cs = new UserKindOfController();
            UserKindOfInfo userKindOfInfo = cs.GetById(id);
            if (userKindOfInfo == null)
            {
                return "undefined";
            }
            else
            {
                return userKindOfInfo.NameVi;
            }
        }
        
        private void showData(UsersInfo ilistinfo)
        {
            if (ilistinfo != null)
            {
           
                pmcid.Text = ilistinfo.UserId.ToString ();
                p_name.Text = ilistinfo.Name;
                p_address.Text = ilistinfo.Address;
                p_tel.Text = ilistinfo.Tel;
                p_nickchat.Text = ilistinfo.NickChat;
                p_username.Text = ilistinfo.UserLogin;
                p_pass.TextMode = TextBoxMode.MultiLine;
                p_pass.Text = "**********";
                p_pass.ReadOnly = true;
                p_skyper.Text = ilistinfo.NickSkyper;
                StringApp.setSelectDropdown(plist_group,ilistinfo.UserKindOfId);
                StringApp.setSelectDropdown(p_kindofbusiness,ilistinfo.KindofBusinessId);
                StringApp.setSelectDropdown(plist_status, ilistinfo.UserStatusId);
                //show right
                
            }
        }

      
      
        private ArrayList getValuesCheck()
        {
            ArrayList vparam = new ArrayList();
            foreach (DataListItem dataItem in plistmain.Items)
             {
                 CheckBoxList checklist = (CheckBoxList)dataItem.FindControl("plistsub");
                 if(checklist==null)
                 {
                     
                 }
                 else
                 {
                     int size = checklist.Items.Count;
                     for (int i = 0; i < size; i++)
                     {
                         if (checklist.Items[i].Selected)
                         {
                             vparam.Add(checklist.Items[i].Value);
                         }
                     }
                 }
            
            }
            return vparam;
        }
        protected void btnAdd_ckick(object sender, EventArgs e)
        {
            //them moi 
            if (IsValid)
            {
                string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
               
                if (UsersInfo != null)
                {
                    Object obj = Session["ADMINUSER"];// user current
                    if (obj == null)
                    {
                        //tao moi
                        _logger.Info("tao moi .....");
                        UserController userController = new UserController();
                        IList<UsersInfo> ilistexist = userController.CheckByExistUser(p_username.Text);
                        if (ilistexist == null || ilistexist.Count == 0)
                        {
                            UsersInfo usersInfo = getParam(UsersInfo.CompanyId, UsersInfo.CodeUserId);
                            userController.Insert(ref usersInfo);
                            StringApp.setCssclass(lang, usersInfo.UserId, 0, p_label);
                            //cap nhat quyen cua user
                            insertRight(lang, UsersInfo, UsersInfo.UserId);
                        }
                        else
                        {
                            p_label.Text = StringApp.MSGUSERLOGINEXIST_VI;
                            p_label.CssClass = "msg_error";
                        }
                    }
                    else
                    {
                         _logger.Info ("cap nhat user da co.....");
                         UserController userController = new UserController();
                        //th ko cap nhat usernmw
                        UsersInfo usersInfo = userController.GetById(Util.convertToInt(Request["pid"]));
                        if (usersInfo != null)
                        {
                            usersInfo = getParamUpdate(usersInfo,1);
                            userController.Update(usersInfo);
                            StringApp.setCssclass(lang, usersInfo.UserId, 1, p_label);
                            updateRight(lang, usersInfo, ((UsersInfo)obj).UserId);
                        }
                    }
                }
            }
        }
      
        private int getMenuMainID(string lang,int subid)
        {
            SubMenuController cs = new SubMenuController();
            MenuSubInfo ilist = cs.GetById(subid);
            if (ilist == null)
            {
                return -1;
            }
            else return ilist.MainId;
      
        }
        private MenuRightInfo getParamRight(int mcid, int mainid, int subid, int index, int companyid)
        {
            MenuRightInfo vparam = new MenuRightInfo();
            vparam.UserId = mcid;
            vparam.MainId = mainid;
            vparam.SubId = subid;
            vparam.Indexs = index;
            vparam.CompanyId = companyid;
          
            return vparam;
        }
        
        private void insertRight()
        {
             ArrayList vlist =getValuesCheck ();
            int size = vlist.Count;
            for(int i=0;i<size;i++)
            {
                _logger.Info ("INSERT ITEM :"+vlist[i].ToString ());
            }
            
        }
        private void insertRight(string lang, UsersInfo trunkinfo, int userid)
        {
                ArrayList vlist = getValuesCheck ();
           
                MenuRightController csright = new MenuRightController();

                if (vlist == null || vlist.Count == 0)
                {
                    if (Session["ADMINUSER"]==null)
                        csright.deletebyMC(userid, Connectionstring);
                    else csright.deletebyMC(Convert.ToInt32(pmcid.Text), Connectionstring);
                }
                else
                {
                    csright.deletebyMC(Convert.ToInt32(pmcid.Text), StringApp.getConnetionString());

                    int size = vlist.Count;
                    for (int i = 0; i < size; i++)
                    {
                    
                        int subid = Convert.ToInt32 (vlist [i].ToString ());
                        int menumainid = getMenuMainID (lang, subid);
                        //check truoc khi insert
                        if (string.IsNullOrEmpty(pmcid.Text))
                        {
                            // truong hop tai moi khong can kiem tra
                            MenuRightInfo menuRightInfo = getParamRight(userid, menumainid, subid, i,
                                                                        trunkinfo.CompanyId);
                            csright.Insert(ref menuRightInfo);
                                
                        }
                        else
                        {
                            IList<MenuRightInfo> ilistcheck =
                                csright.getCheckInsert (Convert.ToInt32 (pmcid.Text), menumainid, subid,
                                                        StringApp.getConnetionString());
                            if (ilistcheck == null || ilistcheck.Count == 0)
                            {
                                MenuRightInfo menuRightInfo = getParamRight(Convert.ToInt32 (pmcid.Text), menumainid, subid, i,
                                                                     trunkinfo.CompanyId);
                                csright.Insert(ref menuRightInfo);
                            }
                            else
                            {

                            }
                        }
                    }
                }
        }
        private void updateRight(string lang, UsersInfo trunkinfo, int mcid)
        {
            ArrayList vlist = getValuesCheck();

            MenuRightController csright = new MenuRightController();
            if (vlist == null || vlist.Count == 0)
            {
                //csright.deletebyMC(mcid, connectionstr);
            }
            else
            {
                csright.deletebyMC(mcid,Connectionstring);
                int size = vlist.Count;
                for (int i = 0; i < size; i++)
                {
                 

                    int subid = Convert.ToInt32(vlist[i].ToString());
                    int menumainid = getMenuMainID(lang, subid);
                    //check truoc khi insert
                    IList<MenuRightInfo> ilistcheck = csright.getCheckInsert(Convert.ToInt32(pmcid.Text), menumainid, subid, Connectionstring);
                    if (ilistcheck == null || ilistcheck.Count == 0)
                    {
                        // _logger.Info("INSERT RIGHT ..................");
                        MenuRightInfo menuRightInfo = getParamRight(Convert.ToInt32(pmcid.Text), menumainid, subid, i,
                                                                    trunkinfo.CompanyId);
                         csright.Insert(ref menuRightInfo);
                    }
                    else
                    {

                    }
                }
            }
        }
       
        private UsersInfo getParam(int companyid,int rootcode)
        {
            UsersInfo vparam = new UsersInfo();
            vparam.Name = p_name.Text;
            vparam.UserLogin = p_username.Text;
            vparam.UserPass = Util.CreatePasswordHash(p_pass.Text);
            vparam.UserKindOfId =Util.convertToInt(plist_group.SelectedValue);
            vparam.UserStatusId = Util.convertToInt(plist_status.SelectedValue);
            vparam.Address = p_address.Text;
            vparam.Edate = DateTime.Now;
            vparam.Mdate = DateTime.Now;
            vparam.NickChat = p_nickchat.Text;
            vparam.Tel = p_tel.Text;
            vparam.KindofBusinessId = Util.convertToInt(p_kindofbusiness.SelectedValue);
            vparam.Confirms = p_pass.Text;
            vparam.CodeUserId = rootcode;//Confirms
            vparam.Picture = "";
            vparam.CompanyId = companyid;
            vparam.NickSkyper = p_skyper.Text;
            return vparam;
        }
        private UsersInfo getParamUpdate(UsersInfo vparam, int coderoot)
        {
            vparam.Name = p_name.Text;
            vparam.UserKindOfId = Util.convertToInt(plist_group.SelectedValue);
            vparam.UserStatusId = Util.convertToInt(plist_status.SelectedValue);
            vparam.Address = p_address.Text;
            vparam.Edate = DateTime.Now;
            vparam.Mdate = DateTime.Now;
            vparam.NickChat = p_nickchat.Text;
            vparam.Tel = p_tel.Text;
            vparam.KindofBusinessId = Util.convertToInt(p_kindofbusiness.SelectedValue);
            vparam.CodeUserId = coderoot;//Confirms
            vparam.Picture = "";
            vparam.NickSkyper = p_skyper.Text;
            return vparam;
            //ArrayList vparam = new ArrayList();
            //vparam.Add(userid);//0
            //vparam.Add(p_name.Text); //1
            //vparam.Add(p_username.Text);//2
            //if (coderoot.Equals(userid.ToString()))
            //{
            //    vparam.Add("-1"); //nhom 3
            //    vparam.Add(1);//address 4
            //}
            //else
            //{
            //    vparam.Add(plist_group.SelectedValue); //nhom 3
            //    vparam.Add(plist_status.SelectedValue);//address 4
            //}
          
            //vparam.Add(DateTime.Now);//tel 5
            //vparam.Add(p_nickchat.Text);//EmployeeStatusID 6
            //vparam.Add(p_tel.Text);//kindofbusiness 7
            //vparam.Add(p_address.Text);//8
            //vparam.Add(p_kindofbusiness.SelectedValue); //9
            //vparam.Add(p_username.Text);//Confirms
            //vparam.Add(companyid);//companyid
            //vparam.Add("");//picture
            //vparam.Add(p_skyper.Text);//p_skyper
            //return vparam;
        }
        protected void btnAddList_Click(object sender, EventArgs e)
        {
            pmcid.Text = "";
            PANNELCREATE.Visible = true;
            PANNELLIST.Visible = false;
            lblTitle.Text = StringApp.MSGLISTDANHMUC_VI;
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());

            if (UsersInfo != null)
            {
                showCombo(UsersInfo, Connectionstring);
                MainMenuController csmenu = new MainMenuController();
                IList<MenuMainInfo> ilistmenu = csmenu.GetAll();
                if (ilistmenu == null || ilistmenu.Count == 0)
                {

                }
                else
                {
                    plistmain.DataSource = ilistmenu;
                    plistmain.DataBind();
                }
                Object obj = Session["ADMINUSER"];
                if(obj!=null)
                    Session.Remove("ADMINUSER");
              
            }
            Display = "none";
            
        }
        protected void pchangepass_Click(object sender, EventArgs e)
        {
            if (UsersInfo!= null)
            {
                sendDirect("changepass.aspx?n=" + DateTime.Now.Ticks + "&id=" +UsersInfo.UserId);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (UsersInfo != null)
            {
         
                string[] vparam = Request.Params.GetValues ("checkbtn");
                if (vparam == null || vparam.Length == 0)
                {
                }
                else
                {
                    string result = "(";
                    for (int i = 0; i < vparam.Length; i++)
                    {
                        result += vparam [i].Trim () + ",";
                    }
                    result = result.Substring (0, result.Length - 1);
                    result += ")";

                    try
                    {
                        UserController cs = new UserController();
                        cs.Delete(result);

                    }
                    catch (Exception ex)
                    {
                        _logger.Info("Buton delete error" + ex.Message);
                    }
                }
                // xu ly lai
                //
                PANNELCREATE.Visible = false;
                PANNELLIST.Visible = true;
                UserController cscus = new UserController();
                IList<UsersInfo> ilist = cscus.GetAll(UsersInfo.CompanyId);
                if (ilist == null || ilist.Count == 0)
                {
                }
                else
                {
                    p_list.DataSource = ilist;
                    p_list.DataBind ();
                }
            }
        }
        
       
        private IList<MenuSubInfo> getSubMenu(int mainid, int mcid)
        {
            SubMenuController cs = new SubMenuController();
            IList<MenuSubInfo> ilist = cs.GetAllByMainIdAndUserId(mainid, mcid);
            if (ilist == null || ilist.Count == 0)
            {
                return null;
            }
            else
            {
                return ilist;
            }
        }
        protected void plistmain_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            UsersInfo trunkinfo = getSession();
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            if (trunkinfo == null)
            {
            }
            else
            {
                MenuMainInfo row = (MenuMainInfo)e.Item.DataItem;
                if (row == null)
                {
                }
                else
                {
                    CheckBoxList plistsub = (CheckBoxList)e.Item.FindControl("plistsub");
                    if (plistsub == null)
                    {

                    }
                    else
                    {
                        IList<MenuSubInfo> ilistsub = getSubMenu(row.MainId, trunkinfo.UserId);
                        if (ilistsub == null || ilistsub.Count == 0)
                        {
                        }
                        else
                        {
                            plistsub.DataSource = ilistsub;
                            plistsub.DataTextField = "NameVi";
                            plistsub.DataValueField = "subId";
                            plistsub.DataBind();
                            //set value
                           
                            if (string.IsNullOrEmpty(pmcid.Text))
                            {
                            }
                            else
                            {
                                _logger.Info("pmcid.Text :" + pmcid.Text);
                                showright(row.MainId, Convert.ToInt32(pmcid.Text), row.Indexs, row.CompanyId,plistsub);
                            }
                        }



                    }
                }
            }
        }
        protected void plistsub_TextChanged(object sender, EventArgs e)
        {
            CheckBoxList tb1 = ((CheckBoxList)(sender));
            DataListItem datalist = ((DataListItem)(tb1.NamingContainer));
            CheckBoxList checklist = (CheckBoxList)datalist.FindControl("plistsub");
            if (checklist == null)
            {

            }
            else
            {
                ArrayList vget =Util.getValuesCheck(checklist);
                if (vget == null || vget.Count == 0)
                {

                }
                else
                {
                    if (Session["VGET"] == null)
                    {
                        Session["VGET"] = vget;
                    }
                    else
                    {
                        ArrayList vlist = (ArrayList)Session["VGET"];
                        int size = vget.Count;
                        for (int i = 0; i < size; i++)
                        {
                            if (vlist.IndexOf(vget[i].ToString()) >= 0)
                            {
                            }
                            else
                            {
                                vlist.Add(vget[i].ToString());
                            }
                        }
                        Session["VGET"] = vlist;
                    }
                }
            }
        }
        private void showright(int mainid, int mcid,int mainindex,int companyid, CheckBoxList plistcheck)
        {
            ArrayList vget = new ArrayList ();
            string lang = Util.getLang(Request.Url.PathAndQuery.ToString());
            MenuRightController cs = new MenuRightController();
            IList<MenuRightInfo> ilist = cs.GetAllByMainIdAndUserId(mainid, mcid);
            if (ilist == null || ilist.Count == 0)
            {
                Session["VGET"] = null;
            }
            else
            {
                if (plistcheck == null)
                {

                }
                else
                {
                    for (int i = 0; i < ilist.Count; i++)
                    {
                        int id = ilist [i].SubId;
                      
                        try
                        {
                            plistcheck.Items.FindByValue (id.ToString ()).Selected = true;
                        }
                        catch(Exception ex)
                        {
                            continue;
                        }
                        vget.Add (id);
                    }
                }
                if (Session["VGET"] == null)
                {
                    Session["VGET"] = vget;
                }
                else
                {
                    ArrayList v = (ArrayList) Session ["VGET"];
                    int initsize = vget.Count;
                    for(int i=0;i<initsize;i++)
                    {
                        string ii = vget [i].ToString ();
                        if (v.IndexOf(ii) >= 0)
                        {

                        }
                        else
                        {
                            v.Add (vget [i]);
                        }
                    }
                    Session ["VGET"] = v;
                }
                
            }

        }
        //Util.setCombo (plist_status, "Name_vi", "ID",
        //                           SqlHelper.getDataset ("select ID,Name_vi from tb_User_status WHERE companyid="+trunkinfo.CompanyID,
        //                                                 StringApp.DATABASELOCAL));
        //            Util.setCombo (p_kindofbusiness, "Name_vi", "ID",
        //                           SqlHelper.getDataset ("select ID,Name_vi from tb_KindofBusiness WHERE companyid="+trunkinfo.CompanyID,
        //                                                 StringApp.DATABASELOCAL));
        private void load_UserStatus(int companyid, DropDownList dropdownlist,string connectionstr)
        {
            UserStatusController userStatus =new UserStatusController();
            IList<UserStatusInfo> list = userStatus.GetAll();
            if (list == null || list.Count == 0)
            {
                IList<UserStatusInfo> ilistnect = new List<UserStatusInfo>();
                UserStatusInfo item = new UserStatusInfo();
                item.Id = -1;
                item.NameVi = "Select  Item";
                ilistnect.Add(item);
                dropdownlist.DataSource = ilistnect;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
            else
            {
                UserStatusInfo item = new UserStatusInfo();
                item.Id = -1;
                item.NameVi = "Select  Item";
                list.Add(item);
                dropdownlist.DataSource = list;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
        }
        private void load_UserKindof(DropDownList dropdownlist,string condition)
        {
            UserKindOfController userKindOfController = new UserKindOfController();
            IList<UserKindOfInfo> list = userKindOfController.GetSearch(condition);
            if (list == null || list.Count == 0)
            {
                IList<UserKindOfInfo> ilistnect = new List<UserKindOfInfo>();
                UserKindOfInfo item = new UserKindOfInfo();
                item.Id = -1;
                item.NameVi = "Select Item";
                ilistnect.Add(item);
                dropdownlist.DataSource = ilistnect;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
            else
            {
                
                UserKindOfInfo item = new UserKindOfInfo();
                item.Id = -1;
                item.NameVi = "Select Item";
                list.Add(item);
                dropdownlist.DataSource = list;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
        }
        private void load_KindofBusiness(int companyid, DropDownList dropdownlist, string connectionstr)
        {
            KindOfBusinessController kindOfBusiness=new KindOfBusinessController();
            IList<KindOfBusinessInfo> list = kindOfBusiness.GetAll();
            if (list == null || list.Count == 0)
            {
                IList<KindOfBusinessInfo> ilistnect = new List<KindOfBusinessInfo>();
                KindOfBusinessInfo item = new KindOfBusinessInfo();
                item.Id = -1;
                item.NameVi = StringApp.STRING_SELECT;
                ilistnect.Add(item);
                dropdownlist.DataSource = ilistnect;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
            else
            {
                KindOfBusinessInfo item = new KindOfBusinessInfo();
                item.Id = -1;
                item.NameVi = StringApp.STRING_SELECT;
                list.Add(item);
                dropdownlist.DataSource = list;
                dropdownlist.DataTextField = "NameVi";
                dropdownlist.DataValueField = "Id";
                dropdownlist.DataBind();
            }
        }
       
    }
}
