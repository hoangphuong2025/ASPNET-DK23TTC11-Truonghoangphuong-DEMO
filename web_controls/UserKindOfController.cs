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
    public class UserKindOfController : BaseController<UserKindOfInfo>
    {
         public UserKindOfController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal UserKindOfController(string connectionString)
              : base(connectionString)
          {
          }
        
        
         private string SQL_SELECT_BYID = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                             FROM [tb_UserKindOf] WHERE Id=@Id";
         private string SQL_SELECT_ALL = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                             FROM [tb_UserKindOf]";
         private string SQL_SELECT_SEARCH = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                             FROM [tb_UserKindOf] {0}";
         private string SQL_INSERT = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_UserKindOf]
                                           ( [CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs])
                                        VALUES(@CompanyId,
	                                        @NameVi,	                                     
	                                        @NameEn,
	                                        @Indexs);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";


         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_UserKindOf]
                                        SET [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                       
	                                        [Indexs]=@Indexs
                                     WHERE [Id]=@Id";

         public void Insert(ref UserKindOfInfo userKindOfInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(userKindOfInfo, ref parms, false);
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
                         userKindOfInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(UserKindOfInfo userKindOfInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(userKindOfInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = userKindOfInfo.Id;
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
         public List<UserKindOfInfo> GetAll()
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
         public List<UserKindOfInfo> GetSearch(string condition)
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
         public UserKindOfInfo GetById(int companyid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = companyid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     UserKindOfInfo info = Row2Object(rdr);
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
