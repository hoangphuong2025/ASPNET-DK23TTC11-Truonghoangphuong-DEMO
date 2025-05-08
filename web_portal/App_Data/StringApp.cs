using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using NLog;
using web_controls;
using web_model;
using web_util;


namespace web_portal.App_Data
{
   

    public class StringApp
    {
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        public static string BACKUPFILENAME = ConfigurationManager.AppSettings["BACKUPFILENAME"].ToString();
        public static string BACKUPFILENAMEERROR = "Lưu trữ database bị  lỗi";
        public static string BACKUPFILENAMEOK = "Lưu trữ database h\x00f2an tất";
        public static string BACKUPFOLDERSERVERNAME = ConfigurationManager.AppSettings["FOLDERDATABASE"].ToString();
        public static string BACKUPSERVERNAME = ConfigurationManager.AppSettings["BACKUPSERVERNAME"].ToString();
        public static string BAOCAOPHIEUNHAP = "Inventory from {0} to {1}";
        public static string BAOCAOPHIEUNHAPTAOBOI = "Tạo bởi :{0}";
        public static string BAOCAOPHIEUXUAT = "Inventory from {0} to {1}";
        public static string BAOCAOPHIEUXUATTAOBOI = "Tạo bởi :{0}";
        public static string BUOICHIEU = "Buổi chiều - Evening";
        public static string BUOISANG = "Buổi s\x00e1ng - Morning";
        public static string BUOITRUA = "Buổi trưa -AfterMoon";
        public static string CUSTOMERINFO = "Th\x00f4ng tin t\x00e0i khỏan kh\x00e1ch h\x00e0ng";
        public static string CUSTOMERINFO_EN = "Customer Account Information";
        public static string CUSTOMERINFOUPDATE = "Đồng \x00fd thay đổi";
        public static string CUSTOMERINFOUPDATE_EN = "Agreed to change";
        public static string DATABASELOCAL = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        //public static string DATABASELOCAL = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        //public static string DATABASELOCAL = "Database=web_9hd;Server=112.78.3.66;Uid=db_9hdvn;Pwd=duongnoithatX;pooling=false;";
        //public static string DATABASELOCAL = "Database=phuonganhmobile_com_webdbhuong;Server=112.213.89.80\\sql2008,1433;Uid=tranhuongkd;Pwd=quan!@#$%^&*;pooling=false;";
        
        public static string DISPLAY = "<span>Tổng số {2},&nbsp;item {0}-{1}</span>";
      
        public static string EMAILTITLEPASSWORDNEW = "Mật khẩu mới";
        public static string EMAILTONGSO = "Tổng tiền";
        public static string EMAILTONGSOSHIPPING = "Tiền vận chuyển";
        public static string EMAILTONGSOPAY = "Tổng thanh toán";
        public static string EMAILTONGSO_EN = "Total";
        public static string EMAILWELLCOME = "<b>Th\x00f4ng tin đơn h\x00e0ng m\x00e0 qu\x00fd kh\x00e1ch đ\x00e3 đặt  mua </b> ";
        public static string FEEDBACKDETAIL = "Th\x00f4ng tin y\x00eau cầu của kh\x00e1ch h\x00e0ng(Contact Info)";
        public static string FEEDBACKSTATUSNAMECHUADOC = "chưa  đọc";
        public static string FEEDBACKSTATUSNAMEDOC = "đ\x00e3 đọc ";
        public static string FINDNOTFOUND = "Item not found";
        public static string FINDNOTFOUND_vi = "kh\x00f4ng t\x00ecm thấy dữ liệu";
        public static string ITEMNOTFOUND = "kh\x00f4ng t\x00ecm thấy";
        public static string LOGINERROR = "Lỗi khi tạo th\x00f4ng tin kh\x00e1ch h\x00e0ng";
        public static string LOGINOK = "Th\x00f4ng tin đ\x00e3 được tạo";
        public static string LOGINYOURCARTERROR = "T\x00ean truy cập hay mật khẩu kh\x00f4ng tồn tại";
        public static string LOGINYOURCARTERROREN = "Username or password does not exist";
        public static string MSGALL = "To\x00e0n bộ";
        public static string MSGBUTTONCREATE = " Add new";
        public static string MSGBUTTONCREATE_VI = "Tạo mới ";
        public static string MSGBUTTONUPDATE = "Update";
        public static string MSGBUTTONUPDATE_VI = "Cập nhật";
        public static string MSGCARRTNOTICE = "Vui l\x00f2ng nhập địa chỉ giao h\x00e0ng v\x00e0 t\x00ean truy cập";
        public static string MSGCARRTNOTICE_EN = "Please enter the delivery address and your username and password";
        public static string MSGCATEGORYROOT = "Danh mục gốc";
        public static string MSGCHANGEPASSERROR = " Mật khẩu đ\x00e3 kh\x00f4ng thay đổi được";
        public static string MSGCHANGEPASSOK = " Mật khẩu đ\x00e3 được thay đổi th\x00e0nh c\x00f4ng";
        public static string MSGCOMPANYCREATE = "Tạo mới th\x00f4ng tin";
        public static string MSGCONTACTUSEN = "Contact US";
        public static string MSGCONTACTUSVI = "Li\x00ean lạc với ch\x00fang t\x00f4i";
        public static string MSGCREATE = "Create";
        public static string MSGCREATE_VI = " Tạo mới";
        public static string MSGCREATEDANHMUC = "Create Category";
        public static string MSGCREATEDANHMUC_PROMOTION = "Create Promotion";
        public static string MSGCREATEDANHMUC_PROMOTION_VI = "Tạo mới danh mục khuyến m\x00e3i ";
        public static string MSGCREATEDANHMUC_VI = "Tạo mới danh mục ";
        public static string MSGCREATEDANHMUCDRIVER = "Tạo mới Driver";
        public static string MSGCREATEERROR = "Create Error";
        public static string MSGCREATEERROR_VI = "Tạo mới bị lỗi ";
        public static string MSGCREATEINFOCDRIVER = "Th\x00f4ng tin driver";
        public static string MSGCREATEOK = " Create Ok";
        public static string MSGCREATEOK_VI = "Tạo mới th\x00e0nh c\x00f4ng";
        public static string MSGCREATESTORE = "Create";
        public static string MSGCREATESTORE_VI = "Nhập danh mục";

