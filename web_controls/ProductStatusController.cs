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
    public class ProductStatusController : BaseController<ProductStatusInfo>
    {
         public ProductStatusController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal ProductStatusController(string connectionString)
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
	                                        FROM [tb_ProductStatus] WHERE Id=@Id";
         private string SQL_DELETE = @"DELETE  FROM [tb_ProductStatus] WHERE Id IN {0}";
         private string SQL_ALL = @"SELECT     
                                        [Id] ,
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture]	
	                                        FROM [tb_ProductStatus] Order BY Indexs ASC";
         private string SQL_SEARCH = @"SELECT     
                                          [Id] ,
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture]	
	                                        FROM [tb_ProductStatus] {0}";
         private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_ProductStatus]
                                           ([CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                        
	                                        [Indexs],
                                            [Picture])
                                        VALUES(@CompanyId,
	                                        @NameVi,
	                                        @NameEn,
	                                        @Indexs,@Picture);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_ProductStatus]
                                       SET  [CompanyId]=@CompanyId,
                                            [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                       
	                                        [Indexs]=@Indexs,	  
                                            [Picture]=@Picture	
                                       WHERE [Id]=@Id";
     
         public void Insert(ref ProductStatusInfo statusInfo)
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
         public ProductStatusInfo GetById(int id)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = id;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                    return Row2Object(rdr);
                     
                 }
             }
             catch (SqlException ex)
             {
                 return new ProductStatusInfo();
             }
             return null;
         }

         public List<ProductStatusInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     return  Rows2Objects(rdr);
                     
                 }
             }
             catch (SqlException ex)
             {
                 _logger.Info("Error :"+ex.Message);
                 throw ex;
             }
             return null;
         }
         public List<ProductStatusInfo> GetSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_SEARCH, condition);
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query , null);
                 if (rdr.HasRows)
                 {
                     return  Rows2Objects(rdr);
                  
                 }
             }
             catch (SqlException ex)
             {
                 return new List<ProductStatusInfo>();
             }
             return null;
         }


         public void Update(ProductStatusInfo statusInfo)
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

