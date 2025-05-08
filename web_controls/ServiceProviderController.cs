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
    public class ServiceProviderController : BaseController<ServiceProviderInfo>
    {

        public ServiceProviderController()
            : base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal ServiceProviderController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_CREATE = @"Declare @ServiceProviderId int; Declare @ERR int; 
                                     INSERT INTO [tb_SevicesProvider]
                                           ([CompanyNameVi] ,
	                                        [CompanyNameEn] ,
	                                        [NameVi],
	                                        [NameEn],
	                                        [AddressVi],	                                   
	                                        [AddressEn],	                                   
	                                        [Tel],
	                                        [WebSite],
                                            [Fax],
                                            [Email],
                                            [ShortDesVi],
                                            [ShortDesEn],
                                            [DescriptionVi],
                                            [DescriptionEn],
                                            [Picture],
                                            [StatusId],
                                            [Edate],
                                            [Mdate],                                           
                                            [Indexs],
                                            [CompanyId])
                                        VALUES(@CompanyNameVi,
	                                        @CompanyNameEn,
	                                        @NameVi,
	                                        @NameEn,
	                                        @AddressVi,
	                                        @AddressEn,
	                                        @Tel,
	                                        @WebSite,
	                                        @Fax,
	                                        @Email,
	                                        @ShortDesVi,
	                                        @ShortDesEn,
	                                        @DescriptionVi,
	                                        @DescriptionEn,
	                                        @Picture,
	                                        @StatusId,
	                                        @Edate,
	                                        @Mdate,
	                                        @Indexs,
	                                        @CompanyId);
                                  SELECT @ServiceProviderId=@@IDENTITY; SELECT @ERR=@@ERROR;";

         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_SevicesProvider]
                                       SET  [CompanyNameVi]=@CompanyNameVi,
	                                        [CompanyNameEn]=@CompanyNameEn,
	                                        [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,
	                                        [AddressVi]=@AddressVi,	                                   
	                                        [AddressEn]=@AddressEn,	                                   
	                                        [Tel]=@Tel,
	                                        [WebSite]=@WebSite,
                                            [Fax]=@Fax,
                                            [Email]=@Email,
                                            [ShortDesVi]=@ShortDesVi,
                                            [ShortDesEn]=@ShortDesEn,
                                            [DescriptionVi]=@DescriptionVi,
                                            [DescriptionEn]=@DescriptionEn,
                                            [Picture]=@Picture,
                                            [StatusId]=@StatusId,
                                            [Edate]=@Edate,
                                            [Mdate]=@Mdate,                                           
                                            [Indexs]=@indexs,
                                            [CompanyId]=@CompanyId
                                     WHERE [ServiceProviderId]=@ServiceProviderId";
         private string SQL_ALL        = @"SELECT   
                                            [ServiceProviderId],
                                            [CompanyNameVi],
	                                        [CompanyNameEn],
	                                        [NameVi],
	                                        [NameEn],
	                                        [AddressVi],	                                   
	                                        [AddressEn],	                                   
	                                        [Tel],
	                                        [WebSite],
                                            [Fax],
                                            [Email],
                                            [ShortDesVi],
                                            [ShortDesEn],
                                            [DescriptionVi],
                                            [DescriptionEn],
                                            [Picture],
                                            [StatusId],
                                            [Edate],
                                            [Mdate],                                           
                                            [Indexs],
                                            [CompanyId] FROM [tb_SevicesProvider]";
         private string SQL_SELECT_BY_ID = @"SELECT   
                                            [ServiceProviderId],
                                            [CompanyNameVi] ,
	                                        [CompanyNameEn] ,
	                                        [NameVi],
	                                        [NameEn],
	                                        [AddressVi],	                                   
	                                        [AddressEn],	                                   
	                                        [Tel],
	                                        [WebSite],
                                            [Fax],
                                            [Email],
                                            [ShortDesVi],
                                            [ShortDesEn],
                                            [DescriptionVi],
                                            [DescriptionEn],
                                            [Picture],
                                            [StatusId],
                                            [Edate],
                                            [Mdate],                                           
                                            [Indexs],
                                            [CompanyId] FROM [tb_SevicesProvider] WHERE ServiceProviderId=@ServiceProviderId";

         private string SQL_DELETE = @"DELETE  FROM [tb_SevicesProvider] WHERE ServiceProviderId IN {0}";
         public void Insert(ref  ServiceProviderInfo serviceProviderInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(serviceProviderInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @ServiceProviderId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         serviceProviderInfo.ServiceProviderId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(ServiceProviderInfo serviceProviderInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(serviceProviderInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@ServiceProviderId", SqlDbType.Int);
             paramId.Value = serviceProviderInfo.ServiceProviderId;
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
         public ServiceProviderInfo GetById(int _serviceProviderId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@ServiceProviderId", SqlDbType.Int);
                 param[0].Value = _serviceProviderId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     ServiceProviderInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ServiceProviderInfo> GetAll()
         {
             try
             {
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<ServiceProviderInfo> info = Rows2Objects(rdr);
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
