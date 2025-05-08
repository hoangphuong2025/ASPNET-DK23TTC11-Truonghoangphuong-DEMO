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
    public class IntroController : BaseController<IntroInfo>
    {
         public IntroController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal IntroController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                            [IntroId] ,
	                                        [UserId] ,
	                                        [CompanyId],	                                     
	                                        [TitleVi],
	                                        [TitleEn],	                                        
	                                        [ShortDesVi],
	                                        [ShortDesEn],	                                        
	                                        [DescriptionVi],
	                                        [DescriptionEn],	                                        
	                                        [IntroKindOfId],
	                                        [IntroStatusId],	                                     
	                                        [Edate],
	                                        [Mdate],
	                                        [Indexs],
	                                        [Picture],
	                                        [SourceText]
	                                        FROM [tb_Introduction] WHERE IntroId=@IntroId";
         private string SQL_DELETE = @"DELETE  FROM [tb_Introduction] WHERE IntroId IN {0}";
         private string SQL_ALL = @"SELECT     
                                            [IntroId] ,
	                                        [UserId] ,
	                                        [CompanyId] ,	                                     
	                                        [TitleVi],
	                                        [TitleEn],	                                        
	                                        [ShortDesVi],
	                                        [ShortDesEn],	                                        
	                                        [DescriptionVi],
	                                        [DescriptionEn],	                                        
	                                        [IntroKindOfId],
	                                        [IntroStatusId],	                                     
	                                        [Edate],
	                                        [Mdate],
	                                        [Indexs],
	                                        [Picture],
	                                        [SourceText]
	                                        FROM [tb_Introduction] Order BY IntroKindOfId ASC,Indexs ASC";
         private string SQL_ALL_OTHER = @"SELECT     
                                           [IntroId] ,
	                                        [UserId] ,
	                                        [CompanyId] ,	                                     
	                                        [TitleVi],
	                                        [TitleEn],	                                        
	                                        [ShortDesVi],
	                                        [ShortDesEn],	                                        
	                                        [DescriptionVi],
	                                        [DescriptionEn],	                                        
	                                        [IntroKindOfId],
	                                        [IntroStatusId],	                                     
	                                        [Edate],
	                                        [Mdate],
	                                        [Indexs],
	                                        [Picture],
	                                        [SourceText]
	                                        FROM [tb_Introduction] WHERE IntroId!=@Introid Order BY Indexs ASC";
         private string SQL_CREATE = @"Declare @IntroId int; Declare @ERR int; 
                                     INSERT INTO [tb_Introduction]
                                           ([UserId] ,
	                                        [CompanyId] ,	                                      
	                                        [TitleVi],
	                                        [TitleEn],	                                       
	                                        [ShortDesVi],
	                                        [ShortDesEn],	                                        
	                                        [DescriptionVi],
	                                        [DescriptionEn],	                                        
	                                        [IntroKindOfId],
	                                        [IntroStatusId],	                                     
	                                        [Edate],
	                                        [Mdate],
	                                        [Indexs],
	                                        [Picture],
	                                        [SourceText])
                                        VALUES(@UserId,
	                                        @CompanyId,
	                                        @TitleVi,
	                                        @TitleEn,	                                     
	                                        @ShortDesVi,
	                                        @ShortDesEn,	                                        
	                                        @DescriptionVi,
	                                        @DescriptionEn,	                                        
	                                        @IntroKindOfId,
	                                        @IntroStatusId,	                                                                     
	                                        @Edate,
	                                        @Mdate,
	                                        @Indexs,
	                                        @Picture,
                                            @SourceText);
                                  SELECT @IntroId=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Introduction]
                                       SET  [UserId]=@UserId,
	                                        [CompanyId]=@CompanyId,	                                      
	                                        [TitleVi]=@TitleVi,
	                                        [TitleEn]=@TitleEn,	                                     
	                                        [ShortDesVi]=@ShortDesVi,
	                                        [ShortDesEn]=@ShortDesEn,	                                        
	                                        [DescriptionVi]=@DescriptionVi,
	                                        [DescriptionEn]=@DescriptionEn,	                                        
	                                        [IntroKindOfId]=@IntroKindOfId,
	                                        [IntroStatusId]=@IntroStatusId,	                                     
	                                        [Edate]=@Edate,
	                                        [Mdate]=@Mdate,
	                                        [Indexs]=@Indexs,
	                                        [Picture]=@Picture,
	                                        [SourceText]=@SourceText	                                     
                                            WHERE [IntroId]=@IntroId";
         private string SQL_ALL_SEARCH = @"SELECT 
                                            [IntroId],    
                                            [UserId],
	                                        [CompanyId] ,	                                      
	                                        [TitleVi],
	                                        [TitleEn],	                                        
	                                        [ShortDesVi],
	                                        [ShortDesEn],	                                        
	                                        [DescriptionVi],
	                                        [DescriptionEn],	                                        
	                                        [IntroKindOfId],
	                                        [IntroStatusId],	                                     
	                                        [Edate],
	                                        [Mdate],
	                                        [Indexs],
	                                        [Picture],
	                                        [SourceText]
	                                        FROM [tb_Introduction] {0}";
         public void Insert(ref IntroInfo introInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(introInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @IntroId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         introInfo.IntroId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public IntroInfo GetById(int introId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@IntroId", SqlDbType.Int);
                 param[0].Value = introId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     IntroInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<IntroInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_ALL_SEARCH, condition);
                
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     List<IntroInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public List<IntroInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<IntroInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<IntroInfo> GetAllOther(int introid)
         {
             try
             {
                 SqlParameter paramId = new SqlParameter("@IntroId", SqlDbType.Int);
                 paramId.Value = introid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_OTHER, paramId);
                 if (rdr.HasRows)
                 {
                     List<IntroInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public void Update(IntroInfo categoryInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(categoryInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@IntroId", SqlDbType.Int);
             paramId.Value = categoryInfo.IntroId;
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

