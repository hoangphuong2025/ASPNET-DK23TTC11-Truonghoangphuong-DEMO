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
    public class ProductGroupController : BaseController<ProductGroupInfo>
    {
       
         public ProductGroupController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal ProductGroupController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_CREATE = @"Declare @ProductGroupId int; Declare @ERR int; 
                                     INSERT INTO [tb_ProductGroup]
                                           ([CompanyId],
	                                        [NameVi],
	                                        [NameEn],
	                                        [NameChi],
	                                        [Indexs],	                                   	                                   
	                                        [UserId])
                                        VALUES(@CompanyId,
	                                        @NameVi,
	                                        @NameEn,
	                                        @NameChi,
	                                        @Indexs,	                                      
	                                        @UserId);
                                  SELECT @ProductGroupId=@@IDENTITY; SELECT @ERR=@@ERROR;";

         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_ProductGroup]
                                       SET  [CompanyId]=@CompanyId,
	                                        [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,
	                                        [NameChi]=@NameChi,	 
                                  	        [Indexs]=@Indexs,	 
	                                        [UserId]=@UserId
                                     WHERE [ProductGroupId]=@ProductGroupId";
         private string SQL_ALL        = @"SELECT   
                                            [ProductGroupId],    
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],
	                                        [NameChi],
	                                        [Indexs],	                                   	                                   
	                                        [UserId] FROM [tb_ProductGroup]";
         private string SQL_SELECT_BY_ID = @"SELECT   
                                            [ProductGroupId],    
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],
	                                        [NameChi],
	                                        [Indexs],	                                   	                                   
	                                        [UserId] FROM [tb_ProductGroup] WHERE ProductGroupId=@ProductGroupId";

         private string SQL_SELECT_DELETE = @"DELETE FROM [tb_ProductGroup] WHERE ProductGroupId In {0}";
         public void Insert(ref  ProductGroupInfo productGroupInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(productGroupInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @ProductGroupId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         productGroupInfo.ProductGroupId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public ProductGroupInfo GetById(int productgroupid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@ProductGroupId", SqlDbType.Int);
                 param[0].Value = productgroupid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     ProductGroupInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ProductGroupInfo> GetAll()
         {
             try
             {
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<ProductGroupInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public void Update(ProductGroupInfo productGroupInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(productGroupInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@ProductGroupId", SqlDbType.Int);
             paramId.Value = productGroupInfo.ProductGroupId;
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
             string query = string.Format(SQL_SELECT_DELETE, condition);
             return SqlHelper.updateData(query, connectionString);
         }

    }
}
