using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using NLog;


namespace web_util
{
    public class Util
    {
        public static Logger _logger = LogManager.GetCurrentClassLogger();
        private string EncryptKey = "truonghoangphuong";
        public static string getCultureInfoLang(string lang)
        {
            if (lang.Equals("vi"))

                return getCultureInfo();
            else

                return getCultureInfoEn();
        }
        public static string getCultureInfoEn()
        {
            try
            {
                return ConfigurationManager.AppSettings["cultureinfoen"].ToString();
            }
            catch (Exception ex)
            {
                return "en-US";
            }
        }
        public static string FormatNumberVi(double number, string sformat, string returnstring)
        {

            if (number <= 0)
            {
                return returnstring;
            }
            else
            {

                NumberFormatInfo numberFormatInfo = new CultureInfo(sformat, true).NumberFormat;
                double check = Math.Ceiling(number) - Math.Floor(number);
                if (check == 0)
                    numberFormatInfo.NumberDecimalDigits = 0;
                else numberFormatInfo.NumberDecimalDigits = 0;
                numberFormatInfo.NumberDecimalSeparator = " ";
                string ss = number.ToString("N", numberFormatInfo);

                return ss;

            }
        }
        public static string checkRequestStringInput(string s, string returns)
        {
            try
            {
                if (string.IsNullOrEmpty(s))
                {
                    return returns;
                }
                else
                {
                    s = s.Replace("www.", "");
                    s = s.Replace("http:", "");
                    s = s.Replace(".com", "");
                    s = s.Replace(".com.vn", "");
                    s = s.Replace(".net", "");
                    s = s.Replace(".net.vn", "");
                    s = s.Replace(".biz", "");
                    s = s.Replace(".info", "");
                    s = s.Replace(".js", "");
                    s = s.Replace(".vn", "");
                    s = s.Replace(".exe", "");
                    s = s.Replace(".bat", "");
                    s = s.Replace(".zip", "");
                    s = s.Replace(".css", "");
                    s = s.Replace(".com", "");
                    s = s.Replace("url=", "");
                    s = s.Replace("[", "");
                    s = s.Replace("]", "");
                    s = s.Replace("link=", "");
                    s = s.Replace("<", "");
                    s = s.Replace(">", "");
                    return s;
                }
            }
            catch (Exception)
            {
                return returns;
            }
        }
        public static void Send_Email(int ssl, int smtpport, string emailfrom, string emailto, string body, string smtphost, string titleemail, string emailaddress, string password)
        {

            MailMessage message = new MailMessage();
            try
            {
               
                message.From = new MailAddress(emailfrom);
                if (string.IsNullOrEmpty(emailto))
                {
                    _logger.Info("emailto.............:null");
                }
                else
                {
                    message.To.Add(new MailAddress(emailto));
               
                    message.Subject = titleemail;
                    message.IsBodyHtml = true;
                    message.Body = body;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                    message.DeliveryNotificationOptions = DeliveryNotificationOptions.Delay;
                    message.Headers.Add("Disposition-Notification-To", "nguyentruongquan@gmail.com");
                    message.ReplyTo = new MailAddress("nguyentruongquan@gmail.com");
                
                    SmtpClient client = new SmtpClient();
                    client.Timeout = 5000;
                    client.Host = smtphost;
                    if (ssl == 1)
                    {
                        client.EnableSsl = true;
                    }
                    else client.EnableSsl = false;
                    if (smtpport == 0)
                    {

                    }
                    else
                    {
                        client.Port = smtpport;
                    }
                  
                    //client.UseDefaultCredentials = false;
                    // update 01/06/2020
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(emailaddress, password);
                  
                    client.Send(message);

                    _logger.Info("Send_Email.............sucessfull");
                }

            }
            catch (Exception ex)
            {

                _logger.Info("Error Send_Email.............:" + ex.Message);
            }
            finally
            {
                _logger.Info("Send_Email............. message.Dispose");
                message.Dispose();
            }
        }
        public static void Send_Email(string emailfrom, string emailto, string emailtobb, string emailtocc, string subject, string body, string smtphost, string titleemail, string emailaddress, string password)
        {
            
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(emailfrom);
                if (string.IsNullOrEmpty(emailto))
                {

                }
                else
                {
                    message.To.Add(new MailAddress(emailto));
                }
                if (string.IsNullOrEmpty(emailtobb))
                {

                }
                else
                {
                    message.To.Add(new MailAddress(emailtobb));
                }
                if (string.IsNullOrEmpty(emailtocc))
                {

                }
                else
                {
                    message.To.Add(new MailAddress(emailtocc));
                }
                
                message.Subject = titleemail;
                message.IsBodyHtml = true;
                message.Body = body;
                SmtpClient client = new SmtpClient();
                client.Timeout = 3000;
                client.Host = smtphost;
                client.Credentials = new System.Net.NetworkCredential(emailaddress, password);
                client.Send(message);

            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
                _logger.Info("Error Send_Email.............:" + ex.Message);
            }
        }
        public static string getData(string url)
        {
            string message = String.Empty;
            try
            {
                WebResponse response = WebRequest.Create(url).GetResponse();
                message = new StreamReader(response.GetResponseStream()).ReadToEnd();
                //_logger.Info("xxx:"+message);
                response.Close();
            }
            catch (Exception ex)
            {

            }
            return message;
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
        public static string replaceStringUnicode(string filename)
        {

            filename = Util.convertToUnSign2(filename);
            filename = filename.ToLower();
            filename = filename.Replace("\"", "");
            filename = filename.Replace(" ", "-");
            filename = filename.Trim().Replace("?", "");
            filename = filename.Replace("'", "");
            filename = filename.Replace(",", "");
            filename = filename.Replace(":", "");
            filename = filename.Replace("!", "");
            filename = filename.Replace("%", "");
            filename = filename.Replace(".", "");
            filename = filename.Replace("”", "");
            filename = filename.Replace("“", "");
            filename = filename.Replace("‘", "");
            filename = filename.Replace("'", "");
            filename = filename.Replace("/", "-");
            return filename;

        }
        public static int convertToInt(string s, int ireturn)
        {
          
            try
            {
                if (string.IsNullOrEmpty(s))
                {
                    return ireturn;
                }
                else return Convert.ToInt16(s);
            }
            catch (FormatException e)
            {
                _logger.Info("convertToInt :"+e.Message);
                return ireturn;

            }
        }
        public static int convertToInt(string s)
        {
          
            try
            {
                return Convert.ToInt32(s);
            }
            catch (Exception es)
            {
               //_logger.Info("Error convertToInt:"+es.Message);
                return 0;
                
            }
        }
        public static float convertFloat(string s)
        {
            try
            {
                return float.Parse(s);
            }
            catch (Exception)
            {
                return 0;

            }
        }
        public static double convertDouble(string s)
        {
            try
            {
                return double.Parse(s);
            }
            catch (Exception)
            {
                return 0;

            }
        }
        public static string convertToUnSign2(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                char ch;
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }  
        public static bool checkFile(string rootpath, string filename)
        {
           
            DirectoryInfo info = new DirectoryInfo(rootpath);
            if (info.Exists)
            {
                FileInfo[] files = info.GetFiles("*.htm");
                for (int i = 0; i < files.Length; i++)
                {
                        if (files[i].Name.Equals(filename))
                        {
                            _logger.Info("checkFile:" + filename+" is ok");
                            return true;
                        }
                       
                }
            }
            return false;
            
        }
        public static string checkRequestStringAdmin(string s)
        {
            if ((((s == null) || (s.Length == 0)) || ((s.IndexOf("http://") >= 0) || (s.IndexOf(",") >= 0))) || (s.IndexOf("='") >= 0) || s.IndexOf("www.") >= 0 || s.IndexOf("<") >= 0)
            {
                return "";
            }
            try
            {
                return s;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string checkRequestStringConvertToInt(string s)
        {
            if ((((s == null) || (s.Length == 0)) || ((s.IndexOf("http://") >= 0) || (s.IndexOf(",") >= 0))) || (s.IndexOf("='") >= 0))
            {
                return "";
            }
            try
            {
               int i = Convert.ToInt32(s);
               return s;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string checkRequestStringWeb(string s)
        {
            if (string.IsNullOrEmpty(s) || s.IndexOf("http://") >= 0 || s.IndexOf(",") >= 0)
            {
                return "";
            }
            try
            {
                Regex reg = new Regex(@"^[a-zA-Z'.\s\d]{1,200}$");
                if (!reg.IsMatch(s))
                {
                    _logger.Info("S NOT MATCH");
                    return "";
                }
                else
                {
                    return s;
                }
                return s;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string checkInputString(string s)
        {
            if (s == null || s.Length == 0)
            {
                return "";
            }
            else
            {
                s = s.Replace("www.", "");
                s = s.Replace("http:", "");
                s = s.Replace(".com", "");
                s = s.Replace(".com.vn", "");
                s = s.Replace(".net", "");
                s = s.Replace(".net.vn", "");
                s = s.Replace(".biz", "");
                s = s.Replace(".info", "");
                s = s.Replace(".js", "");
                s = s.Replace(".vn", "");
                s = s.Replace(".exe", "");
                s = s.Replace(".bat", "");
                s = s.Replace(".zip", "");
                s = s.Replace(".css", "");
                s = s.Replace(".com", "");
                s = s.Replace("url=", "");
                s = s.Replace("[", "");
                s = s.Replace("]", "");
                s = s.Replace("link=", "");
                s = s.Replace("<", "");
                s = s.Replace(">", "");
                Regex reg = new Regex(@"^[a-zA-Z'.\s\d]{1,200}$");  
                if (reg.IsMatch(s))
                {
                    
                    return s;
                }
                else
                {
                    return "";
                }
                
            }
        }
        public static string checkRequestString(string s)
        {
            if ((((s == null) || (s.Length == 0)) || ((s.IndexOf("http://") >= 0) || (s.IndexOf(",") >= 0))) || (s.IndexOf("='") >= 0)||s.IndexOf("www.")>=0||s.IndexOf("<")>=0)
            {
                return "";
            }
            try
            {
                s = checkInputString(s);
                return s;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static ArrayList convertStringToArrayList(string s, string dimm)
        {
            ArrayList list = new ArrayList();
            TokenizerString str = new TokenizerString(s, dimm);
            while (str.hasMoreTokens())
            {
                list.Add(str.nextToken());
            }
            return list;
        }

        public static bool createFolder(string sfolder)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(sfolder);
                if (info.Exists)
                {
                    return true;
                }
                try
                {
                    info.Create();
                }
                catch
                {
                    return false;
                }
            }
            catch (Exception)
            {
            }
            return true;
        }

        public static string CreatePasswordHash(string pwd)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        }

        public string DecryptData(string strData)
        {
            string str = "";
            string encryptKey = this.EncryptKey;
            if (encryptKey != "")
            {
                if (encryptKey.Length == 0x10)
                {
                    encryptKey = encryptKey + Left("XXXXXXXXXXXXXXXX", 0x10 - encryptKey.Length);
                }
                else if (encryptKey.Length == 0x10)
                {
                    encryptKey = Left(encryptKey, 0x10);
                }
                byte[] bytes = Encoding.UTF8.GetBytes(Left(encryptKey, 8));
                byte[] rgbIV = Encoding.UTF8.GetBytes(Right(encryptKey, 8));
                byte[] buffer = new byte[strData.Length];
                try
                {
                    buffer = Convert.FromBase64String(strData);
                }
                catch
                {
                    str = strData;
                }
                if (!(str == ""))
                {
                    return str;
                }
                try
                {
                    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                    MemoryStream stream = new MemoryStream();
                    CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
                catch
                {
                    return "";
                }
            }
            return strData;
        }
      
        public static string readFile(string filename)
        {
            string s = string.Empty;
            try
            {

                using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
                {
                    string content = sr.ReadToEnd();
                    s += content;
                }
                return s;
            }
            catch (Exception exception)
            {
                  _logger.Info("can not read file :"+exception.Message);
            }
            return s;
        }
        public static bool deleteFile(string rootpath, ArrayList listfile)
        {
            Exception exception;
            for (int i = 0; i < listfile.Count; i++)
            {
            }
            try
            {
                DirectoryInfo info = new DirectoryInfo(rootpath);
                if (info.Exists)
                {
                    FileInfo[] files = info.GetFiles();
                    for (int j = 0; j < files.Length; j++)
                    {
                        try
                        {
                            if (listfile.IndexOf(files[j].Name) >= 0)
                            {
                                files[j].Delete();
                            }
                        }
                        catch (Exception exception1)
                        {
                            exception = exception1;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exception2)
            {
                exception = exception2;
            }
            return true;
        }

        public static bool deleteFile(string rootpath, string filename)
        {
         
            Exception exception;
            try
            {
                DirectoryInfo info = new DirectoryInfo(rootpath);
                if (info.Exists)
                {
                   
                    FileInfo[] files = info.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                   
                        try
                        {
                            if (files[i].Name.Equals(filename))
                            {
                               
                                files[i].Delete();
                            }
                        }
                        catch (Exception exception1)
                        {
                            _logger.Info("Error delete file :" + exception1.Message);
                            exception = exception1;
                            continue;
                        }
                    }
                    return true;
                }
                return false;
            }
            catch (Exception exception2)
            {
                _logger.Info("Error delete file :" + exception2.Message);
                exception = exception2;
            }
            return false;
        }

        public string EncryptData(string strData)
        {
            try
            {
                string str;
                string encryptKey = this.EncryptKey;
                if (encryptKey != "")
                {
                    if (encryptKey.Length == 0x10)
                    {
                        encryptKey = encryptKey + Left("XXXXXXXXXXXXXXXX", 0x10 - encryptKey.Length);
                    }
                    else if (encryptKey.Length == 0x10)
                    {
                        encryptKey = Left(encryptKey, 0x10);
                    }
                    byte[] bytes = Encoding.UTF8.GetBytes(Left(encryptKey, 8));
                    byte[] rgbIV = Encoding.UTF8.GetBytes(Right(encryptKey, 8));
                    byte[] buffer = Encoding.UTF8.GetBytes(strData);
                    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                    MemoryStream stream = new MemoryStream();
                    CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    str = Convert.ToBase64String(stream.ToArray());
                }
                else
                {
                    str = strData;
                }
                return str;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static double Formatdouble(double number)
        {
            if (number == 0f || double.IsNaN(number))
            {
                return 0f;
            }
            return double.Parse(number.ToString("#.###.00"));
        }
        public static double FormatdoublePesent(double number)
        {
            if (number == 0f||double.IsNaN(number))
            {
                return 0f;
            }
            return double.Parse(number.ToString("#.#"));
        }
        public static float FormatFloat(float number)
        {
            if (number == 0f)
            {
                return 0f;
            }
            return float.Parse(number.ToString("#,###.00"));
        }

        public static string FormatNumber(decimal number)
        {
            if (number == 0M)
            {
                return "0";
            }
            string str = number.ToString("#,###");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumber(double number)
        {
            if (number == 0.0)
            {
                return "0";
            }
            string str = number.ToString("#,###");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }
        public static string FormatNumberReturnString(double number,string sreturn)
        {
            if (number <= 0.0)
            {
                return sreturn;
            }
            string str = number.ToString("N");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }
        public static string FormatNumber(int number)
        {
            if (number == 0)
            {
                return "0";
            }
            string str = number.ToString("#,###");
            if (str.IndexOf(",") == 0)
            {
                return (0 + str);
            }
            return str;
        }
        public static string getCultureInfo()
        {
            try
            {
                return ConfigurationManager.AppSettings["cultureinfo"].ToString();
            }
            catch (Exception ex)
            {
                return "en-US";
            }
        }
        public static string FormatNumber(double number, string sformat)
        {

            if (number <= 0)
            {
                return number.ToString();
            }
            else
            {
                string s = number.ToString("N", CultureInfo.GetCultureInfo(sformat).NumberFormat);
                s = s.Replace(".00", "");
                return s.Replace(",", ".");
            }

        }
        public static string FormatNumber(float number, string sformat)
        {

            if (number <= 0)
            {
                return number.ToString();
            }
            else
            {
                string s = number.ToString("N", CultureInfo.GetCultureInfo(sformat).NumberFormat);
                s = s.Replace(".00", "");
                return s.Replace(",", ".");
            }

        }
        public static string FormatNumber(float number)
        {
            if (number == 0f)
            {
                return "0";
            }
            string str = number.ToString("N");
            _logger.Info("FormatNumber float: "+str);
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumberBis(double number)
        {
            if (number == 0.0)
            {
                return "0";
            }
            string str = number.ToString("#.###.00");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumberBis(float number)
        {
            if (number == 0f)
            {
                return "0";
            }
            string str = number.ToString("#.###");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumberDec(float number)
        {
            if (number == 0f)
            {
                return "0";
            }
            string str = number.ToString("#.###.#");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumberNormal(float number)
        {
            if (number == 0f)
            {
                return "0";
            }
            string str = number.ToString("#,###");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string FormatNumberReport(float number)
        {
            if (number == 0f)
            {
                return "";
            }
            string str = number.ToString("#,###");
            if (str.IndexOf(".") == 0)
            {
                return (0 + str);
            }
            return str;
        }

        public static string getDay(SqlDataReader rdr, int i)
        {
            string str = "undefined";
            try
            {
                if (rdr.IsDBNull(i))
                {
                    str = "undefined";
                }
                else
                {
                    SqlDateTime sqlDateTime = rdr.GetSqlDateTime(i);
                    str = string.Concat(new object[] { twoChar(sqlDateTime.Value.Day), "/", twoChar(sqlDateTime.Value.Month), "/", sqlDateTime.Value.Year, " ", twoChar(sqlDateTime.Value.Hour), ":", twoChar(sqlDateTime.Value.Month), ":", twoChar(sqlDateTime.Value.Second) });
                }
            }
            catch (Exception)
            {
                return "undefined";
            }
            return str;
        }

        public static decimal getDecimal(SqlDataReader rdr, int i)
        {
            if (rdr.IsDBNull(i))
            {
                return 0M;
            }
            return Convert.ToDecimal(rdr.GetValue(i).ToString());
        }

        public static float getFloat(SqlDataReader rdr, int i)
        {
            float num = 0f;
            try
            {
                if (rdr.IsDBNull(i))
                {
                    num = 0f;
                }
                else
                {
                    num = float.Parse(rdr.GetSqlValue(i).ToString());
                }
            }
            catch (Exception e)
            {
                _logger.Info("Error :"+e.Message);
                return 0f;
            }
            return num;
        }

        public static string getFloatDisplay(SqlDataReader rdr, int i)
        {
            if (rdr.IsDBNull(i))
            {
                return "0";
            }
            return rdr.GetValue(i).ToString();
        }

        public static int getInt(SqlDataReader rdr, int i)
        {
            if (rdr.IsDBNull(i))
            {
                return 0;
            }
            return rdr.GetInt32(i);
        }

        public static int getInt32(SqlDataReader rdr, int i)
        {
            try
            {
                if (rdr.IsDBNull(i))
                {
                    return 0;
                }
                return rdr.GetInt32(i);
            }
            catch (Exception ex)
            {
                _logger.Info("Error getInt32 index:"+i);
                _logger.Info("Error getInt32 :"+ex.Message);
                return 0;
            }
           
        }
        public static string getLangAdmin(string surl)
        {
            if (string.IsNullOrEmpty(surl))
            {
                return "vi";
            }
            else
                if (surl.IndexOf("webadmin_en/") >= 0)
                {
                    return "en";
                }
                    else
                        if (surl.IndexOf("webadmin/") >= 0)
                            return "vi";
            return "vi";
        }
        public static  string getLang(string surl)
        {
            string lang="vi";
            
            if (string.IsNullOrEmpty(surl))
            {
                return "en";
            }
            else
                if (surl.IndexOf("/en/") >= 0)
                {
                    lang = "en";
                }
                else 
                     if(surl.IndexOf("/vi/") >= 0)
                       lang="vi";
            return lang;
        }

        public static string getMaxLen(ArrayList vlist)
        {
            string str = "0";
            if ((vlist == null) || (vlist.Count == 0))
            {
                return "";
            }
            string str2 = vlist[0].ToString();
            for (int i = 1; i < vlist.Count; i++)
            {
                string str3 = vlist[i].ToString();
                if (str3.Length > str2.Length)
                {
                    str = str3;
                    str2 = str3;
                }
                else
                {
                    str = str2;
                    str2 = str;
                }
            }
            return str;
        }

        public static string getMinLen(ArrayList vlist)
        {
            string str = "0";
            if ((vlist == null) || (vlist.Count == 0))
            {
                return "";
            }
            string str2 = vlist[0].ToString();
            for (int i = 1; i < vlist.Count; i++)
            {
                string str3 = vlist[i].ToString();
                if (str3.Length < str2.Length)
                {
                    str = str3;
                    str2 = str3;
                }
                else
                {
                    str = str2;
                    str2 = str;
                }
            }
            return str;
        }

        public static string getNowLong()
        {
            return string.Concat(new object[] { twoChar(DateTime.Now.Day), "/", twoChar(DateTime.Now.Month), "/", DateTime.Now.Year, " ",twoChar(DateTime.Now.Hour), ":",twoChar(DateTime.Now.Minute), ":",twoChar(DateTime.Now.Second) });
        }

        public static string getNowLongSingapors()
        {
            return string.Concat(new object[] { twoChar(DateTime.Now.Day), "/", twoChar(DateTime.Now.Month), "/", DateTime.Now.Year, " ", DateTime.Now.Hour + 1, ":", DateTime.Now.Minute, ":", DateTime.Now.Second });
        }

        public static string getNowMonthAndDay()
        {
            return (twoChar(DateTime.Now.Day) + twoChar(DateTime.Now.Month));
        }

        public static string getNowShort()
        {
            return string.Concat(new object[] { twoChar(DateTime.Now.Day), "/", twoChar(DateTime.Now.Month), "/", DateTime.Now.Year });
        }

        public static string getNowShort(string dim)
        {
            return string.Concat(new object[] { twoChar(DateTime.Now.Day), dim, twoChar(DateTime.Now.Month), dim, DateTime.Now.Year });
        }

        public static string getNowShortDefault()
        {
            return string.Concat(new object[] { twoChar(1), "/", twoChar(1), "/", 0x76c });
        }

        public static string getNowShortReceipt()
        {
            return (twoChar(DateTime.Now.Year) + twoChar(DateTime.Now.Month) + twoChar(DateTime.Now.Day));
        }
        public static string setDayLong(DateTime tt)
        {
            return twoChar(tt.Day) + "/" + twoChar(tt.Month) + "/" + twoChar(tt.Year) + " &nbsp; &nbsp; &nbsp;" + twoChar(tt.Hour) + ":" + twoChar(tt.Second);
        }

        public static string getParentCatgoryID(string scategory)
        {
            if ((scategory == null) || (scategory.Length == 0))
            {
                return "";
            }
            int index = scategory.IndexOf("_");
            if (index > 0)
            {
                return scategory.Substring(0, index);
            }
            return "-1";
        }

        public static string getReceiptNumber()
        {
            return (twoChar(DateTime.Now.Day) + twoChar(DateTime.Now.Month));
        }

        public static string getString(SqlDataReader rdr, int i)
        {
           
            string str = string.Empty;
            
                if (rdr.IsDBNull(i))
                {
                    str = "";
                }
                else
                {
                    str = rdr.GetString(i);
                }
            
            return str;
        }

        public string getStringFromRequest(string s)
        {
            if (((s == null) || (s.Length == 0)) || (s.IndexOf("'") > 0))
            {
                return "";
            }
            return s;
        }

        public static string getSubCatgoryID(string scategory)
        {
            if ((scategory == null) || (scategory.Length == 0))
            {
                return "";
            }
            int index = scategory.IndexOf("_");
            if (index > 0)
            {
                return scategory.Substring(index + 1, (scategory.Length - index) - 1);
            }
            return "-1";
        }

        public static DateTime getTimeZone()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = DateTime.Now.Hour + 1;
            int minute = DateTime.Now.Minute;
            return new DateTime(year, month, day, hour, minute, DateTime.Now.Second);
        }

        public static string getToolTip(string shortdes)
        {
            string format = "cssbody=[dvbdy1] cssheader=[dvhdr1] header=[<span class=\"toolTipTitle\"></span>]body=[<table  cellpadding=0 cellspacing=0 ><tr><td width=\"13\"><img src=\"../images/topleft.gif\"  width=\"13\" height=\"12\"></td><td style=\"background-image:url(../images/topmid.gif);padding:0px;margin:0px;font-size:12px;font-weight:bold;color:#000000\"></td><td width=\"19\"><img src=\"../images/topright.gif\" width=\"19\" height=\"12\"></td></tr><tr><td width=\"13\" style=\"background-image:url(../images/midleft.gif);\"></td><td style=\"color:#000080;font-size:11px;text-align:justify;padding:3px;background-color:#FFFFFF\"><span class=\"toolTipBody\">{0}</span></td><td width=\"19\" style=\"background-image:url(../images/midrightshadow.png);\"></td></tr><tr><td width=\"13\"><img src=\"../images/bottomleft.gif\"  width=\"13\" height=\"18\"></td><td style=\"background-image:url(../images/bottommid.gif);\"></td><td width=\"8\"><img src=\"../images/bottomright.gif\"  width=\"19\" height=\"18\"></td> </tr></table>]";
            return string.Format(format, shortdes);
        }

        public static ArrayList getValuesCheck(CheckBoxList checkboklist)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < checkboklist.Items.Count; i++)
            {
                if (checkboklist.Items[i].Selected)
                {
                    list.Add(checkboklist.Items[i].Value);
                }
            }
            return list;
        }
        public static ArrayList getValuesCheck(RadioButtonList checkboklist)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < checkboklist.Items.Count; i++)
            {
                if (checkboklist.Items[i].Selected)
                {
                    list.Add(checkboklist.Items[i].Value);
                }
            }
            return list;
        }
        public static string getValuesCheckToString(CheckBoxList checkboklist)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < checkboklist.Items.Count; i++)
            {
                if (checkboklist.Items[i].Selected)
                {
                    list.Add(checkboklist.Items[i].Value);
                }
            }
            string str = "";
            if (list.Count > 0)
            {
                int count = list.Count;
                for (int j = 0; j < count; j++)
                {
                    if (j == (count - 1))
                    {
                        str = str + list[j].ToString();
                    }
                    else
                    {
                        str = str + list[j].ToString() + ",";
                    }
                }
            }
            return str;
        }

        public static string getValuesCheckToString(CheckBoxList checkboklist, string dimn)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < checkboklist.Items.Count; i++)
            {
                if (checkboklist.Items[i].Selected)
                {
                    list.Add(checkboklist.Items[i].Value);
                }
            }
            string str = "";
            if (list.Count > 0)
            {
                int count = list.Count;
                for (int j = 0; j < count; j++)
                {
                    if (j == (count - 1))
                    {
                        str = str + list[j].ToString();
                    }
                    else
                    {
                        str = str + list[j].ToString() + dimn;
                    }
                }
            }
            return str;
        }

        public static string Left(string strParam, int iLen)
        {
            if (iLen > 0)
            {
                return strParam.Substring(0, iLen);
            }
            return strParam;
        }

        public static string PadString(HttpServerUtility utility, int nummax, int isub)
        {
            string str2;
            int num = 20;
            try
            {
                string s = "";
                if (nummax != isub)
                {
                    int num2 = 0;
                    if ((nummax - isub) < num)
                    {
                        if (isub <= num)
                        {
                            num2 = 2;
                        }
                        else
                        {
                            num2 = 1;
                        }
                    }
                    else
                    {
                        num2 = nummax / num;
                    }
                    for (int i = 1; i < num2; i++)
                    {
                        s = s + "<br>";
                    }
                }
                str2 = utility.HtmlDecode(s);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }

        public static string PadStringLeft(HttpServerUtility utility, int nummax, int isub)
        {
            string str2;
            int num = 0x16;
            try
            {
                string s = "";
                int num2 = nummax / num;
                int num3 = isub / num;
                int num4 = num2 - num3;
                for (int i = 0; i < num4; i++)
                {
                    s = s + "<br>";
                }
                str2 = utility.HtmlDecode(s);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str2;
        }

     

        public static string Right(string strParam, int iLen)
        {
            if (iLen > 0)
            {
                return strParam.Substring(strParam.Length - iLen, iLen);
            }
            return strParam;
        }

        public static void savefile(string filename, string scontext)
        {
            _logger.Info("FILE SAVE ....:" + filename);
            try
            {
                StreamWriter writer = new FileInfo(filename).CreateText();
                writer.Write(scontext);
                writer.Close();
                _logger.Info("Save FILE OK");
            }
            catch (Exception ex)
            {
                _logger.Info("Save file ............Error:"+ex.Message);
            }
        }

        public static void Send_Email(string emailfrom, string emailto, string subject, string body, string smtphost, string titleemail, string emailaddress, string password)
        {
            //try
            //{
            //    MailMessage message = new MailMessage();

            //    message.From = new MailAddress(emailfrom);
            //    message.To.Add(new MailAddress(emailto));
            //    message.Subject = titleemail;
            //    message.IsBodyHtml = true;
            //    message.Body = body;
            //    new SmtpClient { Timeout = 0xbb8, Host = smtphost, Credentials = new NetworkCredential(emailaddress, password) }.Send(message);
            //}
            //catch (Exception)
            //{
            //}
        }

        public static void SendFile(string fileName, HttpResponse Response1)
        {
            FileInfo info = new FileInfo(fileName);
            if (info.Exists)
            {
                Response1.Clear();
                Response1.AddHeader("Content-Disposition", "attachment; filename=" + info.Name);
                Response1.AddHeader("Content-Length", info.Length.ToString());
                Response1.ContentType = "application/zip";
                Response1.WriteFile(info.FullName);
                Response1.Flush();
                Response1.End();
            }
        }

        public static void setCombo(CheckBoxList abc, string names, string value, DataSet ds)
        {
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }

        public static void setCombo(DropDownList abc, string names, string value, DataSet ds)
        {
            try
            {
                if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
                {
                    abc.DataSource = ds.Tables[0];
                    abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                    abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                    abc.DataBind();
                }
            }
            catch (Exception)
            {
            }
        }

        public static void setCombo(ListBox abc, string names, string value, DataSet ds)
        {
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }

        public static void setCombo(RadioButtonList abc, string names, string value, DataSet ds)
        {
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }

        public static void setComboAddCategory(DropDownList abc, string names, string value, DataSet ds)
        {
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }

        public static void setComboCategory(DropDownList abc, string names, string value, DataSet ds)
        {
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!ds.Tables[0].Rows[i][2].ToString().Equals("-1"))
                    {
                        string str2 = "-" + ds.Tables[0].Rows[i][1].ToString();
                        ds.Tables[0].Rows[i][1] = str2;
                    }
                }
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }

        public static int setComboReturn(DropDownList abc, string names, string value, DataSet ds)
        {
            if ((ds == null) || (ds.Tables[0].Rows.Count == 0))
            {
                return 0;
            }
            abc.DataSource = ds.Tables[0];
            abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
            abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
            abc.DataBind();
            return ds.Tables[0].Rows.Count;
        }

        public static void setComboSelectAll(DropDownList abc, string names, string value, DataSet ds)
        {
            ds.Tables[0].Rows.Add(new object[0]);
            if ((ds != null) && (ds.Tables[0].Rows.Count != 0))
            {
                abc.DataSource = ds.Tables[0];
                abc.DataTextField = ds.Tables[0].Columns[names].ColumnName.ToString();
                abc.DataValueField = ds.Tables[0].Columns[value].ColumnName.ToString();
                abc.DataBind();
            }
        }
        
        public static void showCheckBox(string sstatus, CheckBoxList checkboxlist, string dimn)
        {
            ArrayList list = convertStringToArrayList(sstatus, dimn);
            if ((list != null) && (list.Count != 0))
            {
                for (int i = 0; i < checkboxlist.Items.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (Convert.ToInt32(list[j].ToString()) == Convert.ToInt32(checkboxlist.Items[i].Value))
                        {
                            checkboxlist.Items[i].Selected = true;
                        }
                    }
                }
            }
        }
        public static void showCheckBox(string sstatus, RadioButtonList checkboxlist, string dimn)
        {
            ArrayList list = convertStringToArrayList(sstatus, dimn);
            if ((list != null) && (list.Count != 0))
            {
                for (int i = 0; i < checkboxlist.Items.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (Convert.ToInt32(list[j].ToString()) == Convert.ToInt32(checkboxlist.Items[i].Value))
                        {
                            checkboxlist.Items[i].Selected = true;
                            return;
                        }
                    }
                }
            }
        }
        public static string twoChar(int valueCheck)
        {
            if (valueCheck > 9)
            {
                return valueCheck.ToString();
            }
            return ("0" + valueCheck);
        }
        public static string getCurrentDayStringVN()
        {
            string day = DateTime.Now.Day.ToString();
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            else
            {

            }
            string month = DateTime.Now.Month.ToString();
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            else
            {

            }
            string year = DateTime.Now.Year.ToString();
            return "Hôm nay, ngày " + day + " tháng " + month + " năm " + year;
        }
        public static string getCurrentDayStringEN()
        {
            string[] selectMonth = new string[12];
            selectMonth[0]  ="January";
            selectMonth[1]  ="February";
            selectMonth[2]  ="March";
            selectMonth[3]  ="April";
            selectMonth[4]  ="May";
            selectMonth[5]  ="June";
            selectMonth[6]  ="July";
            selectMonth[7]  ="August";
            selectMonth[8]  ="September";
            selectMonth[9]  ="October";
            selectMonth[10] ="November";
            selectMonth[11] ="December";
            string day = DateTime.Now.DayOfWeek.ToString();
            string sday = DateTime.Now.Day.ToString();

            string imonth = DateTime.Now.Month.ToString();


            string year = DateTime.Now.Year.ToString();
            return "Today&nbsp;" + day + ",&nbsp;" + selectMonth[Convert.ToInt32(imonth) - 1] + " " + sday +",&nbsp;" + year;
        }
    }
}

