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
    public class PictureController : BaseController<ProductPicInfo>
    {
         public PictureController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal PictureController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                             [Id]
                                            ,[ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                            ,[PictureColor]                                       
	                                        FROM [tb_ProductPicture] WHERE Id=@Id";
         private string SQL_DELETE = @"DELETE  FROM [tb_ProductPicture] WHERE Id IN {0}";
         private string SQL_ALL = @"SELECT     
                                            [Id]
                                            ,[ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                            ,[PictureColor]                                   
	                                        FROM [tb_ProductPicture]  Order BY Indexs ASC";
         private string SQL_ALL_OTHER = @"SELECT     
                                             [Id]
                                            ,[ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                            ,[PictureColor]                                                                        
	                                        FROM [tb_ProductPicture]  WHERE Id!=@Id Order BY Indexs ASC";
         private string SQL_BY_PRODUCTID = @"SELECT     
                                             [Id]
                                            ,[ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                            ,[PictureColor]                                                                        
	                                        FROM [tb_ProductPicture]  WHERE ProductId=@ProductId Order BY Indexs ASC";
         private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_ProductPicture]
                                            ([ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs]
                                            ,[PictureColor])
                                        VALUES(@ProductId,
	                                        @Picture,
                                            @ColorId,
	                                        @CodeColor,
	                                        @NameVi,	                                        
	                                        @NameEn,
                                            @Indexs,
                                            @PictureColor);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_ProductPicture]
                                       SET  [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                      	                                                                          
	                                        [Indexs]=@Indexs,
                                            [ColorId]=@ColorId,
                                            [CodeColor]=@CodeColor,
                                            [Picture]=@Picture,  
	                                        [PictureColor]=@PictureColor  
                                            WHERE [Id]=@Id";
         private string SQL_ALL_SEARCH = @"SELECT     
                                             [Id]
                                            ,[ProductId]
                                            ,[Picture]
                                            ,[ColorId]
                                            ,[CodeColor]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs] 
                                            ,[PictureColor]   
	                                        FROM [tb_ProductPicture] WHERE {0}";
         public void Insert(ref ProductPicInfo productPicInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(productPicInfo, ref parms, false);
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
                         productPicInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public ProductPicInfo GetById(int Id)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = Id;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     ProductPicInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ProductPicInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_ALL_SEARCH, condition);
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     List<ProductPicInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ProductPicInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<ProductPicInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ProductPicInfo> GetAllByProductId(int productid)
         {
             try
             {
                 SqlParameter paramId = new SqlParameter("@ProductId", SqlDbType.Int);
                 paramId.Value = productid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_BY_PRODUCTID, paramId);
                 if (rdr.HasRows)
                 {
                     List<ProductPicInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public void Update(ProductPicInfo newsKindOfInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(newsKindOfInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = newsKindOfInfo.Id;
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

