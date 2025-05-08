using System;
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
    public class SubMenuController : BaseController<MenuSubInfo>
    {
       
         public SubMenuController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal SubMenuController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_CREATE = @"Declare @SubId int; Declare @ERR int; 
                                     INSERT INTO [tb_MenuSub]
                                               ([MainId],
                                                [UserId] ,
	                                            [NameVi] ,
	                                            [NameEn],
	                                            [Indexs],	
                                   	            [Url],	
	                                            [CompanyId],
	                                            [StatusId],
	                                            [Target],[IconString])
                                         VALUES(@MainId,
                                                @UserId,
	                                            @NameVi,
	                                            @NameEn,
	                                            @Indexs,
	                                            @Url,
	                                            @CompanyId,
	                                            @StatusId,@Target,@IconString);
                                  SELECT @SubId=@@IDENTITY; SELECT @ERR=@@ERROR;";

         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_MenuSub]
                                       SET  [MainId]=@MainId,
                                            [UserId]=@UserId,
	                                        [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,
	                                        [Indexs]=@Indexs,	
                                   	        [Url]=@Url,	
	                                        [CompanyId]=@CompanyId,
	                                        [StatusId]=@StatusId,
	                                        [Target]=@Target,
	                                        [IconString]=@IconString
                                     WHERE [SubId]=@SubId";
         private string SQL_ALL        = @"SELECT   
                                            [SubId],
                                            [MainId],
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	
                                   	        [Url],	
	                                        [CompanyId],
	                                        [StatusId],
	                                        [Target],
	                                        [IconString]                                          
                                            FROM [tb_MenuSub]";
         private string SQL_SELECT_BY_ID = @"SELECT   
                                            [SubId],
                                            [MainId],
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	
                                   	        [Url],	
	                                        [CompanyId],
	                                        [StatusId],
	                                        [Target],
	                                        [IconString]  FROM [tb_MenuSub] WHERE SubId=@SubId";
         private string SQL_SELECT_BY_MAINID = @"SELECT   
                                            [SubId],
                                            [MainId],
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	
                                   	        [Url],	
	                                        [CompanyId],
	                                        [StatusId],
	                                        [Target],
	                                        [IconString]  FROM [tb_MenuSub] WHERE MainId=@MainId";
         private string SQL_SELECT_BY_MAINID_AND_USERID = @"SELECT   
                                            [SubId],
                                            [MainId],
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	
                                   	        [Url],	
	                                        [CompanyId],
	                                        [StatusId],
	                                        [Target],
	                                        [IconString] FROM [tb_MenuSub] WHERE MainId=@MainId AND UserId=@UserId";

         private string SQL_DELETE = @"DELETE  FROM [tb_MenuSub] WHERE SubId in {0}";
         private string SQL_SELECT_BY_USERID= @"SELECT   
                                            [SubId],
                                            [MainId],
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	
                                   	        [Url],	
	                                        [CompanyId],
	                                        [StatusId],
	                                        [Target],
	                                        [IconString]
                                            FROM [tb_MenuSub] WHERE UserId=@UserId Order By MainId ASC,Indexs ASC";
         public void Insert(ref  MenuSubInfo menuSubInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(menuSubInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @SubId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         menuSubInfo.SubId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public MenuSubInfo GetById(int _subId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@SubId", SqlDbType.Int);
                 param[0].Value = _subId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     MenuSubInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuSubInfo> GetAllByMainId(int mainid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = mainid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_MAINID, param);
                 if (rdr.HasRows)
                 {
                     List<MenuSubInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuSubInfo> GetAllByMainIdAndUserId(int mainid,int userid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[2];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = mainid;
                 param[1] = new SqlParameter("@UserId", SqlDbType.Int);
                 param[1].Value = userid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_MAINID_AND_USERID, param);
                 if (rdr.HasRows)
                 {
                     List<MenuSubInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public long Delete(string condition)
         {
             string query = string.Format(SQL_DELETE, condition);
             
             return SqlHelper.updateData(query, connectionString);
         }
         public List<MenuSubInfo> GetAll()
         {
             try
             {
                 
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<MenuSubInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuSubInfo> GetAllByMcId(int userid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserId", SqlDbType.Int);
                 param[0].Value = userid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_USERID,param);
                 if (rdr.HasRows)
                 {
                     List<MenuSubInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public void Update(MenuSubInfo menuSubInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(menuSubInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@SubId", SqlDbType.Int);
             paramId.Value = menuSubInfo.SubId;
             parms.Add(paramId);
             SqlCommand cmd = new SqlCommand();

             foreach (SqlParameter parm in parms)
                 cmd.Parameters.Add(parm);


             // Create the connection to the database
             using (SqlConnection conn = new SqlConnection(this.connectionString))
             {

                 // Insert the order status
                 strSQL.Append(SQL_UPDATE_BY_ID);

                 conn.Open();
                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = strSQL.ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {


                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }

    }
}
