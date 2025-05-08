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
    public class BannerController : BaseController<BannerInfo>
    {
         public BannerController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal BannerController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                           [Id]
                                          ,[NameVi]
                                          ,[NameEn]
                                          ,[DescriptionVi]
                                          ,[DescriptionEn]
                                          ,[Picture]
                                          ,[Indexs]
                                          ,[UrlString]
                                          ,[CategoryId]
	                                       FROM [tb_Banner] WHERE Id=@Id";

         private string SQL_DELETE = @"DELETE  FROM [tb_Banner] WHERE Id IN {0}";
         private string SQL_ALL = @"SELECT 
                                           [Id]
                                          ,[NameVi]
                                          ,[NameEn]
                                          ,[DescriptionVi]
                                          ,[DescriptionEn]
                                          ,[Picture]
                                          ,[Indexs]
                                          ,[UrlString]
                                          ,[CategoryId]
	                                       FROM [tb_Banner]  Order BY Indexs ASC";
         private string SQL_SEARCH = @"SELECT 
                                           [Id]
                                          ,[NameVi]
                                          ,[NameEn]
                                          ,[DescriptionVi]
                                          ,[DescriptionEn]
                                          ,[Picture]
                                          ,[Indexs]
                                          ,[UrlString]
                                          ,[CategoryId]
	                                       FROM [tb_Banner] {0}";
         private string SQL_CREATE = @"Declare @Id int; Declare @ERR int;
                                        INSERT INTO [tb_Banner]
                                           ([NameVi],
	                                        [NameEn],	                                          
                                            [DescriptionVi],
                                            [DescriptionEn],
                                            [Picture],
                                            [Indexs],
                                            [UrlString],
                                            [CategoryId])
                                     VALUES(@NameVi,
	                                        @NameEn,	                                                                            
	                                        @DescriptionVi,
                                            @DescriptionEn,
                                            @Picture,
                                            @Indexs,
                                            @UrlString,
                                            @CategoryId);
                                      SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Banner]
                                        SET [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,              
	                                        [DescriptionVi]=@DescriptionVi,	
                                            [Picture]=@Picture,   
                                            [Indexs]=@Indexs,
                                            [UrlString]=@UrlString,
                                            [CategoryId]=@CategoryId
                                            WHERE [Id]=@Id";
         private string SQL_MAX = @"SELECT Max(Id) FROM [tb_Banner]";
         public int GetMax()
         {
             int result = 1;
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_MAX, null);
                 if (rdr.HasRows)
                 {
                     while (rdr.Read())
                     {

                         Object obj = rdr.GetValue(0);
                         rdr.IsDBNull(0);
                         if (obj == null)
                         {
                             return 1;
                         }
                         else return result = rdr.GetInt32(0) + 1;
                     }
                 }
                 else
                 {
                     return result;
                 }
             }
             catch (Exception ex)
             {
                 _logger.Info("Error GetMax BookingId:" + ex.Message);
                 return result;
             }
             return result;
         }
       
         public void Insert(ref BannerInfo newsKindOfInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(newsKindOfInfo, ref parms, false);
             SqlCommand cmd = new SqlCommand();

             foreach (SqlParameter parm in parms)
             {
                
                 cmd.Parameters.Add(parm);
             }
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
                         newsKindOfInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public BannerInfo GetById(int Id)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = Id;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                    return  Row2Object(rdr);
                    
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }

         public List<BannerInfo> GetAll()
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
                 return null;
             }
             return null;
         }
         public List<BannerInfo> GetSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_SEARCH, condition);
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
         public void Update(BannerInfo roomTypeInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(roomTypeInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = roomTypeInfo.Id;
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

