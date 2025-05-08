using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using web_connection;
using web_controls.Base;
using web_model;


namespace web_controls
{
    public class MenuRightController : BaseController<MenuRightInfo>
    {
       
         public MenuRightController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal MenuRightController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_CREATE = @"Declare @UserRightId int; Declare @ERR int; 
                                     INSERT INTO [tb_MenuRight]
                                           ([UserId],
	                                        [MainId],
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId])
                                        VALUES(@UserId,
	                                        @MainId,
	                                        @SubId,
	                                        @Indexs,
	                                        @CompanyId);
                                  SELECT @UserRightId=@@IDENTITY; SELECT @ERR=@@ERROR;";

         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_MenuRight]
                                       SET  [UserId]=@UserId,
	                                        [MainId]=@MainId,
	                                        [SubId]=@SubId,
	                                        [Indexs]=@Indexs,	                                   
	                                        [CompanyId]=@CompanyId
                                     WHERE [UserRightId]=@UserRightId";
         private string SQL_ALL        = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId] FROM [tb_MenuRight]";
         private string SQL_ALL_MAIN_ID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId] FROM [tb_MenuRight] WHERE MainId=@MainId";
         private string SQL_ALL_MAIN_ID_AND_USERID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId] FROM [tb_MenuRight] WHERE MainId=@MainId AND  UserId=@UserId";
         private string SQL_SELECT_BY_ID = @"SELECT 
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId] FROM [tb_MenuRight] WHERE UserRightId=@UserRightId";
         private string SQL_CHECKINSERT = @"SELECT  
                                            [UserRightId],    
                                            [UserId],
	                                        [MainId],
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId] FROM [tb_MenuRight] " +
                                            " WHERE UserId=@UserId AND MainId=@MainId AND SubId=@SubId";

         public void Insert(ref MenuRightInfo menuRightInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(menuRightInfo, ref parms, false);
             SqlCommand cmd = new SqlCommand();

             foreach (SqlParameter parm in parms)
                 cmd.Parameters.Add(parm);

             // Create the connection to the database
             using (SqlConnection conn = new SqlConnection(this.connectionString))
             {
                 // Insert the order status
                 strSQL.Append(SQL_CREATE);

                 conn.Open();
                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = strSQL.Append("SELECT @UserRightId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         menuRightInfo.UserRightId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public MenuRightInfo GetById(int _userrightId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserRightId", SqlDbType.Int);
                 param[0].Value = _userrightId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     MenuRightInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuRightInfo> GetAll()
         {
             try
             {
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<MenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuRightInfo> GetAllByMainId(int _mainid)
         {
             SqlParameter[] param = new SqlParameter[1];
             param[0] = new SqlParameter("@Mainid", SqlDbType.Int);
             param[0].Value = _mainid;
             try
             {

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_MAIN_ID, param);
                 if (rdr.HasRows)
                 {
                     List<MenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuRightInfo> GetAllByMainIdAndUserId(int _mainid,int userid)
         {
             SqlParameter[] param = new SqlParameter[2];
             param[0] = new SqlParameter("@Mainid", SqlDbType.Int);
             param[0].Value = _mainid;
             param[1] = new SqlParameter("@UserId", SqlDbType.Int);
             param[1].Value = userid;
             try
             {

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_MAIN_ID_AND_USERID, param);
                 if (rdr.HasRows)
                 {
                     List<MenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
   

        private string SQL_DELETEMCID = "DELETE FROM [tb_MenuRight] WHERE USERID ={0}";
   
         public long deletebyMC(int mcid, string strconnection)
         {
             string s = String.Format(SQL_DELETEMCID, mcid);

             return SqlHelper.updateData(s, strconnection);
         }
    
         public IList<MenuRightInfo> getCheckInsert(int mcid, int mainid, int subid, string strconnection)
         {
            
             IList<MenuRightInfo> pList = new List<MenuRightInfo>();
             SqlParameter[] param = new SqlParameter[3];
             param[0] = new SqlParameter("@UserId", DbType.Int32);
             param[0].Value = mcid;
             param[1] = new SqlParameter("@MainId", DbType.Int32);
             param[1].Value = mainid;
             param[2] = new SqlParameter("@SubId", DbType.Int32);
             param[2].Value = subid;
             try
             {

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_CHECKINSERT, param);
                 if (rdr.HasRows)
                 {
                     List<MenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }

             return pList;
         }
     //   //public IList<MenuRightInfo> getAllByMainID(int mainid, int mcid,int indexmain, string strconnection)
     //   //{
     //   //    IList<MenuRightInfo> pList = new List<MenuRightInfo>();
     //   //    SqlDataReader rdr;
     //   //    SqlParameter[] param = new SqlParameter[2];
     //   //    param[0] = new SqlParameter("@mainid", DbType.Int32);
     //   //    param[0].Value = mainid;
     //   //    param[1] = new SqlParameter("@mcid", DbType.Int32);
     //   //    param[1].Value = mcid;

     //   //    rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,
     //   //                                   SQL_GETALLBYMAINID, param);


     //   //    if (rdr == null)
     //   //    {
     //   //    }
     //   //    else
     //   //    {
     //   //        while (rdr.Read())
     //   //        {
     //   //            MenuRightInfo grp = createObjectGetAllMenu(indexmain,rdr, strconnection);
     //   //            pList.Add(grp);

     //   //        }
     //   //    }
     //   //    return pList;
     //   //}
     //   public IList<MenuRightInfo> getAllByMainID(string lang,int mainid, int mcid, int indexmain,int companyid, string strconnection)
     //   {
     //       IList<MenuRightInfo> pList = new List<MenuRightInfo>();
     //       SqlDataReader rdr;
     //       SqlParameter[] param = new SqlParameter[3];
     //       param[0] = new SqlParameter("@mainid", DbType.Int32);
     //       param[0].Value = mainid;
     //       param[1] = new SqlParameter("@mcid", DbType.Int32);
     //       param[1].Value = mcid;

     //       param[2] = new SqlParameter("@companyid", DbType.Int32);
     //       param[2].Value = companyid;

     //       rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text,
     //                                      SQL_GETALLBYMAINID, param);


     //       if (rdr == null)
     //       {
     //       }
     //       else
     //       {
     //           while (rdr.Read())
     //           {
     //               MenuRightInfo grp = createObjectGetAllMenu(lang,indexmain, rdr, strconnection);
     //               pList.Add(grp);

     //           }
     //       }
     //       return pList;
     //   }
     //   public IList<MenuRightInfo> getAllByMainIDActive(string lang, int mainid, int mcid, int indexmain, int companyid,string statusid, string strconnection)
     //   {
     //       IList<MenuRightInfo> pList = new List<MenuRightInfo>();
     //       SqlDataReader rdr;
     //       SqlParameter[] param = new SqlParameter[3];
     //       param[0] = new SqlParameter("@mainid", DbType.Int32);
     //       param[0].Value = mainid;
     //       param[1] = new SqlParameter("@mcid", DbType.Int32);
     //       param[1].Value = mcid;

     //       param[2] = new SqlParameter("@companyid", DbType.Int32);
     //       param[2].Value = companyid;
     //       string query = string.Format (SQL_GETALLBYMAINIDACTIVE, statusid);

     //       rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text,
     //                                     query , param);


     //       if (rdr == null)
     //       {
     //       }
     //       else
     //       {
     //           while (rdr.Read())
     //           {
     //               MenuRightInfo grp = createObjectGetAllMenu(lang, indexmain, rdr, strconnection);
     //               pList.Add(grp);

     //           }
     //       }
     //       return pList;
     //   }
     //   public IList<MenuRightInfo> getAll(string strconnection)
     //   {
     //       IList<MenuRightInfo> pList = new List<MenuRightInfo>();
     //       SqlDataReader rdr;

     //       rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text,
     //                                      SQL_GETALL, null);


     //       if (rdr == null)
     //       {
     //       }
     //       else
     //       {
     //           while (rdr.Read())
     //           {
     //               MenuRightInfo grp = createObjectGetAll(rdr);
     //               pList.Add(grp);

     //           }
     //       }
     //       return pList;
     //   }


     //   public IList<MenuRightInfo> getInfo(int rightid,int mcid, string strconnection)
     //   {
     //       IList<MenuRightInfo> pList = new List<MenuRightInfo>();
     //       SqlDataReader rdr;
     //       SqlParameter[] param = new SqlParameter[2];
     //       param[0] = new SqlParameter("@rightid", DbType.Int32);
     //       param[0].Value = rightid;

     //       param[1] = new SqlParameter("@mcid", DbType.Int32);
     //       param[1].Value = mcid;
     //       rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text,
     //                                      SQL_INFO, param);
     //       if (rdr == null)
     //       {
     //       }
     //       else
     //       {
     //           while (rdr.Read())
     //           {
     //               MenuRightInfo grp = createObjectGetAll(rdr);
     //               pList.Add(grp);
     //           }
     //       }
     //       return pList;
     //   }
     //   private static MenuRightInfo createObjectGetAll( SqlDataReader rdr)
     //   {
     //       int rightid = Util.getInt(rdr, 0);
     //       int mcid = Util.getInt(rdr, 1);
     //       int mainid = Util.getInt(rdr, 2);
     //       int subid = Util.getInt(rdr, 3);
     //       int indexs = Util.getInt(rdr, 4);
     //       int companyid = Util.getInt(rdr, 5);
     //       MenuRightInfo grp = new MenuRightInfo(rightid, mcid, mainid, subid, indexs, companyid);
     //       return grp;
     //   }
     //   private static MenuRightInfo createObjectGetAllMenu(string lang,int indexmain,SqlDataReader rdr,string strconnection)
     //   {
     //       int rightid = Util.getInt(rdr, 0);
     //       int mcid = Util.getInt(rdr, 1);
     //       int mainid = Util.getInt(rdr, 2);
     //       int subid = Util.getInt(rdr, 3);
     //       int indexs = Util.getInt(rdr, 4);
     //       int companyid = Util.getInt(rdr, 5);
     //       string name = "";
     //       string url = "";
     //       string target = "";
     //       MenuSubInfo subinfo = getMenuSubInfo(lang,subid,strconnection);
     //       if(subinfo==null)
     //       {
     //           target = "";
     //       }
     //       else
     //       {
     //           if(lang.Equals ("vi"))
     //           {
     //               name = subinfo.Name;
     //           }
     //           else name = subinfo.Name_en;
     //           if (subinfo.URL.IndexOf("?") >= 0)
     //           {
     //               url = subinfo.URL + "&pindex=" + indexmain;
     //           }
     //           else url = subinfo.URL + "?pindex=" + indexmain;
     //           target = subinfo.Target;
     //       }
     //       MenuRightInfo grp = new MenuRightInfo(rightid, mcid, mainid, subid, indexs, name, url, companyid,target);
     //       return grp;
     //   }
     //   private static MenuSubInfo getMenuSubInfo(string lang,int subid,string strconnection)
     //   {
     //       CS_MenuSub cs = new CS_MenuSub();
     //       IList<MenuSubInfo> ilist = cs.getInfo(lang,subid,strconnection);
     //       if (ilist == null || ilist.Count == 0)
     //       {
     //           return null;
     //       }
     //       else return ilist [0];
     //   }

    }
}
