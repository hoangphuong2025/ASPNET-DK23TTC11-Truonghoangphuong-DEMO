using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using  web_connection;

using web_controls.Base;
using  web_model;


namespace web_controls
{
    public class UserStatusController : BaseController<UserStatusInfo>
    {
         public UserStatusController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal UserStatusController(string connectionString)
              : base(connectionString)
          {
          }
        
        
         private string SQL_SELECT_BYID = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]                                         
                                             FROM [tb_UserStatus] WHERE Id=@Id";
         private string SQL_SELECT_ALL = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]                                           
                                             FROM [tb_UserStatus]";
         private string SQL_SELECT_SEARCH = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]                                            
                                             FROM [tb_UserStatus] {0}";
         private string SQL_INSERT = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_UserStatus]
                                           ( [CompanyId]
                                            ,[NameVi]
                                            ,[NameEn])
                                        VALUES(@CompanyId,
	                                        @NameVi,	                                     
	                                        @NameEn);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";


         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_UserStatus]
                                        SET [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn
                                     WHERE [Id]=@Id";

         public void Insert(ref UserStatusInfo userStatusInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(userStatusInfo, ref parms, false);
             SqlCommand cmd = new SqlCommand();

             foreach (SqlParameter parm in parms)
                 cmd.Parameters.Add(parm);

             // Create the connection to the database
             using (SqlConnection conn = new SqlConnection(this.connectionString))
             {
                 // Insert the order status
                 strSQL.Append(SQL_INSERT);

                 conn.Open();
                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = strSQL.Append("SELECT @Id, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         userStatusInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(UserStatusInfo userStatusInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(userStatusInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = userStatusInfo.Id;
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
         public List<UserStatusInfo> GetAll()
         {
             try
             {

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_ALL, null);
                 if (rdr.HasRows)
                 {
                     return Rows2Objects(rdr);
                     
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public List<UserStatusInfo> GetSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_SELECT_SEARCH, condition);
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, null);
                 if (rdr.HasRows)
                 {
                     return Rows2Objects(rdr);

                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public UserStatusInfo GetById(int companyid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = companyid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     UserStatusInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
    }
}
