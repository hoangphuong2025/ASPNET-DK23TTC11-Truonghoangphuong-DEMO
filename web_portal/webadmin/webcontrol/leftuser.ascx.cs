using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;

using web_controls;
using web_model;

namespace web_portal.webadmin.webcontrol
{
    public partial class leftuser : UserControl
    {
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        private string strHeight;
        private string dateString;

        public string DateString
        {
            get { return dateString; }
            set { dateString = value; }
        }
        private string stringUrl;

        public string StringUrl
        {
            get { return stringUrl; }
            set { stringUrl = value; }
        }

        public string StrHeight
        {
            get { return strHeight; }
            set { strHeight = value; }
        }

        private UsersInfo getSession()
        {
            Object obj = Session["ADMIN"];
            if (obj == null)
                return null;
            else return ((UsersInfo)obj);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsersInfo trunkinfo = getSession ();
            string lang ="vi";
            _logger.Info ("Lang ...:"+lang);
            if (trunkinfo == null)
            {
                _logger.Info ("Session==null");
                    
            }
            else
            {
                string s = Request.Url.PathAndQuery.ToString ();
                stringUrl = s.Replace ("/", "@@");
                stringUrl = stringUrl.Replace ("&", "$");
                string pindexs = Request ["pindex"];
               
                if (trunkinfo.UserId==trunkinfo.CodeUserId)
                {
               
                      ViewMenuRightController cs = new ViewMenuRightController();
                       IList<ViewMenuRightInfo> ilist = cs.GetAllUserId(trunkinfo.UserId);
                        if (ilist == null || ilist.Count == 0)
                        {
                            //insert data
                       
                            intMenuAdmin(trunkinfo.UserId);
                        }
                        else
                        {
                            
                        }

                        if (Session ["MENUMAIN"] == null)
                        {
                            MainMenuController csmenu = new MainMenuController();
                            List<MenuMainInfo> ilistmenu =csmenu.GetAll();
                            if (ilistmenu == null || ilistmenu.Count == 0)
                            {
                            }
                            else
                            {
                                ilistmenu = BubbleSort(ilistmenu);
                                pmain.DataSource = ilistmenu;
                                pmain.DataBind ();
                                Session ["MENUMAIN"] = ilistmenu;
                            }
                        }
                        else
                        {
                            _logger.Info ("da co session MENUMAIN");   
                            if (string.IsNullOrEmpty(pindexs))
                            {
                                _logger.Info ("ko tim thay");
                            }
                            else
                            {
                                initMenuMain (Convert.ToInt32 (pindexs), Convert.ToInt32 (Request ["pindex"]));
                            }

                            List<MenuMainInfo> ilistmenu = BubbleSort((List<MenuMainInfo>)Session ["MENUMAIN"]);
                            pmain.DataSource = ilistmenu;
                            pmain.DataBind ();
                            Session["MENUMAIN"] = ilistmenu;
                        }
                }
                else
                {
                    MainMenuController csmenu = new MainMenuController();
                    List<MenuMainInfo> ilistmenu =csmenu.GetAll();
                    if (ilistmenu == null || ilistmenu.Count == 0)
                    {
                    }
                    else
                    {
                        ilistmenu = BubbleSort(ilistmenu);
                        pmain.DataSource = ilistmenu;
                        pmain.DataBind();
                    }
                }
            }
        }

        private void intMenuAdmin(int userid)
        {
            SubMenuController menusub = new SubMenuController();
            IList<MenuSubInfo> ilistsub = menusub.GetAllByMcId(userid);
            if (ilistsub == null || ilistsub.Count == 0)
            {
                _logger.Info("khong co getAllUsersView");
            }
            else
            {
                MenuRightController menuRightController = new MenuRightController();
                int size = ilistsub.Count;
                for (int i = 0; i < size; i++)
                {
                    MenuSubInfo subinfo = ilistsub [i];
                    MenuRightInfo menuRightInfo = getParamRight(userid, subinfo.MainId, subinfo.SubId, subinfo.Indexs, subinfo.CompanyId);
                    menuRightController.Insert(ref menuRightInfo);
                }
            }
        }

