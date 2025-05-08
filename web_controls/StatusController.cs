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
    public class StatusController : BaseController<StatusInfo>
    {
         public StatusController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal StatusController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                            [Id] ,
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture]		                                        
	                                        FROM [tb_Status] WHERE Id=@Id";
         private string SQL_DELETE = @"DELETE  FROM [tb_Status] WHERE Id IN {0}";
         private string SQL_ALL = @"SELECT     
                                        [Id] ,
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture]	
	                                        FROM [tb_Status] Order BY Indexs ASC";
         private string SQL_SEARCH = @"SELECT     
                                          [Id] ,
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture]	
	                                        FROM [tb_Status] {0}";
         private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_Status]
                                           ([CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture])
                                        VALUES(@NameVi,
	                                        @CompanyId,
	                                        @NameVi,
	                                        @NameEn,
	                                        @Indexs,@Picture);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Status]
                                       SET  [CompanyId]=@CompanyId,
                                            [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                       
	                                        [Indexs]=@Indexs,	  
                                            [Picture]=@Picture	
                                       WHERE [Id]=@Id";
     
         public void Insert(ref StatusInfo statusInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(statusInfo, ref parms, false);
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
                         statusInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public StatusInfo GetById(int id)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = id;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     StatusInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new StatusInfo();
             }
             return null;
         }

         public List<StatusInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<StatusInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<StatusInfo> GetSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_SEARCH, condition);
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query , null);
                 if (rdr.HasRows)
                 {
                     List<StatusInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<StatusInfo>();
             }
             return null;
         }
        
       
         public void Update(StatusInfo statusInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(statusInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = statusInfo.Id;
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
         public long Delete(string condition)
         {
             string query = string.Format(SQL_DELETE, condition);
           
             return SqlHelper.updateData(query, connectionString);
         }
           
    }
}

