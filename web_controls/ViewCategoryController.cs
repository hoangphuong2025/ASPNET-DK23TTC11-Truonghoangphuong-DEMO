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
    public class ViewCategoryController : BaseController<ViewCategoryInfo>
    {
         public ViewCategoryController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal ViewCategoryController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                            [CategoryId] ,
	                                        [NameVi] ,
	                                        [NameEn] ,
	                                        [NameChi],
	                                        [Code],
	                                        [Indexs],
	                                        [ShortDesVi],
	                                        [ShortDesEn],
	                                        [ShortDesChi],
	                                        [DescriptionVi],
	                                        [DescriptionEn],
	                                        [DescriptionChi],
	                                        [UserId],
	                                        [ProductGroupId],
	                                        [CompanyId],
	                                        [Edate],
	                                        [Mdate],
	                                        [CodeSub],
	                                        [Picture],
                                            [RootVi],
                                            [RootEn]
	                                        FROM [view_title] WHERE CategoryId=@CategoryId";
         private string SQL_ALL = @"SELECT     
                                            [CategoryId] ,
	                                        [NameVi] ,
	                                        [NameEn] ,
	                                        [NameChi],
	                                        [Code],
	                                        [Indexs],
	                                        [ShortDesVi],
	                                        [ShortDesEn],
	                                        [ShortDesChi],
	                                        [DescriptionVi],
	                                        [DescriptionEn],
	                                        [DescriptionChi],
	                                        [UserId],
	                                        [ProductGroupId],
	                                        [CompanyId],
	                                        [Edate],
	                                        [Mdate],
	                                        [CodeSub],
	                                        
                                            [Picture],
                                            [RootVi],
                                            [RootEn]
	                                        FROM [view_title]  Order BY Indexs ASC";

         private string SQL_SEARCH = @"SELECT     
                                            [CategoryId] ,
	                                        [NameVi] ,
	                                        [NameEn] ,
	                                        [NameChi],
	                                        [Code],
	                                        [Indexs],
	                                        [ShortDesVi],
	                                        [ShortDesEn],
	                                        [ShortDesChi],
	                                        [DescriptionVi],
	                                        [DescriptionEn],
	                                        [DescriptionChi],
	                                        [UserId],
	                                        [ProductGroupId],
	                                        [CompanyId],
	                                        [Edate],
	                                        [Mdate],
	                                        [CodeSub],	                                        
                                            [Picture],
                                            [RootVi],
                                            [RootEn]
	                                        FROM [view_title]  Order BY Indexs ASC";
         public ViewCategoryInfo GetById(int categoryid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@CategoryId", SqlDbType.Int);
                 param[0].Value = categoryid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     ViewCategoryInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 _logger.Info("Error GetById CategoryInfo:"+ex.Message);
                 return null;
             }
             return null;
         }
         public List<ViewCategoryInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_SEARCH, condition);
         
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     return  Rows2Objects(rdr);
                     
                 }
             }
             catch (SqlException ex)
             {
                 return new List<ViewCategoryInfo>();
             }
             return null;
         }
         public List<ViewCategoryInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
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
        
        
        
    }
}