        private MenuRightInfo getParamRight(int mcid, int mainid, int subid, int index,int companyid)
        {
            MenuRightInfo menuRightInfo = new MenuRightInfo();
            menuRightInfo.UserId =mcid;
            menuRightInfo.MainId =mainid;
            menuRightInfo.SubId = subid;
            menuRightInfo.Indexs = index;
            menuRightInfo.CompanyId = companyid;
            return menuRightInfo;
        }
        
        private void initMenuMain(int id,int currentid)
        {
            Object obj = Session["MENUMAIN"];
            if (obj == null)
            {

            }
            else
            {
                if (id == 1)
                {

                }
                else
                {
                    IList<MenuMainInfo> ilist = (IList<MenuMainInfo>) Session ["MENUMAIN"];
                    int size = ilist.Count;
                    for (int i = 0; i < size; i++)
                    {
                        MenuMainInfo info = ilist [i];
                        if (info.Indexs == id)
                        {
                           
                            MenuMainInfo swap = ilist [0];
                            swap.Indexs = info.Indexs;
                            info.Indexs = 1;
                            ilist [0] = info;
                            ilist [i] = swap;
                            Session ["MENUMAIN"] = ilist;
                            return;
                        }
                        else
                        {
                        }
                    }
                }
            }
        }
        protected void pmain_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
         