        public static string MSGDELETEORROR = "X\x00f3a bị lỗi";
        public static string MSGEMAILFORGOT = "Qu\x00ean mật khẩu";
        public static string MSGFAQERROR = " C\x00e2u hỏi của bạn đ\x00e3 được gởi th\x00e0nh c\x00f4ng";
        public static string MSGFAQOK = " C\x00e2u hỏi của bạn đ\x00e3 được gởi th\x00e0nh c\x00f4ng";
        public static string MSGFASTnhattrungvietCREATE = "New Product Information  ";
        public static string MSGFASTnhattrungvietORDERCREATEERROR = "Tạo Order lỗi - Bill Order Error  ";
        public static string MSGFASTnhattrungvietORDERCREATEERROR_EN = " Bill Order Error  ";
        public static string MSGFASTnhattrungvietORDERCREATEOK = "Tạo Order OK";
        public static string MSGFASTnhattrungvietORDERCREATEOK_EN = "Bill Order OK  ";
        public static string MSGFASTnhattrungvietUPDATE = "Update ";
        public static string MSGFASTnhattrungvietUPDATE_VI = "Cập nhật";
        public static string MSGFEEDBACKERROR = "Yêu cầu của quí khách chưa được gởi đến chúng tôi, xin vui lòng kiểm tra lại";
        public static string MSGFEEDBACKERROR_EN = "Yêu cầu của quí khách chưa được gởi đến chúng tôi, xin vui lòng kiểm tra lại";

        public static string MSGFEEDBACKNOTREAD = "Chưa đọc(unread)";
        public static string MSGFEEDBACKOK = "Your request has been sent to us, thank you";
        public static string MSGFEEDBACKOK_EN = "Yêu cầu của quí khách đã được gởi đến chúng tôi, xin cám ơn";

        public static string MSGFEEDBACKREAD = "Đ\x00e3 xem(read)";
        public static string MSGHOMETITLE = "The ky laptop";
        public static string MSGINTRO = "vui l\x00f2ng tạo th\x00f4ng tin c\x00f4ng ty trước khi tạo th\x00f4ng tin giới thiệu";
        public static string[] MSGINTROLEFT = new string[] { "Intro Left", "Tuyển dụng", "Chương tr\x00ecnh khuyến m\x00e3i", "Sơ đồ website", "Trợ gi\x00fap theo y\x00eau cầu", "Phương thức thanh t\x00f3an", "Hướng dẫn mua h\x00e0ng", "Qui định sử dụng", "Bảo mật th\x00f4ng tin", "F.A.Q", "Privacy policy", "Chương tr\x00ecnh đại l\x00fd", "G\x00f3c b\x00e1o ch\x00ed" };
        public static string MSGLIST = "List ";
        public static string MSGLIST_VI = "Danh s\x00e1ch";
        public static string MSGLISTBOSUUTAP_VI = "Danh s\x00e1ch bộ sưu tập";
        
