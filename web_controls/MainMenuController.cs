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
    public class MainMenuController : BaseController<MenuMainInfo>
    {
       
         public MainMenuController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal MainMenuController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_CREATE = @"Declare @MainId int; Declare @ERR int; 
                                     INSERT INTO [tb_MenuMain]
                                           ([UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId])
                                        VALUES(@UserId,
	                                        @NameVi,
	                                        @NameEn,
	                                        @Indexs,
	                                        @CompanyId,
	                                        @StatusId);
                                  SELECT @MainId=@@IDENTITY; SELECT @ERR=@@ERROR;";

         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_MenuMain]
                                       SET  [UserId]=@UserId,	
                                            [NameVi]=@NameVi,	
                                            [NameEn]=@NameEn,	
	                                        [Indexs]=@Indexs,	    
                                            [StatusId]=@StatusId,                              
	                                        [CompanyId]=@CompanyId
                                      WHERE [MainId]=@MainId";
         private string SQL_DELETE = @"DELETE FROM   [tb_MenuMain]  WHERE [MainId] IN {0}";
         private string SQL_ALL        = @"SELECT   
                                            [MainId],    
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId] FROM [tb_MenuMain]";
         private string SQL_ALL_ACTIVE = @"SELECT   
                                            [MainId],    
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId] FROM [tb_MenuMain] WHERE [StatusId]>0";
         private string SQL_ALL_BY_USERID = @"SELECT   
                                            [MainId],    
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId] FROM [tb_MenuMain] WHERE [UserId]=@UserId";
         private string SQL_SELECT_BY_ID = @"SELECT   
                                            [MainId],    
                                            [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId] FROM [tb_MenuMain] WHERE [MainId]=@MainId";

        
         public void Insert(ref  MenuMainInfo menuMainInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(menuMainInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @MainId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         menuMainInfo.MainId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(MenuMainInfo menuMainInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(menuMainInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@MainId", SqlDbType.Int);
             paramId.Value = menuMainInfo.MainId;
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
         public MenuMainInfo GetById(int _mainId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = _mainId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     MenuMainInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuMainInfo> GetAll()
         {
             try
             {
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<MenuMainInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuMainInfo> GetAllActive()
         {
             try
             {

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ACTIVE, null);
                 if (rdr.HasRows)
                 {
                     List<MenuMainInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<MenuMainInfo> GetAll(int userid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Userid", SqlDbType.Int);
                 param[0].Value = userid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_BY_USERID, param);
                 if (rdr.HasRows)
                 {
                     List<MenuMainInfo> info = Rows2Objects(rdr);
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
   

    }
}
