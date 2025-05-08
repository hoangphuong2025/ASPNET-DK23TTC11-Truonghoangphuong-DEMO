using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using web_connection;
using web_controls.Base;
using web_model;


namespace web_controls
{
    public class ViewMenuRightController : BaseController<ViewMenuRightInfo>
    {
       
         public ViewMenuRightController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal ViewMenuRightController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_ALL          = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
                                            [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] Order by Indexs ASC";
         private string SQL_ALL_MAIN_ID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] WHERE MainId=@MainId AND StatusId=@StatusId Order By Indexs ASC";
         private string SQL_ALL_MAIN_USER = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] WHERE MainId=@MainId AND UserId=@UserId AND StatusId=@StatusId Order By Indexs ASC";
         private string SQL_ALL_SUB_ID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
                                            [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] WHERE MainId=@MainId AND SubId=@SubId order by Indexs ASC";

         private string SQL_SELECT_BY_ID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
                                            [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] WHERE UserRightId=@UserRightId Order by Indexs ASC";
         private string SQL_SELECT_BY_USER_ID = @"SELECT   
                                            [UserRightId],    
                                            [UserId] ,
	                                        [MainId] ,
	                                        [SubId],
	                                        [Indexs],	                                   
	                                        [CompanyId],
	                                        [StatusId],
                                            [NameVi],
                                            [NameEn],
                                            [Url],
                                            [Target]
                                            FROM [view_menuright] WHERE UserId=@UserId Order by Indexs ASC";

         public ViewMenuRightInfo GetById(int _userrightId)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserRightId", SqlDbType.Int);
                 param[0].Value = _userrightId;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_ID, param);
                 if (rdr.HasRows)
                 {
                     ViewMenuRightInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ViewMenuRightInfo> GetAllMainId(int mainid, int statusId,int userid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[3];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = mainid;

                 param[1] = new SqlParameter("@StatusId", SqlDbType.Int);
                 param[1].Value = statusId;

                 param[2] = new SqlParameter("@UserId", SqlDbType.Int);
                 param[2].Value = userid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_MAIN_USER, param);
                 if (rdr.HasRows)
                 {
                     List<ViewMenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ViewMenuRightInfo> GetAllMainId(int mainid,int statusId)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[2];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = mainid;

                 param[1] = new SqlParameter("@StatusId", SqlDbType.Int);
                 param[1].Value = statusId;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_MAIN_ID, param);
                 if (rdr.HasRows)
                 {
                     List<ViewMenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }

         public List<ViewMenuRightInfo> GetAllSubId(int mainid,int subid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[2];
                 param[0] = new SqlParameter("@MainId", SqlDbType.Int);
                 param[0].Value = mainid;
                 param[1] = new SqlParameter("@SubId", SqlDbType.Int);
                 param[1].Value = subid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_SUB_ID, param);
                 if (rdr.HasRows)
                 {
                     List<ViewMenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<ViewMenuRightInfo> GetAllUserId(int userid)
         {
             try
             {
                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserId", SqlDbType.Int);
                 param[0].Value = userid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_USER_ID, param);
                 if (rdr.HasRows)
                 {
                     List<ViewMenuRightInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
   

    }
}