        public static string MSGLISTDANHMUC_VI = "Danh s\x00e1ch danh mục ";
        public static string MSGLISTDANHMUC_EN = "List Item ";
        public static string MSGLISTDANHMUCCUSTOMER = "Danh S\x00e1ch kh\x00e1ch h\x00e0ng";
        public static string MSGLISTDANHMUCCUSTOMERCREATE = "Tạo mới th\x00f4ng tin";
        public static string MSGLISTDANHMUCCUSTOMERUPDATE = "Cập nhật th\x00f4ng tin ";
        public static string MSGLISTDANHMUCDRIVER = "Danh s\x00e1ch danh mục Driver";
        public static string MSGLISTDANHMUCEMPLOYEE = "Danh s\x00e1ch Users";
        public static string MSGLISTDANHMUCEMPLOYEECREATE = "Tạo mới th\x00f4ng tin nh\x00e2n vi\x00ean";
        public static string MSGLISTDANHMUCEMPLOYEEUPDATE = "Cập nhật ";
        public static string MSGLISTDANHMUCUSERSCREATE = "Tạo mới th\x00f4ng tin";
        public static string MSGLISTDANHMUCUSERSUPDATE = "Cập nhật th\x00f4ng tin";
        public static string MSGLISTDANHMUCUSERSUPDATTE = "Th\x00f4ng tin đơn h\x00e0ng";
        public static string MSGLISTSTORE = "List store";
        public static string MSGLISTSTORE_VI = "Danh s\x00e1ch kho";
        public static string MSGLISTUSERINFO = "Th\x00f4ng tin nh\x00e2n vi\x00ean";
        public static string MSGLISTUSERINFO_EN = "User Info";
        public static string MSGLOGIN = " Mật khẩu kh\x00f4ng hợp lệ";
        public static string MSGnhattrungvietCREATE = "Tạo mới th\x00f4ng tin thức ăn - nhattrungviet Info  ";
        public static string MSGnhattrungvietREGISTERCREATE = "Đăng k\x00fd thức ăn - Customer Register nhattrungviet Info  ";
        public static string MSGnhattrungvietREGISTERUPDATE = "Cập nhật đăng k\x00fd thức ăn - Customer Register nhattrungviet Info  ";
        public static string MSGnhattrungvietUPDATE = "Cập nhật th\x00f4ng tin thức ăn - nhattrungviet Info  ";
        public static string MSGORDERINFO = "Thông tin đơn hàng của bạn đã được gởi cho chúng tôi";
        public static string MSGORDERINFOERROR = "Y\x00eau cầu của bạn chưa được gởi tới chung t\x00f4i !!!";
        public static string MSGORDERINFOHISTORY = "Lịch sử mua h\x00e0ng";
        public static string MSGPHIEUXUATCREATEOK = "Tạo phiếu xuất th\x00e0nh c\x00f4ng";
        public static string MSGPHIEUXUATCREATEORROR = "Kh\x00f4ng tạo đựoc phiếu xuất";
        public static string MSGREGISTER = "Đăng k\x00fd th\x00e0nh vi\x00ean";
        public static string MSGREGISTEROK = "Đăng k\x00fd th\x00e0nh vi\x00ean h\x00f2an tất";
        public static string MSGREGISTERORROR = "Chưa đăng k\x00fd th\x00e0nh vi\x00ean được";
        public static string MSGSEARCH = "kết  quả t\x00ecm kiếm";
        public static string MSGSEARCH_EN = "Search Result";
        public static string MSGSELECTITEM = "chọn mục cần x\x00f3a";
        public static string MSGTITLEINPUTSTORE_EN = "Input store bill";
        public static string MSGTITLEINPUTSTORE_VI = "Th\x00f4ng tin phiếu nhập";
        public static string MSGTITLELISTINPUTSTORE_EN = "List input bill";
        public static string MSGTITLELISTINPUTSTORE_VI = "Danh s\x00e1ch phiếu nhập";
        public static string MSGTITLELISTINPUTSTOREUPDATE_EN = "Update info";
        public static string MSGTITLELISTINPUTSTOREUPDATE_VI = "Cập nhật th\x00f4ng tin";
        public static string MSGTITLENEWS = " Tin Tức";
        public static string MSGUPDATE = " Cập nhật";
        public static string MSGUPDATE_EN = " Update";
        public static string MSGUPDATEDANHMUC = "Update Category";
        public static string MSGUPDATEDANHMUC_PROMOTION = "Update Promotion";
        public static string MSGUPDATEDANHMUC_PROMOTION_VI = "Cập nhật danh mục khuyến m\x00e3i ";
        public static string MSGUPDATEDANHMUC_VI = "Cập nhật ";
        public static string MSGUPDATEDANHMUC_EN = "Update Item";
        public static string MSGUPDATEERROR = "Update Error";
        public static string MSGUPDATEERROR_VI = "Cập nhật lỗi";
        public static string MSGUPDATEINPUTSTORE = "";
        public static string MSGUPDATEINPUTSTORE_ERROR_EN = "Input store is Error";
        public static string MSGUPDATEINPUTSTORE_ERROR_VI = "Nhập kho chưa h\x00f2an tất";
        public static string MSGUPDATEINPUTSTORE_OK_EN = "Input store is completed";
        public static string MSGUPDATEINPUTSTORE_OK_VI = "Nhập kho ho\x00e0n tất";
        public static string MSGUPDATELISTOUTPUTSTORE_EN = "List output";
        public static string MSGUPDATELISTOUTPUTSTORE_VI = "Danh s\x00e1ch phiếu xuất";
        public static string MSGUPDATEOK = "Update Ok";
        public static string MSGUPDATEOK_VI = "Cập nhật th\x00e0nh c\x00f4ng";
        public static string MSGUPDATEOUTPUTSTORE_EN = "Output store bill";
        public static string MSGUPDATEOUTPUTSTORE_ERROR_EN = "Out store is Error";
        public static string MSGUPDATEOUTPUTSTORE_ERROR_VI = "Xuất kho chưa h\x00f2an tất";
        public static string MSGUPDATEOUTPUTSTORE_OK_EN = "Out put store is completed";
        public static string MSGUPDATEOUTPUTSTORE_OK_VI = "Xuất kho ho\x00e0n tất";
        public static string MSGUPDATEOUTPUTSTORE_VI = "Th\x00f4ng tin phiếu xuất";
        public static string MSGUPDATESTORE = "Update";
        public static string MSGUPDATESTORE_VI = "Cập nhật";
        public static string MSGUPLOADFILE = "kh\x00f4ng thể upload file được,k\x00edch thước file phải nhỏ hơn<4MB";
        public static string MSGUPLOADFILEEXIST = "File đ\x00e3 c\x00f3 trong hệ thống";
        public static string MSGVANBANGIUEMAUCOUNT = "C\x00f3 {0} văn bản & biểu mẩu";
        public static string MSGWELCOME = "Ch\x00e0o kh\x00e1ch h\x00e0ng";
        public static string MSGWELCOME_EN = "Welcome to Customer";
        public static string NEWSEN = "News";
        public static string NEWSVI = "Tin tức";
        public static string PAGE = "<span>Trang:&nbsp;</span>&nbsp;&nbsp;";
        public static string PAGEFIRST = "&nbsp;đầu ti\x00ean";
        public static string PAGELAST = "sau";
        public static string PAGENEXT = "<span style=\"padding-left:2px;\"> \x00bb </span>";
        public static string PAGEPRE = " \x00ab ";
        public static string PASSWORDNOTCONFIRM = "X\x00e1c nhận mật khẩu kh\x00f4ng đ\x00fang";
        public static string PASSWORDNOTNULL = "Nhập mật khẩu";
        public static string SIZEPAGE = ConfigurationManager.AppSettings["PAGESIZE"].ToString();
        public static string SIZEPAGEWEB = ConfigurationManager.AppSettings["PAGESIZEWEB"].ToString();
        public static string STRINGCAPCHARERROR = "M\x00e3 code kh\x00f4ng đ\x00fang";
        public static string TITLECHITIETDONHANG = "Infomation";
        public static string TITLEFOUNDATION = "Nội dung giới thiệu trang chủ(Description Earthquake Foundation)";
        public static string TITLEFUEL = "Nội dung giới thiệu trang chủ(Fuel Breakthrough)";
        public static string TITLEHOME = "Cafe";
        public static string TITLEHOME_CHI = "";
        public static string TITLEHOME_EN = "Cafe";
        public static string STRING_SELECT = "Chọn danh mục";
        public static string STRING_ALLSELECT = "Chọn toàn bộ";
        public static string TITLEPRODUCTS = "Nội dung giới thiệu trang chủ(Technology & Products)";
        public static string MSGUSERLOGINEXIST_VI = "Tên truy cập đã có";
        public static string TOP = ConfigurationManager.AppSettings["TOP"].ToString();
        private static string[] Unicode_charss = new string[] { 
            "Đ", "đ", "Ĩ", "ĩ", "Ị", "ị", "Ỉ", "ỉ", "Ỵ", "ỵ", "\x00c6", "\x00e6", "ỹ", "Ỹ", "ỷ", "Ỷ", 
            "ỳ", "Ỳ", "ự", "Ự", "ữ", "Ữ", "ử", "Ử", "ừ", "Ừ", "ứ", "Ứ", "ủ", "Ủ", "ụ", "Ụ", 
            "ợ", "Ợ", "ỡ", "Ỡ", "ở", "Ở", "ờ", "Ờ", "ớ", "Ớ", "ộ", "Ộ", "ỗ", "Ỗ", "ổ", "Ổ", 
            "ồ", "Ồ", "ố", "Ố", "ỏ", "Ỏ", "ọ", "Ọ", "ệ", "Ệ", "ễ", "Ễ", "ể", "Ể", "ề", "Ề", 
            "ế", "Ế", "ẽ", "Ẽ", "ẻ", "Ẻ", "ẹ", "Ẹ", "ặ", "Ặ", "ẵ", "Ẵ", "ẳ", "Ẳ", "ằ", "Ằ", 
            "ắ", "Ắ", "ậ", "Ậ", "ẫ", "Ẫ", "ẩ", "Ẩ", "ầ", "Ầ", "ấ", "Ấ", "ả", "Ả", "ạ", "Ạ", 
            "ũ", "Ũ", "ă", "Ă", "\x00fd", "\x00fa", "\x00f9", "\x00f5", "\x00f3", "\x00f2", "\x00ea", "\x00e9", "\x00e8", "\x00e3", "\x00e2", "\x00e1", 
            "\x00e0", "\x00dd", "\x00da", "\x00d9", "\x00d5", "\x00d3", "\x00d2", "\x00ca", "\x00c9", "\x00c8", "\x00c3", "\x00c2", "\x00c1", "\x00c0", "Ơ", "ơ", 
            "Ư", "ư", "\x00d4", "\x00f4"
         };
        public static string USERLOGINEXIST = "T\x00ean truy cập đ\x00e3 tồn tại";
        public static string YOURCARTEMPLTY = "<strong>Giỏ h\x00e0ng chưa c\x00f3 !</strong>";
        public static string GOMSU = "Gốm sứ";
        public static string THIETBINHAHANGKHACHSAN= "THIẾT Bị nhà hàng khách sạn";
        public static string MICA = "Mica";
        public static string NEWS = "Tin tức";
        public static string JOB = "Tuyển dụng";
        public static string CUSTOMERSERVICE = "DỊCH VỤ KHÁCH HÀNG";
        public static string EMAILEMAIL = "Email";
        public static string EMAILNOIDUNG = "Nội dung";
        //1 : thoe thu tu tang dan ,giam dan , theo ten giam dan ,theo ten tang dan
        private static string[] str = new string[] { "", "ORDER BY Indexs ASC", "ORDER BY Indexs DESC", "ORDER BY Name_vi ASC", "ORDER BY Name_vi DESC", "ORDER BY CategoryID ASC", "ORDER BY CategoryID DESC", "ORDER BY SubCategoryID ASC,Indexs ASC", "ORDER BY SubCategoryID DESC,Indexs DESC" };
        ////public static string  getOrderby(int iproductgroup,int categoryid,int subcategoryid,int icompanyid, string connectiostr)