            UsersInfo trunkinfo = getSession();
            if (trunkinfo != null)
            {
           
                MenuMainInfo row = (MenuMainInfo)e.Item.DataItem;
                if (row == null)
                {
                }
                else
                {
                    if (row.StatusId <= 0)
                    {
                        Panel panel = (Panel)e.Item.FindControl("PANELOK");
                        if (panel !=null)
                        {
                            panel.Visible = false;
                        }
                    }
                    else
                    {


                        Repeater plistsub = (Repeater) e.Item.FindControl("psub");
                        if (plistsub == null)
                        {

                        }
                        else
                        {

                            if (trunkinfo.CodeUserId == trunkinfo.UserId)
                            {
                                IList<ViewMenuRightInfo> ilistsub = getSubMenu(trunkinfo.UserId, row.MainId,
                                                                               row.StatusId);
                                if (ilistsub == null || ilistsub.Count == 0)
                                {

                                }
                                else
                                {
                                    plistsub.DataSource = ilistsub;
                                    plistsub.DataBind();
                                }
                            }
                            else
                            {
                                IList<ViewMenuRightInfo> ilistsub = getSubMenuUserId(row.MainId, trunkinfo.UserId,
                                                                                     row.UserId);
                                if (ilistsub == null || ilistsub.Count == 0)
                                {
                                    Panel panel = (Panel) e.Item.FindControl("PANELOK");
                                    if (panel == null)
                                    {

                                    }
                                    else
                                    {
                                        panel.Visible = false;
                                    }

                                }
                                else
                                {
                                    
                                    plistsub.DataSource = ilistsub;
                                    plistsub.DataBind();
                                }
                            }
                        }
                    }
                }
            }
        }
        private IList<ViewMenuRightInfo> getALL(int userid)
        {
            Object obj = Session["ALLMAIN"];
            if (obj == null)
            {
                ViewMenuRightController cs = new ViewMenuRightController();
                IList<ViewMenuRightInfo> ilist = cs.GetAllUserId(userid);
                if (ilist == null || ilist.Count == 0)
                {
                    return null;
                }
                else
                {
                    _logger.Info("ALLMAIN here");
                    Session["ALLMAIN"] = ilist;
                    return ilist;
                }
            }
            else
            {
                return (List<ViewMenuRightInfo>)obj;
            }
            
        }
        public List<MenuMainInfo> BubbleSort(List<MenuMainInfo> a)
        {
            if (a != null && a.Count > 0)
            {
                int size = a.Count;
                MenuMainInfo tam = new MenuMainInfo();
                for (int i = 0; i < size - 1; i++)
                {
                    for (int j = size - 1; j > i; j--)
                    {
                        if (a[j].Indexs < a[j - 1].Indexs)
                        {

                            tam = a[j];
                            a[j] = a[j - 1];
                            a[j - 1] = tam;

                        }
                    }
                }

            }

            return a;
        }
        private IList<ViewMenuRightInfo> getSubMenu(int userid,int mainid,int statusid)
        {
            IList<ViewMenuRightInfo> vList = getALL(userid);
            if (vList == null || vList.Count == 0)
            {
               
                ViewMenuRightController cs = new ViewMenuRightController();
                IList<ViewMenuRightInfo> ilist = cs.GetAllMainId(mainid, statusid);
                if (ilist == null || ilist.Count == 0)
                {
                    return null;
                }
                else
                {
                    return ilist;
                }
            }
            else
            {
                 IList<ViewMenuRightInfo> viewMenuRight = new List<ViewMenuRightInfo>();
                int size = vList.Count;
                for (int i = 0; i < size; i++)
                {
                  
                    ViewMenuRightInfo viewMenuRightInfo = vList[i];
                    if (viewMenuRightInfo.MainId == mainid && viewMenuRightInfo.StatusId == statusid)
                    {
                        string url = viewMenuRightInfo.Url;
                 
                        if (string.IsNullOrEmpty(url))
                        {

                        }
                        else
                        {
                            if (url.IndexOf("?") >= 0)
                            {

                                if (url.IndexOf("?n=") >= 0)
                                {

                                }
                                else
                                {
                                    if (url.IndexOf("&n=") >= 0)
                                    {
                                        
                                    }
                                    else
                                    viewMenuRightInfo.Url = url + "&n=" + DateTime.Now.Ticks.ToString();
                                    
                                }

                            }
                            else
                            {

                                if (url.IndexOf("&n=") >= 0)
                                {

                                }
                                else
                                {
                                    viewMenuRightInfo.Url = url + "?n=" + DateTime.Now.Ticks.ToString();
                                }
                            }
                        }

                        viewMenuRight.Add(viewMenuRightInfo);
                    }
                }
                return viewMenuRight;
            }
        }
        private IList<ViewMenuRightInfo> getSubMenuUserId(int mainid,int statusid,int userid)
        {
            
            List<ViewMenuRightInfo> viewresult = new List<ViewMenuRightInfo>();
            IList<ViewMenuRightInfo> viewMenu = getALL(userid);
            if (viewMenu == null || viewMenu.Count == 0)
            {
                return null;
            }
            else
            {
                int size = viewMenu.Count;
                for (int i = 0; i < size; i++)
                {
                    ViewMenuRightInfo viewMenuRightInfo = viewMenu[i];
                    if (viewMenuRightInfo.MainId == mainid && viewMenuRightInfo.StatusId == statusid && viewMenuRightInfo.UserId == userid)
                    {
                        string url = viewMenuRightInfo.Url;
                        if (string.IsNullOrEmpty(url))
                        {

                        }
                        else
                        {
                            if (url.IndexOf("?") >= 0)
                            {
                                if (url.IndexOf("?n=") >= 0)
                                {

                                }
                                else
                                {
                                    viewMenuRightInfo.Url = viewMenuRightInfo.Url + "&n=" + DateTime.Now.Ticks.ToString();
                                }

                            }
                            else
                            {
                                if (url.IndexOf("&n=") >= 0)
                                {

                                }
                                else
                                {
                                    viewMenuRightInfo.Url = viewMenuRightInfo.Url + "?n=" + DateTime.Now.Ticks.ToString();
                                }
                            }


                        }

                        viewresult.Add(viewMenuRightInfo);
                    }
                }
            }
            return viewresult;
        }
    }
}