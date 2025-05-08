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
    public class CompanyController : BaseController<CompanyInfo>
    {
         public CompanyController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal CompanyController(string connectionString)
              : base(connectionString)
          {
          }
        
        
         private string SQL_SELECT_BYID = @"SELECT     
                                            [CompanyId] ,
	                                        [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [NameChi],
	                                        [Description],
	                                        [AddressVi],
	                                        [AddressEn],
	                                        [AddressChi],
	                                        [Tel],
	                                        [Fax],
	                                        [Email],
	                                        [CellPhone],
	                                        [WebSite],
	                                        [Director],
	                                        [Edate],
	                                        [Mdate],
	                                        [McId],
	                                        [SiteMap] FROM [tb_Company] WHERE CompanyId=@CompanyId";
         private string SQL_SELECT_ALL = @"SELECT     
                                            [CompanyId] ,
	                                        [UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [NameChi],
	                                        [Description],
	                                        [AddressVi],
	                                        [AddressEn],
	                                        [AddressChi],
	                                        [Tel],
	                                        [Fax],
	                                        [Email],
	                                        [CellPhone],
	                                        [WebSite],
	                                        [Director],
	                                        [Edate],
	                                        [Mdate],
	                                        [McId],
	                                        [SiteMap] FROM [tb_Company] ";
         private string SQL_INSERT = @"Declare @CompanyId int; Declare @ERR int; 
                                     INSERT INTO [tb_Company]
                                           ([UserId] ,
	                                        [NameVi] ,
	                                        [NameEn],
	                                        [NameChi],
	                                        [Description],
	                                        [AddressVi],
	                                        [AddressEn],
	                                        [AddressChi],
	                                        [Tel],
	                                        [Fax],
	                                        [Email],
	                                        [CellPhone],
	                                        [WebSite],
	                                        [Director],
	                                        [Edate],
	                                        [Mdate],
	                                        [McId],
	                                        [SiteMap])
                                        VALUES(@NameVi,
	                                        @UserId,
	                                        @NameVi,
	                                        @NameEn,
	                                        @NameChi,
	                                        @Description,
	                                        @AddressVi,
	                                        @AddressEn,
	                                        @AddressChi,
	                                        @Tel,
	                                        @Fax,
	                                        @Email,
	                                        @CellPhone,
	                                        @WebSite,
	                                        @Director,
	                                        @Edate,
	                                        @Mdate,
	                                        @McId,
	                                        @SiteMap);
                                  SELECT @CompanyId=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Company]
                                        SET [UserId]=@UserId,
	                                        [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,
	                                        [NameChi]=@NameChi,
	                                        [Description]=@Description,
	                                        [AddressVi]=@AddressVi,
	                                        [AddressEn]=@AddressEn,
	                                        [AddressChi]=@AddressChi,
	                                        [Tel]=@Tel,
	                                        [Fax]=@Fax,
	                                        [Email]=@Email,
	                                        [CellPhone]=@CellPhone,
	                                        [WebSite]=@WebSite,
	                                        [Director]=@Director,
	                                        [Edate]=@Edate,
	                                        [Mdate]=@Mdate,
	                                        [McId]=@McId,
	                                        [SiteMap]=@SiteMap
                                     WHERE [CompanyId]=@CompanyId";
         public void Insert(ref CompanyInfo companyInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(companyInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @CompanyId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         companyInfo.CompanyId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(CompanyInfo companyInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(companyInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@CompanyId", SqlDbType.Int);
             paramId.Value = companyInfo.CompanyId;
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
      
         public CompanyInfo GetById(int companyid)
         {
           
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@CompanyId", SqlDbType.Int);
                 param[0].Value = companyid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     CompanyInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 _logger.Info("Error CompanyInfo GetById:"+ex.Message);
                 return new CompanyInfo();
             }
             return null;
         }
    }
}