        ////{
        ////    CS_ConfigProductGroup cs = new CS_ConfigProductGroup();
        ////    IList<ConfigProductGroupInfo> ilist = cs.getInfo(icompanyid, iproductgroup,categoryid,subcategoryid,connectiostr);
        ////    if (ilist == null || ilist.Count == 0)
        ////    {
        ////        return "";
        ////    }
        ////    else
        ////    {
        ////        return str[Convert.ToInt32(ilist[0].Description)];

        ////    }

        ////}
        ////public static string getOrderby(int iproductgroup, int categoryid,int icompanyid, string connectiostr)
        ////{
        ////    CS_ConfigProductGroup cs = new CS_ConfigProductGroup();
        ////    IList<ConfigProductGroupInfo> ilist = cs.getInfo(icompanyid, iproductgroup, categoryid, -1, connectiostr);
        ////    if (ilist == null || ilist.Count == 0)
        ////    {
        ////        return "";
        ////    }
        ////    else
        ////    {
        ////        return str[Convert.ToInt32(ilist[0].Description)];

        ////    }

        ////}
        public static string CreatePasswordHash(string pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        }

        public static string FormatDayOutEN_VN(string strDate, string dal)
        {
            string[] strArray = new string[3];
            StringTokenizer tokenizer = new StringTokenizer(strDate, dal);
            for (int i = 0; tokenizer.hasMoreTokens(); i++)
            {
                strArray[i] = tokenizer.nextToken();
            }
            strDate = strArray[0] + "/" + strArray[1] + "/" + strArray[2];
            return strDate;
        }

        public static string FormatDayOutVN_EN(string strDate, string dal)
        {
            string[] strArray = new string[3];
            StringTokenizer tokenizer = new StringTokenizer(strDate, dal);
            for (int i = 0; tokenizer.hasMoreTokens(); i++)
            {
                strArray[i] = tokenizer.nextToken();
            }
            strDate = strArray[1] + "/" + strArray[0] + "/" + strArray[2];
            return strDate;
        }

