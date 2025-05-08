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
    public class WebsiteController : BaseController<WebsiteInfo>
    {
         public WebsiteController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal WebsiteController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                            [Id],	 
                                            [TitleVi],
                                            [TitleEn],                                                                         
	                                        [DesKeyWordVi],
	                                        [DesKeyWordEn],
	                                        [DesVi],
                                            [DesEn],
	                                        [WebSiteName], 
                                            [PostCode],
                                            [PostCodeName],
                                            [AddressLocality],
                                            [AddressCountry],
                                            [CountryName],
                                            [Tel]                                   
	                                        FROM [tb_WebSite] WHERE Id=@Id";
         private string SQL_DELETE = @"DELETE  FROM [tb_WebSite] WHERE Id in {}";

         private string SQL_ALL = @"SELECT     
                                          [Id],	 
                                            [TitleVi],
                                            [TitleEn],                                                                         
	                                        [DesKeyWordVi],
	                                        [DesKeyWordEn],
	                                        [DesVi],
                                            [DesEn],
	                                        [WebSiteName], 
                                            [PostCode],
                                            [PostCodeName],
                                            [AddressLocality],
                                            [AddressCountry],
                                            [CountryName],
                                            [Tel]              
	                                        FROM [tb_WebSite] Order by TitleVi ASC";
         private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_WebSite]
                                           ([TitleVi],
                                            [TitleEn],     
                                            [DesKeyWordVi],
	                                        [DesKeyWordEn],
	                                        [DesVi],
                                            [DesEn],
                                            [WebSiteName],
                                            [PostCode],
                                            [PostCodeName],
                                            [AddressLocality],
                                            [AddressCountry],
                                            [CountryName],
                                            [Tel])
                                        VALUES(@TitleVi,
                                            @TitleEn, 
                                            @DesKeyWordVi,
	                                        @DesKeyWordEn,
	                                        @DesVi,
	                                        @DesEn,
                                            @WebSiteName,
                                            @PostCode,
                                            @PostCodeName,
                                            @AddressLocality,
                                            @AddressCountry,
                                            @CountryName,
                                            @Tel);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_WebSite]
                                       SET  [TitleVi]=@TitleVi,
                                            [TitleEn]=@TitleEn,
                                            [DesKeyWordVi]=@DesKeyWordVi,
	                                        [DesKeyWordEn]=@DesKeyWordEn,	                                      
	                                        [DesVi]=@DesVi,	                                      
	                                        [DesEn]=@DesEn,
	                                        [WebSiteName]=@WebSiteName,
                                            [PostCode]=@PostCode,
                                            [PostCodeName]=@PostCodeName,
                                            [AddressLocality]=@AddressLocality,
                                            [AddressCountry]=@AddressCountry,
                                            [CountryName]=@CountryName,
                                            [Tel]=@Tel                                   
                                            WHERE [Id]=@Id";
         private string SQL_ALL_SEARCH = @"SELECT     
                                            [Id] ,
                                            [TitleVi],
                                            [TitleEn],  	                                                                         
	                                        [DesKeyWordVi],
	                                        [DesKeyWordEn],
	                                        [DesVi],
                                            [DesEn],
                                            [WebSiteName],
                                            [PostCode],
                                            [PostCodeName],
                                            [AddressLocality],
                                            [AddressCountry],
                                            [CountryName],
                                            [Tel]	
	                                        FROM [tb_WebSite] WHERE {0}";
         public void Insert(ref WebsiteInfo newsKindOfInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(newsKindOfInfo, ref parms, false);
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
                         newsKindOfInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public WebsiteInfo GetById(int Id)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = Id;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     WebsiteInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new WebsiteInfo();
             }
             return null;
         }
         public List<WebsiteInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_ALL_SEARCH, condition);
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     List<WebsiteInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<WebsiteInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<WebsiteInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return null ;
             }
             return null;
         }
        
         public void Update(WebsiteInfo newsKindOfInfo)
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