        public static string getBackUpServerName()
        {
            try
            {
                return ConfigurationManager.AppSettings["BACKUPSERVERNAME"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getBackUpServerName Error:" + exception.Message);
                return "";
            }
        }
        public string stringHeader(string companyname,string url,string description,string images,string ogtitle,string optype,
            string opurl,string opimages,string opsitename,string opdescription)
        {
                string s="<meta itemprop=\"name\" content="+companyname+"/>"+
                "<meta itemprop=\"url\" content="+url+" />"+
                "<meta itemprop=\"description\" content="+description+" />"+
                "<meta itemprop=\"image\" content="+images+" />"+
                "<meta property=\"og:title\" content="+ogtitle+" />"+
                "<meta property=\"og:type\" content="+optype+" />"+
                "<meta property=\"og:url\" content="+opurl+" />"+
                "<meta property=\"og:image\" content="+opimages+" />"+
                "<meta property=\"og:site_name\" content="+opsitename+" />"+
                "<meta property=\"og:description\" content="+opdescription+" />";
            return s;
        }
        public static string getConnetionString()
        {
            try
            {
                return ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
                //return "Database=gle4ba72_asian_db;Server=112.78.2.42" + "\\" + "2008,1433;Uid=gle4ba72_asiashop;Pwd=Quan123!@#;pooling=false;";
            }
            catch (Exception ex)
            {
                _logger.Info("Ex:" + ex.Message);
                return "";
            }
        }
        public static string getCompannyID()
        {
            try
            {
                return ConfigurationManager.AppSettings["companyid"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getExpried Error:" + exception.Message);
                return "0";
            }
        }
        public static int getCompannyId()
        {
            try
            {
                return Util.convertToInt(ConfigurationManager.AppSettings["companyid"].ToString());
            }
            catch (Exception exception)
            {
                _logger.Info("getExpried Error:" + exception.Message);
                return 0;
            }
        }
        public static string getOwnDatabase()
        {
            try
            {
                return ConfigurationManager.AppSettings["owndatabase"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailPass Error:" + exception.Message);
                return "";
            }
        }
        public static string getEmailPass()
        {
            try
            {
                return ConfigurationManager.AppSettings["emailpass"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailPass Error:" + exception.Message);
                return "";
            }
        }

        public static string getEmailSend()
        {
            try
            {
                return ConfigurationManager.AppSettings["emailsend"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailSend Error:" + exception.Message);
                return "";
            }
        }

        public static string getEmailTitleProfessionals()
        {
            try
            {
                return ConfigurationManager.AppSettings["titleprofessional"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailTitleProfessionals Error:" + exception.Message);
                return "";
            }
        }

        public static string getEmailTo()
        {
            try
            {
                return ConfigurationManager.AppSettings["emailto"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailTo Error:" + exception.Message);
                return "";
            }
        }

        public static string getEmailToBB()
        {
            try
            {
                return ConfigurationManager.AppSettings["emailtobb"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailToBB Error:" + exception.Message);
                return "";
            }
        }

        public static string getEmailToCC()
        {
            try
            {
                return ConfigurationManager.AppSettings["emailtocc"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getEmailToCC Error:" + exception.Message);
                return "";
            }
        }

        public static string getExpried()
        {
            try
            {
                return ConfigurationManager.AppSettings["expriedrent"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getExpried Error:" + exception.Message);
                return "0";
            }
        }

        public static string getFileSave()
        {
            return HttpContext.Current.Request.PhysicalApplicationPath;
        }

        public static int getPageOther()
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PAGESIZEOTHER"].ToString());
            }
            catch (Exception exception)
            {
                _logger.Info("getPageOther Error:" + exception.Message);
                return 15;
            }
        }

        public static int getPageView()
        {
            try
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["PAGESIZETVIEW"].ToString());
            }
            catch (Exception exception)
            {
                _logger.Info("getPageView Error:" + exception.Message);
                return 5;
            }
        }

        public static string getPassEmailSend()
        {
            return ConfigurationManager.AppSettings["emailpass"].ToString();
        }

        public static string getSayThankYou()
        {
            try
            {
                return ConfigurationManager.AppSettings["responseemail"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getSayThankYou Error:" + exception.Message);
                return "";
            }
        }

        public static string getSayThankYouEn()
        {
            try
            {
                return ConfigurationManager.AppSettings["responseemailen"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getSayThankYouEn Error:" + exception.Message);
                return "";
            }
        }

        public static string getSmtpHost()
        {
            try
            {
                return ConfigurationManager.AppSettings["smtphost"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getSmtpHost Error:" + exception.Message);
                return "";
            }
        }
        public static string getTitleEmail()
        {
            try
            {
                return ConfigurationManager.AppSettings["titleemail"].ToString();
            }
            catch (Exception exception)
            {
                _logger.Info("getTitleEmail Error:" + exception.Message);
                return "";
            }
        }
        public static string getStatusName(string lang, int id, int companyid)
        {
            return "nnn";
            //CS_Status cs = new CS_Status();
            //IList<StatusInfo> list = cs.getInfo(id, DATABASELOCAL);
            //if ((list == null) || (list.Count == 0))
            //{
            //    return "";
            //}
            //if (lang.Equals("vi"))
            //{
            //    return list[0].Name_vi;
            //}
            //return list[0].Name_en;
        }

        //public static string getStatusName(string lang, string statusid, int companyid)
        //{
        //    if ((statusid != null) && (statusid.Length != 0))
        //    {
        //        ArrayList list = Util.convertStringToArrayList(statusid, ",");
        //        if ((list != null) && (list.Count != 0))
        //        {
        //            if (list.Count == 1)
        //            {
        //                return getStatusName("vi", Convert.ToInt32(list[0].ToString()), companyid);
        //            }
        //            int count = list.Count;
        //            string result = "";
        //            for (int i = 0; i < count; i++)
        //            {
        //                if (i == (count - 1))
        //                {
        //                    result = result + " ID =" + list[i].ToString();
        //                }
        //                else
        //                {
        //                    result = result + " ID =" + list[i].ToString() + " OR ";
        //                }
        //            }
        //            result = "(" + result + ")";
        //            CS_Status status = new CS_Status();
        //            return status.getInfoLike(result, companyid, DATABASELOCAL);
        //        }
        //    }
        //    return "undefined";
        //}

        //public static string getStatusNewsName(string lang, int id, int companyid)
        //{
        //    IList<NewsStatusInfo> list = new CS_NewsStatus().getInfo(DATABASELOCAL,id);
        //    if ((list == null) || (list.Count == 0))
        //    {
        //        return "";
        //    }
        //    if (lang.Equals("vi"))
        //    {
        //        return list[0].Name_vi;
        //    }
        //    return list[0].Name_en;
        //}

        //public static string getStatusNewsName(string lang, string statusid, int companyid)
        //{
        //    if ((statusid != null) && (statusid.Length != 0))
        //    {
        //        ArrayList list = Util.convertStringToArrayList(statusid, ",");
        //        if ((list != null) && (list.Count != 0))
        //        {
        //            if (list.Count == 1)
        //            {
        //                return getStatusName("vi", Convert.ToInt32(list[0].ToString()), companyid);
        //            }
        //            int count = list.Count;
        //            string result = "";
        //            for (int i = 0; i < count; i++)
        //            {
        //                if (i == (count - 1))
        //                {
        //                    result = result + " ID =" + list[i].ToString();
        //                }
        //                else
        //                {
        //                    result = result + " ID =" + list[i].ToString() + " OR ";
        //                }
        //            }
        //            result = "(" + result + ")";
        //            CS_NewsStatus status = new CS_NewsStatus();
        //            return status.getInfoLike(result, companyid, DATABASELOCAL);
        //        }
        //    }
        //    return "undefined";
        //}

        public static string getStatusUserName(int statusid)
        {
            return "csstatus.getName(statusid, DATABASELOCAL)";
        }

        public string getToolTip(string shortdes)
        {
            string format = "cssbody=[dvbdy1] cssheader=[dvhdr1] header=[<span class=\"toolTipTitle\"></span>]body=[<table width=\"230px\" cellpadding=0 cellspacing=0 ><tr><td width=\"13\"><img src=\"images/topleft.gif\"  width=\"13\" height=\"12\"></td><td style=\"background-image:url(images/topmid.gif);padding:0px;margin:0px;font-size:12px;font-weight:bold;color:#000000\"></td><td width=\"19\"><img src=\"images/topright.gif\" width=\"19\" height=\"12\"></td></tr><tr><td width=\"13\" style=\"background-image:url(images/midleft.gif);\"></td><td style=\"color:#000080;font-size:11px;text-align:justify;padding:3px;background-color:#FFFFFF\"><span class=\"toolTipBody\">{0}</span></td><td width=\"19\" style=\"background-image:url(images/midrightshadow.png);\"></td></tr><tr><td width=\"13\"><img src=\"images/bottomleft.gif\"  width=\"13\" height=\"18\"></td><td style=\"background-image:url(images/bottommid.gif);\"></td><td width=\"8\"><img src=\"images/bottomright.gif\"  width=\"19\" height=\"18\"></td> </tr></table>]";
            return string.Format(format, shortdes);
        }

        public static string getUserEmailSend()
        {
            return ConfigurationManager.AppSettings["emailsend"].ToString();
        }

        //public static UsersInfo getUserInfo(int userid)
        //{
        //    IList<UsersInfo> list = new CS_Users().getInfo(userid, DATABASELOCAL);
        //    if ((list == null) || (list.Count == 0))
        //    {
        //        return null;
        //    }
        //    return list[0];
        //}

        //public static string getUserName(int customerid)
        //{
        //    IList<UsersInfo> list = new CS_Users().getInfo(customerid, DATABASELOCAL);
        //    if ((list == null) || (list.Count == 0))
        //    {
        //        return "undefined";
        //    }
        //    return list[0].Name;
        //}

        //public static string getUserName(string listuser)
        //{
        //    string str = "";
        //    ArrayList list = Util.convertStringToArrayList(listuser, ";");
        //    if ((list == null) || (list.Count == 0))
        //    {
        //        return "";
        //    }
        //    int count = list.Count;
        //    CS_Users users = new CS_Users();
        //    for (int i = 0; i < count; i++)
        //    {
        //        IList<UsersInfo> list2 = users.getInfo(Convert.ToInt32(list[i].ToString()), DATABASELOCAL);
        //        if ((list2 != null) && (list2.Count != 0))
        //        {
        //            if (i == (count - 1))
        //            {
        //                str = str + list2[0].Name;
        //            }
        //            else
        //            {
        //                str = str + list2[0].Name + " - ";
        //            }
        //        }
        //    }
        //    return str;
        //}

        public static ArrayList getValuesCheck(CheckBoxList plistcheck)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < plistcheck.Items.Count; i++)
            {
                if (plistcheck.Items[i].Selected)
                {
                    list.Add(plistcheck.Items[i].Value);
                }
            }
            return list;
        }

        public static string getValuesCheckToString(CheckBoxList plistcheck, string deal)
        {
            string str = string.Empty;
            int count = plistcheck.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (plistcheck.Items[i].Selected)
                {
                    if (i == (count - 1))
                    {
                        str = str + plistcheck.Items[i].Value;
                    }
                    else
                    {
                        str = str + plistcheck.Items[i].Value + deal;
                    }
                }
            }
            return str;
        }

        //public static IList<UsersInfo> load_SearchUser(string lang, string query, int types, DropDownList p_seachkindof)
        //{
        //    UsersInfo info;
        //    IList<UsersInfo> list = new CS_Users().getCombo(DATABASELOCAL);
        //    if (lang.Equals("vi"))
        //    {
        //        info = new UsersInfo(-1, "Chọn user");
        //    }
        //    else
        //    {
        //        info = new UsersInfo(-1, "Select user");
        //    }
        //    list.Add(info);
        //    p_seachkindof.DataSource = list;
        //    p_seachkindof.DataTextField = "Name";
        //    p_seachkindof.DataValueField = "UserID";
        //    if (types == 1)
        //    {
        //        p_seachkindof.SelectedValue = "-1";
        //    }
        //    p_seachkindof.DataBind();
        //    return list;
        //}
        //public static void load_UsersNotAll(int companyid, DropDownList dropdowlist)
        //{
        //    IList<UsersInfo> list = new CS_Users().getAllUsers(companyid, DATABASELOCAL);
           
        //    dropdowlist.DataSource = list;
        //    dropdowlist.DataTextField = "Name";
        //    dropdowlist.DataValueField = "UserID";
        //    dropdowlist.DataBind();
        //}
        //public static void load_Users(int types,int companyid, DropDownList dropdowlist)
        //{
        //    IList<UsersInfo> list = new CS_Users().getAllUsers(companyid, DATABASELOCAL);
        //    UsersInfo item = new UsersInfo(-1, "Sellect All");
        //    list.Add(item);
        //    dropdowlist.DataSource = list;
        //    dropdowlist.DataTextField = "Name";
        //    dropdowlist.DataValueField = "UserID";
        //    if (types == 1)
        //    {
        //        dropdowlist.SelectedValue = "-1";
        //    }
        //    dropdowlist.DataBind();
        //}
        //31/03/2015
        public static IList<CategoryInfo> load_CategoryLevelRoot(string lang, DropDownList dropDownList,int productgroupid)
        {
            try
            {
                CategoryController csCategory = new CategoryController();
                IList<CategoryInfo> list = csCategory.GetAllSearch(" WHERE ProductGroupId=" + productgroupid +" AND Code=-1");
                if (list == null || list.Count == 0)
                {
                    IList<CategoryInfo> ilist = new List<CategoryInfo>();
                    if (lang.Equals("vi"))
                    {
                        CategoryInfo info = new CategoryInfo();
                        info.CategoryId = -1;
                        info.NameVi = "Chọn danh mục";
                        ilist.Add(info);
                        dropDownList.DataSource = ilist;
                        dropDownList.DataTextField = "NameVi";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    else
                    {
                        CategoryInfo info = new CategoryInfo();
                        info.CategoryId = -1;
                        info.NameEn = "Select category";
                        ilist.Add(info);
                        dropDownList.DataSource = ilist;
                        dropDownList.DataTextField = "NameEn";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    dropDownList.DataBind();
                    return list;
                }
                else
                {
                    if (lang.Equals("vi"))
                    {
                        dropDownList.DataSource = list;
                        dropDownList.DataTextField = "NameVi";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    else
                    {
                        dropDownList.DataSource = list;
                        dropDownList.DataTextField = "NameEn";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    dropDownList.DataBind();
                    return list;
                }
            }

            catch (Exception ex)
            {

                return new List<CategoryInfo>();
            }

        }
        public static IList<CategoryInfo> load_CategoryLevelSubRoot(string lang, int companyid, DropDownList dropDownList,string categoryparent,string connectionstr)
        {
            try
            {
                CategoryController csCategory = new CategoryController();

             IList<CategoryInfo> list = csCategory.GetAllSubWeb(Util.convertToInt(categoryparent));
            if (list == null || list.Count == 0)
            {
                IList<CategoryInfo> ilist = new List<CategoryInfo>();
                if (lang.Equals("vi"))
                {
                    CategoryInfo info = new CategoryInfo();
                    info.CategoryId = -100;
                    info.NameVi = "Chọn danh mục";
                    ilist.Add(info);
                    dropDownList.DataSource = ilist;
                    dropDownList.DataTextField = "NameVi";
                    dropDownList.DataValueField = "CategoryId";
                }
                else
                {
                    CategoryInfo info = new CategoryInfo();
                    info.CategoryId = -100;
                    info.NameEn = "Select category";
                    ilist.Add(info);
                    dropDownList.DataSource = ilist;
                    dropDownList.DataTextField = "NameEn";
                    dropDownList.DataValueField = "CategoryId";
                }
                dropDownList.DataBind();
                return list;
            }
            else
            {


                if (lang.Equals("vi"))
                {

                    dropDownList.DataSource = list;
                    dropDownList.DataTextField = "NameVi";
                    dropDownList.DataValueField = "CategoryId";
                }
                else
                {


                    dropDownList.DataSource = list;
                    dropDownList.DataTextField = "NameEn";
                    dropDownList.DataValueField = "CategoryId";
                }
                dropDownList.DataBind();
                return list;
            }
            }
            catch (Exception )
            {

                return new List<CategoryInfo>();
            }

        }
        public static IList<CategoryInfo> load_CategoryLevelSubRootFour(string lang, int companyid, DropDownList dropDownList, string categoryparent, string connectionstr)
        {
            try
            {

                CategoryController csCategory = new CategoryController();

                IList<CategoryInfo> list = csCategory.GetAllSubSubWeb();
                if (list == null || list.Count == 0)
                {
                    IList<CategoryInfo> ilist = new List<CategoryInfo>();
                    if (lang.Equals("vi"))
                    {
                        CategoryInfo info = new CategoryInfo();
                        info.CategoryId = -100;
                        info.NameVi = "Chọn danh mục";
                        ilist.Add(info);
                        dropDownList.DataSource = ilist;
                        dropDownList.DataTextField = "NameVi";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    else
                    {
                        CategoryInfo info = new CategoryInfo();
                        info.CategoryId = -100;
                        info.NameEn = "Select category";
                        ilist.Add(info);
                        dropDownList.DataSource = ilist;
                        dropDownList.DataTextField = "NameEn";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    dropDownList.DataBind();
                    return list;
                }
                else
                {


                    if (lang.Equals("vi"))
                    {

                        dropDownList.DataSource = list;
                        dropDownList.DataTextField = "NameVi";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    else
                    {


                        dropDownList.DataSource = list;
                        dropDownList.DataTextField = "NameEn";
                        dropDownList.DataValueField = "CategoryId";
                    }
                    dropDownList.DataBind();
                    return list;
                }
            }
            catch (Exception)
            {

                return new List<CategoryInfo>();
            }

        }
        public static IList<CategoryInfo> load_Category(string lang, int companyid,string condition, DropDownList dropDownList, string connectionstr)
        {
            CategoryController csCategory = new CategoryController();
            IList<CategoryInfo> list = csCategory.GetAllSearch(condition);
            if (list == null || list.Count == 0)
            {
                IList<CategoryInfo> ilist =new List<CategoryInfo>();
                if (lang.Equals("vi"))
                {
                    CategoryInfo info = new CategoryInfo();
                    info.CategoryId = -100;
                    info.NameVi = "Chọn danh mục";
                    ilist.Add(info);
                    dropDownList.DataSource = ilist;
                    dropDownList.DataTextField = "NameVi";
                    dropDownList.DataValueField = "CategoryId";
                }
                else
                {
                    CategoryInfo info = new CategoryInfo();
                    info.CategoryId = -100;
                    info.NameEn = "Select category";
                    ilist.Add(info);
                    dropDownList.DataSource = ilist;
                    dropDownList.DataTextField = "NameEn";
                    dropDownList.DataValueField = "CategoryId";
                }
                dropDownList.DataBind();
                return list;

            }
            else
            {


                if (lang.Equals("vi"))
                {
                    dropDownList.DataSource = list;
                    dropDownList.DataTextField = "NameVi";
                    dropDownList.DataValueField = "CategoryId";
                }
                else
                {

                    dropDownList.DataSource = list;
                    dropDownList.DataTextField = "NameEn";
                    dropDownList.DataValueField = "CategoryId";
                }
                dropDownList.DataBind();
                return list;
            }
          
        }
        public static IList<ProductGroupInfo> load_ProductGroup(string lang, DropDownList dropDownList)
        {
            ProductGroupInfo info;
            ProductGroupController sGroup = new ProductGroupController();

            IList<ProductGroupInfo> list = sGroup.GetAll();
            if (lang.Equals("vi"))
            {

                info = new ProductGroupInfo();
                info.ProductGroupId = -1;
                info.NameVi = "Chọn Nhóm sản phẩm";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameVi";
                dropDownList.DataValueField = "ProductGroupId";
            }
            else
            {
                info = new ProductGroupInfo();
                info.ProductGroupId = -1;
                info.NameEn = "Select productgroup";
                list.Add(info);
                dropDownList.DataSource = list;
                dropDownList.DataTextField = "NameEn";
                dropDownList.DataValueField = "ProductGroupId";
            }
            dropDownList.DataBind();
            return list;
        }
       
        public static void load_UsersNotAll(int companyid, DropDownList dropdowlist)
        {
            UserController userController = new UserController();
            IList<UsersInfo> list = userController.GetUserCategory(companyid);

            dropdowlist.DataSource = list;
            dropdowlist.DataTextField = "Name";
            dropdowlist.DataValueField = "UserId";
            dropdowlist.DataBind();
        }
        public static string  GetProductGroupName(int productgroupid)
        {
           ProductGroupController productGroupController =new ProductGroupController();
            ProductGroupInfo productGroupInfo = productGroupController.GetById(productgroupid);
            if (productGroupInfo == null)
            {
                return "Undefined";
            }
            else
            {
                return productGroupInfo.NameVi;
            }
        }
        public static string GetUserName(int userid)
        {
            UserController userController = new UserController();
            UsersInfo iList = userController.GetById(userid);
            if (iList == null)
            {
                return "Undefined";
            }
            else return iList.Name;
        }
   
        public static string removeUnicode(string s)
        {
            for (int i = 0; i < Unicode_charss.Length; i++)
            {
                s = s.Replace(Unicode_charss[i],"");
            }
            return s;
        }

        public static void setCssclass(long ilong, int kindofupdate, Label p_label)
        {
            switch (kindofupdate)
            {
                case 0:
                    if (ilong <= 0)
                    {
                        p_label.CssClass = "msg_error";
                        p_label.Text = MSGCREATEERROR;
                     
                    }
                    else
                    {
                        p_label.CssClass = "msg_ok";
                        p_label.Text = MSGCREATEOK;
                    }
                    break;

                case 1:
                    if (ilong <= 0)
                    {
                        p_label.CssClass = "msg_error";
                        p_label.Text = MSGUPDATEERROR;
                        
                    }
                   else 
                    {
                        p_label.CssClass = "msg_ok";
                        p_label.Text = MSGUPDATEOK;
                        
                    }
                    break;
                default:
                    break;

            }
        }

        public static void setCssclass(string lang, long ilong, int kindofupdate, Label p_label)
        {
            switch (kindofupdate)
            {
                case 0:
                    if (ilong <= 0L)
                    {
                        p_label.CssClass = "msg_error";
                        if ((lang == null) || lang.Equals("en"))
                        {
                            p_label.Text = MSGCREATEERROR;
                        }
                        else
                        {
                            p_label.Text = MSGCREATEERROR_VI;
                        }
                        break;
                    }
                    p_label.CssClass = "msg_ok";
                    if ((lang != null) && !lang.Equals("en"))
                    {
                        p_label.Text = MSGCREATEOK_VI;
                        break;
                    }
                    p_label.Text = MSGCREATEOK;
                    break;

                case 1:
                    if (ilong <= 0L)
                    {
                        p_label.CssClass = "msg_error";
                        if ((lang == null) || lang.Equals("en"))
                        {
                            p_label.Text = MSGUPDATEERROR;
                        }
                        else
                        {
                            p_label.Text = MSGUPDATEERROR_VI;
                        }
                        break;
                    }
                    p_label.CssClass = "msg_ok";
                    if ((lang != null) && !lang.Equals("en"))
                    {
                        p_label.Text = MSGUPDATEOK_VI;
                        break;
                    }
                    p_label.Text = MSGUPDATEOK;
                    break;
            }
        }

        public static void setCssclass(long ilong, int kindofupdate, Label p_label, string sok, string serror)
        {
            switch (kindofupdate)
            {
                case 0:
                    if (ilong <= 0L)
                    {
                        p_label.CssClass = "msg_error";
                        p_label.Text = serror;
                        ;
                    }
                    else
                    {
                        p_label.CssClass = "msg_ok";
                        p_label.Text = sok;
                    }
                    break;

                case 1:
                    if (ilong <= 0L)
                    {
                        p_label.CssClass = "msg_error";
                        p_label.Text = serror;
                       
                    }
                    else
                    {


                        p_label.CssClass = "msg_ok";
                        p_label.Text =sok;
                    }
                    break;
            }
        }
        public static void setSelectDropdown(DropDownList droplist, string id)
        {
            droplist.ClearSelection();
            if (droplist.Items.Count > 0)
            {
                ListItem item = droplist.Items.FindByValue(id.Trim());
                if (item == null)
                {

                }
                else
                {
                    item.Selected = true;
                }
            }
        }
        public static void setSelectDropdown(CheckBoxList droplist, ArrayList vList)
        {
            droplist.ClearSelection();
            if (droplist.Items.Count > 0)
            {
                int size = vList.Count;
                for (int i = 0; i < size; i++)
                {
                    ListItem item = droplist.Items.FindByValue(vList[i].ToString());
                    _logger.Info("Check arraylist :" + vList[i].ToString());
                    if (item == null)
                    {

                    }
                    else 
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        public static void setSelectDropdown(CheckBoxList droplist, string id)
        {
            droplist.ClearSelection();
            if (droplist.Items.Count > 0)
            {
                ListItem item = droplist.Items.FindByValue(id);
                if (item == null)
                {

                }
                else
                {
                    item.Selected = true;
                }
            }
        }
        public static void setSelectDropdown(CheckBoxList droplist, int id)
        {
            droplist.ClearSelection();
            if (droplist.Items.Count > 0)
            {
                ListItem item = droplist.Items.FindByValue(id.ToString());
                if (item == null)
                {

                }
                else
                {
                    item.Selected = true;
                }
            }
        }
        
       
        public static string GetCategoryName(string lang, int categoryid)
        {
            CategoryController controller = new CategoryController();
            CategoryInfo categoryInfo = controller.GetById(categoryid);
            if (categoryInfo == null)
            {
                return "";
            }
            else
            {
                if (lang.Equals("vi"))
                    return categoryInfo.NameVi;
                else return categoryInfo.NameEn;
            }
        }
  
        public static string truncatShortdes(string s, int max)
        {
            string str;
            if ((s == null) || (s.Length == 0))
            {
                return s;
            }
            if (s.Length > max)
            {
                str = s.Substring(0, max) + " ...";
            }
            else
            {
                str = s;
            }
            return str;
        }
         public static string  setTitle(string lang, string s)
        {
             string title;
            if (lang.Equals("vi"))
                title = TITLEHOME + " " + s;
            else if (lang.Equals("en"))
                title = TITLEHOME_EN + " " + s;
            else title = TITLEHOME_CHI + " " + s;
             return title;

        }
        public static void setControlFile(string pathdirection)
        {
            _logger.Info("setControlFile :" + pathdirection);
            System.Security.AccessControl.FileSecurity fSec = File.GetAccessControl(pathdirection);
            fSec.AddAccessRule(new
                  System.Security.AccessControl.FileSystemAccessRule(@"Administrators",
                  System.Security.AccessControl.FileSystemRights.Read &
                  System.Security.AccessControl.FileSystemRights.Write &
                  System.Security.AccessControl.FileSystemRights.Delete,
                  System.Security.AccessControl.AccessControlType.Allow));
            File.SetAccessControl(pathdirection, fSec);
        }
        //public static string getTypename(string lang, string categoryid, string connectionstr)
        //{
        //    CS_Type cs = new CS_Type();
        //    IList<TypeInfo> ilist = cs.getInfo(Convert.ToInt32(categoryid), connectionstr);
        //    if (ilist == null || ilist.Count == 0)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        if (lang.Equals("vi"))
        //            return ilist[0].Name_vi;
        //        else
        //            return ilist[0].Name_en;
        //    }


        //}
        //public static string getStyleName(string lang, string categoryid, string connectionstr)
        //{
        //    CS_Style cs = new CS_Style();
        //    IList<StyleInfo> ilist = cs.getInfo(Convert.ToInt32(categoryid), connectionstr);
        //    if (ilist == null || ilist.Count == 0)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        if (lang.Equals("vi"))
        //            return ilist[0].Name_vi;
        //        else
        //            return ilist[0].Name_en;
        //    }


        //}
        //public static string getServieProvidername(string lang, string categoryid, int icompanyid, string connectionstr)
        //{
        //    _logger.Info("getServieProvidername:" + categoryid);
        //    CS_ServiceProvider cs = new CS_ServiceProvider();
        //    IList<ServiceProviderInfo> ilist = cs.getInfo(categoryid, icompanyid, connectionstr);
        //    if (ilist == null || ilist.Count == 0)
        //    {
        //        return "";
        //    }
        //    else
        //    {
        //        if (lang.Equals("vi"))
        //            return ilist[0].Name_vi;
        //        else
        //            return ilist[0].Name_en;
        //    }


        //}
        public static string getCategoryname(string lang,string categoryid)
        {
            CategoryController cs = new CategoryController();
            CategoryInfo ilist = cs.GetById(Convert.ToInt32(categoryid));
            if (ilist == null)
            {
                return "";
            }
            else
            {
                if (lang.Equals("vi"))
                    return ilist.NameVi;
                else
                    return ilist.NameEn;
            }

        }
    
     
        public static void removeControlFile(string pathdirection)
        {
            _logger.Info("removeControlFile :" + pathdirection);
            System.Security.AccessControl.FileSecurity fSec = File.GetAccessControl(pathdirection);
            if (fSec == null)
            {

            }
            else
            {
                fSec.RemoveAccessRule(new
                                          System.Security.AccessControl.FileSystemAccessRule(@"Administrators",
                                                                                             System.Security.
                                                                                                 AccessControl.
                                                                                                 FileSystemRights.Read &
                                                                                             System.Security.
                                                                                                 AccessControl.
                                                                                                 FileSystemRights.Write &
                                                                                             System.Security.
                                                                                                 AccessControl.
                                                                                                 FileSystemRights.Delete,
                                                                                             System.Security.
                                                                                                 AccessControl.
                                                                                                 AccessControlType.Allow));
                File.SetAccessControl(pathdirection, fSec);
            }
        }
        public static string getPaserHtml()
        {
            return ConfigurationManager.AppSettings["parserhtml"].ToString();
        }
        public static string getGeneralPublic()
        {
            try
            {
                return ConfigurationManager.AppSettings["generalhtmlurl"].ToString();
            }
            catch (Exception exception)
            {

                return "";
            }
        }
    
        public static void setSelectDropdown(DropDownList droplist, int id)
        {
            droplist.ClearSelection();
            if (droplist.Items.Count > 0)
            {
                ListItem item = droplist.Items.FindByValue(id.ToString());
                if (item == null)
                {

                }
                else
                {
                    item.Selected = true;
                }
            }
        }
        
        
    }
}

