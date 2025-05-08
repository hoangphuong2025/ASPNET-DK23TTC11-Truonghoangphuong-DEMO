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
    public class CategoryController : BaseController<CategoryInfo>
    {
         public CategoryController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal CategoryController(string connectionString)
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE CategoryId=@CategoryId";
         private string SQL_DELETE = @"DELETE  FROM [tb_Category] WHERE CategoryId IN {0}";
         private string SQL_ALL_ROOT =      @"SELECT     
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE Code=-1 Order BY Indexs ASC";
         private string SQL_ALL_ROOT_GOMSU = @"SELECT     
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE ProductGroupId=3 AND Code=-1 Order BY Indexs ASC";
         
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
	                                        [Picture]
	                                        FROM [tb_Category]  Order BY Indexs ASC";
         private string SQL_ALL_ROOTSUB = @"SELECT     
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE Code!='-1' AND CodeSub=-1 ORDER BY Code ASC,NameVi ASC";
         private string SQL_ALL_ROOTSUBBYROOT = @"SELECT     
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE Code=@coderoot AND CodeSub=-1";
         private string SQL_ALL_ROOTSUBSUB = @"SELECT     
                                            [CategoryId] ,
	                                        [NameVi] ,
	                                        [NameEn] ,
	                                        [NameChi],
	                                        [Code],
//	                                        [Indexs],
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE Code!='-1' AND CodeSub!=-1";
         private string SQL_ALL_ROOTSUB_GOMSU = @"SELECT     
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
	                                        [Picture]
	                                        FROM [tb_Category] WHERE ProductGroupId=3 AND Code!='-1' AND CodeSub=-1";

         private string SQL_CREATE = @"Declare @CategoryId int; Declare @ERR int; 
                                     INSERT INTO [tb_Category]
                                           ([NameVi] ,
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
	                                        [Picture])
                                        VALUES(@NameVi,
	                                        @NameEn,
	                                        @NameChi,
	                                        @Code,
	                                        @Indexs,
	                                        @ShortDesVi,
	                                        @ShortDesEn,
	                                        @ShortDesChi,
	                                        @DescriptionVi,
	                                        @DescriptionEn,
	                                        @DescriptionChi,
	                                        @UserId,
	                                        @ProductGroupId,
	                                        @CompanyId,
	                                        @Edate,
	                                        @Mdate,
	                                        @CodeSub,
	                                        @Picture);
                                  SELECT @CategoryId=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Category]
                                       SET [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,
	                                        [NameChi]=@NameChi,
	                                        [Code]=@Code,
	                                        [Indexs]=@Indexs,
	                                        [ShortDesVi]=@ShortDesVi,
	                                        [ShortDesEn]=@ShortDesEn,
	                                        [ShortDesChi]=@ShortDesChi,
	                                        [DescriptionVi]=@DescriptionVi,
	                                        [DescriptionEn]=@DescriptionEn,
	                                        [DescriptionChi]=@DescriptionChi,
	                                        [UserId]=@UserId,
	                                        [ProductGroupId]=@ProductGroupId,
	                                        [CompanyId]=@CompanyId,	                                       
	                                        [Mdate]=@Mdate,
	                                        [CodeSub]=@CodeSub,
	                                        [Picture]=@Picture	                                     
                                     WHERE [CategoryId]=@CategoryId";
         private string SQL_ALL_SEARCH = @"SELECT     
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
	                                        [Picture] FROM [tb_Category] {0}";
         public void Insert(ref CategoryInfo categoryInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(categoryInfo, ref parms, false);
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
                 cmd.CommandText = strSQL.Append("SELECT @CategoryId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         categoryInfo.CategoryId = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public CategoryInfo GetById(int categoryid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@CategoryId", SqlDbType.Int);
                 param[0].Value = categoryid;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     CategoryInfo info = Row2Object(rdr);
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
         public List<CategoryInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_ALL_SEARCH, condition);
               // _logger.Info("Category Search :" + query);
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<CategoryInfo>();
             }
             return new List<CategoryInfo>();
         }
         public List<CategoryInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public List<CategoryInfo> GetAllRoot()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOT, null);
                 if (rdr!=null && rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (Exception ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
         public List<CategoryInfo> GetAllRootGomSu()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOT_GOMSU, null);
                 if (rdr != null && rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (Exception ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
         public List<CategoryInfo> GetAllSubSubWeb()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOTSUBSUB, null);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
         public List<CategoryInfo> GetAllSubWeb()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOTSUB, null);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
         public List<CategoryInfo> GetAllSubGomSu()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOTSUB_GOMSU, null);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
        public List<CategoryInfo> GetAllSubWeb(int categoryroot)
         {
             try
             {
                 SqlParameter paramId = new SqlParameter("@coderoot", SqlDbType.Int);
                 paramId.Value = categoryroot;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_ROOTSUBBYROOT, paramId);
                 if (rdr.HasRows)
                 {
                     List<CategoryInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return new List<CategoryInfo>();
             }
             return null;
         }
         public void Update(CategoryInfo categoryInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(categoryInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@CategoryId", SqlDbType.Int);
             paramId.Value = categoryInfo.CategoryId;
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
        //public static Logger _logger = LogManager.GetCurrentClassLogger();
        //public static string owndatabase = Util.getOwnDatabase();
        //private static string prequery_link = "CategoryID,Name_vi,Name_en,Name_chi,code,indexs,ShortDes_vi,ShortDes_en,ShortDes_chi, Description_vi,Description_en,Description_chi,UserID,ProductGroupID,CompanyID,Edate,Mdate,Code_Sub,Picture,GroupName_vi,GroupName_en,FullName,Code_SubFour";
        //private static string prequery_insert = "CategoryID,Name_vi,Name_en,Name_chi,code,indexs,ShortDes_vi,ShortDes_en,ShortDes_chi, Description_vi,Description_en,Description_chi,UserID,ProductGroupID,CompanyID,Edate,Mdate,Code_Sub,Picture,Code_SubFour";

        //private string SQL_DELETE = "DELETE FROM "+owndatabase+"[tb_category] WHERE CategoryID in{0}";

        //private string SQL_GETALL = "SELECT " + prequery_link + " FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid";

        //private string SQL_GETALLROOT = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE code=-1 AND  CompanyID=@companyid  ORDER  BY Indexs ASC, Name_vi ASC";
        //private string SQL_GETALLROOTBYALL = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE code=-1 AND  CompanyID=@companyid ORDER  BY Indexs ASC, Name_vi ASC";

        //private string SQL_GETALLBYALL = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE code=-1 AND  CompanyID=@companyid ORDER  BY Indexs ASC,ProductGroupID ASC,Name_vi ASC";

        //private string SQL_GETALLSEARCH= "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid {0}";

        //private string SQL_GETALLSEARCHTOP = "SELECT top 8 " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid {0}";


        //private string SQL_GETINFO = "SELECT  " + prequery_link + " FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND CategoryID=@id";
        //private string SQL_GETSUBALL = "SELECT " + prequery_link + "   FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid  AND Code!=-1 AND Code_sub=-1 Order by Code ASC, Indexs ASC";

        ////private string SQL_GETSUBALL = "SELECT " + prequery_link + "   FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND ProductGroupID=@productgroup AND Code!=-1 AND Code_sub=-1 Order by Code ASC, Indexs ASC";

        //private string SQL_GETSUBALL_SUB = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND ProductGroupID=@productgroupid AND Code !=-1 AND Code_sub !=-1 Order by Indexs ASC, Code ASC";
        //private string SQL_GETSUBALL_SUBNOPRODUCTGROUP = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code !=-1 AND Code_sub !=-1 AND  Code_SubFour=-1 Order by Code ASC,Code_Sub ASC,Indexs ASC";
        //private string SQL_GETSUBALL_SUBNOPRODUCTGROUPFOUR = "SELECT " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code !=-1 AND Code_sub !=-1 AND Code_SubFour !=-1  Order by Indexs ASC, Code ASC";

        //private string SQL_GETSUBALL_SUBBY_CODE = "SELECT   " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code_sub=@codesub AND Code_SubFour=-1 Order by Indexs ASC, Code_sub ASC";
        //private string SQL_GETSUBALL_SUBBY_CODEFOUR = "SELECT   " + prequery_link + "  FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code_SubFour=@codesubfour Order by Indexs ASC, Code_SubFour ASC";


        //private string SQL_GETSUBALLBYCATEGORYID = "SELECT " + prequery_link + " FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code=@code  AND Code_Sub=-1 AND Code_SubFour=-1 Order By Indexs ASC";
        //private string SQL_GETSUBALLBYCATEGORYIDFOUR = "SELECT " + prequery_link + " FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND Code !=-1 AND Code_sub=@codesub AND Code_SubFour=-1 Order By Indexs ASC";

        //private string SQL_GETSUBALLBYCATEGORYIDTOP = "SELECT top {0} " + prequery_link + " FROM " + owndatabase + "[view_allcategory] WHERE CompanyID=@companyid AND ProductGroupID=@productgroup  AND Code =@code AND Code !=-1 AND Code_Sub=-1 Order By Indexs ASC";

        ////private string SQL_GETSUBCATEGORYID = "select CategoryID,Name_vi,Name_en,code,indexs from category where code=@id";
        //private string SQL_INSERT = "INSERT INTO " + owndatabase + "[tb_category](" + prequery_insert + ")values(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19)";
        //private string SQL_MAX = "SELECT MAX(CategoryID) FROM " + owndatabase + "[tb_category]";
        //private string SQL_UPDATE = "UPDATE " + owndatabase + "[tb_category] set Name_vi=@1,Name_en=@2,Name_chi=@3,code=@4,indexs=@5,ShortDes_vi=@6,ShortDes_en=@7,ShortDes_chi=@8, Description_vi=@9,Description_en=@10,Description_chi=@11,UserID=@12,ProductGroupID=@13,CompanyID=@14,Mdate=@15,Code_Sub=@16,Picture=@17,Code_SubFour=@18 WHERE CategoryID=@0";
        //private string SQL_COPY = "Select CategoryID,Name_vi,Indexs from category where code=3";
        //private string SQL_COPYTOINSERT = "INSERT INTO " + owndatabase + "[tb_category](CategoryID,Name_vi,Code,indexs,ProductGroupID,CompanyID,Edate,Mdate,Code_Sub)values(@0,@1,@2,@3,@4,@5,@6,@7,@8)";

        //private static CategoryInfo createObjectCopy(SqlDataReader rdr)
        //{

        //    int id = Util.getInt32(rdr, 0);
        //    string name = Util.getString(rdr, 1);
        //    int index = Util.getInt32(rdr, 2);
        //    return new CategoryInfo(id,name,index);
        //}
        //private static CategoryInfo createObject(int stt, SqlDataReader rdr)
        //{
        //    CategoryInfo info = new CategoryInfo();
        //    info.Id = Util.getInt32(rdr, 0);
        //    info.Name_Vi = Util.getString(rdr, 1);
        //    info.Name_En = Util.getString(rdr, 2);
        //    info.Name_Chi = Util.getString(rdr, 3);
        //    info.Code = Util.getInt32(rdr, 4);
        //    info.Indexs = Util.getInt32(rdr, 5);
        //    info.ShortDes_vi = Util.getString(rdr, 6);
        //    info.ShortDes_en = Util.getString(rdr, 7);
        //    info.ShortDes_chi = Util.getString(rdr, 8);
        //    info.Description_vi = Util.getString(rdr, 9);
        //    info.Description_en = Util.getString(rdr, 10);
        //    info.Description_chi= Util.getString(rdr, 11);
        //    info.UserID = Util.getInt32(rdr, 12);
        //    info.ProductGroupID =Util.getInt32(rdr,13);
        //    info.CompanyID =Util.getInt32(rdr,14);
        //    //15;16,edate/mdate
        //    info.Code_Sub = Util.getInt32(rdr, 17);
        //    info.Picture = Util.getString(rdr, 18);
        //    info.GroupName_vi =Util.getString(rdr, 19);
        //    info.GroupName_en =Util.getString(rdr, 20);
        //    info.Stt = stt;
        //    return info;
        //}

        ////private static CategoryInfo createObject(string lang, SqlDataReader rdr)
        ////{
        ////    int num = Util.getInt32(rdr, 0);//categoryid
        ////    string name_vi = Util.getString(rdr, 1);//name_vi
        ////    string name_en = Util.getString(rdr, 2);//name_en
        ////    string name_chi = Util.getString(rdr, 3);//name_chi
        ////    int code = Util.getInt32(rdr, 4);//code
        ////    int indexs = Util.getInt32(rdr, 5);//indexs
        ////    string short_vi = Util.getString(rdr, 6);//short 
        ////    string short_en = Util.getString(rdr, 7);//short en
        ////    string short_chi = Util.getString(rdr, 8);//short chi
        ////    string des_vi = Util.getString(rdr, 9);//des 
        ////    string des_en = Util.getString(rdr, 10);//des en
        ////    string des_chi = Util.getString(rdr, 11);//des chi
        ////    int userid = Util.getInt32(rdr, 12);// userid
        ////    int productgroypid = Util.getInt32(rdr, 13);//productgroypid
        ////    int companyid = Util.getInt32(rdr, 14);//companyid
        ////    int code_sub = Util.getInt32(rdr, 17);
        ////    string picture = Util.getString(rdr, 18);
        ////    if (lang.Equals("vi"))
        ////    {
              
        ////       return new CategoryInfo(num, name_vi, short_vi, des_vi, code, indexs, userid, productgroypid, companyid, 1, code_sub, "#", picture);
        ////    }
        ////    if (lang.Equals("en"))
        ////    {
        ////        return new CategoryInfo(num, name_en, short_en, des_en, code, indexs, userid, productgroypid, companyid, 1, code_sub,"",picture);
        ////    }
        ////    return new CategoryInfo(num, name_chi, short_chi, des_chi, code, indexs, userid, productgroypid, companyid, 1, code_sub, "", picture);
        ////}

        ////private static CategoryInfo createObjectSub(string lang, SqlDataReader rdr)
        ////{
        ////    int num = Util.getInt32(rdr, 0);//categoryid
        ////    string name_vi = Util.getString(rdr, 1);//name_vi
        ////    string name_en = Util.getString(rdr, 2);//name_en
        ////    string name_chi = Util.getString(rdr, 3);//name_chi
        ////    int code = Util.getInt32(rdr, 4);//code
        ////    int indexs = Util.getInt32(rdr, 5);//indexs
        ////    string short_vi = Util.getString(rdr, 6);//short 
        ////    string short_en = Util.getString(rdr, 7);//short en
        ////    string short_chi = Util.getString(rdr, 8);//short chi
        ////    string des_vi = Util.getString(rdr, 9);//des 
        ////    string des_en = Util.getString(rdr, 10);//des en
        ////    string des_chi = Util.getString(rdr, 11);//des chi
        ////    int userid = Util.getInt32(rdr, 12);// userid
        ////    int productgroypid = Util.getInt32(rdr, 13);//productgroypid
        ////    int companyid = Util.getInt32(rdr, 14);//companyid
        ////    int code_sub = Util.getInt32(rdr, 17);
        ////    string picture = Util.getString(rdr, 18);//des chi
        ////    if (lang.Equals("vi"))
        ////    {
        ////        return new CategoryInfo(num, name_vi, short_vi, des_vi, code, indexs, userid, productgroypid, companyid, 1,code_sub,picture);
        ////    }
        ////    if (lang.Equals("en"))
        ////    {
        ////        return new CategoryInfo(num, name_en, short_en, des_en, code, indexs, userid, productgroypid, companyid, 1, code_sub,picture);
        ////    }
        ////    return new CategoryInfo(num, name_chi, short_chi, des_chi, code, indexs, userid, productgroypid, companyid, 1, code_sub,picture);
        ////}

        //public long delete(string scondition, string strconnection)
        //{
        //    return SqlHelper.updateData(string.Format(SQL_DELETE, scondition), strconnection);
        //}

        //public IList<CategoryInfo> getAll(string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALL, null);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAll(int companyid,string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALL, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllCopy(string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
          
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_COPY, null);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item =createObjectCopy(rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllRoot(int companyid, int productgroupid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@productgroup", SqlDbType.Int);
        //    commandParameters[1].Value = productgroupid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLROOT, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllRoot(int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;

        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLROOTBYALL, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllRoot(string lang,int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;

        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLROOTBYALL, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllByAll(string lang, int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLBYALL, commandParameters);
        //    try
        //    {
        //        if (rdr != null)
        //        {
        //            int count = 1;
        //            while (rdr.Read())
        //            {
        //                CategoryInfo item = createObject(count, rdr);
        //                item.FullName = Util.getString(rdr, 21);
        //                item.Code_SubFour = Util.getInt32(rdr, 22);
        //                list.Add(item);
        //                count++;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Info("Error getAllByAll:"+ex.Message);
                
        //    }
          
        //    return list;
        //}
        //public IList<CategoryInfo> getAllRoot(string lang, int companyid, int productgroupid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@productgroup", SqlDbType.Int);
        //    commandParameters[1].Value = productgroupid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLROOT, commandParameters);
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}

        //public IList<CategoryInfo> getAllRootLang(string lang,int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETALLROOT, commandParameters);
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}


        //public IList<CategoryInfo> getAllSubfour(string coderoot, int companyid, string strconnection)
        //{

        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@codesub", SqlDbType.Int);
        //    commandParameters[1].Value = coderoot;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALLBYCATEGORYIDFOUR, commandParameters);

        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSub(string coderoot, int companyid, string strconnection)
        //{
           
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@code", SqlDbType.Int);
        //    commandParameters[1].Value = coderoot;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALLBYCATEGORYID, commandParameters);
          
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSub(int top,string coderoot, int companyid, int sproductgroupid, string strconnection)
        //{
          
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[3];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@code", SqlDbType.Int);
        //    commandParameters[1].Value = coderoot;
        //    commandParameters[2] = new SqlParameter("@productgroup", SqlDbType.Int);
        //    commandParameters[2].Value = sproductgroupid;
        //    string query = string.Format(SQL_GETSUBALLBYCATEGORYIDTOP, top);
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, query,commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSub_Sub(string coderoot, int companyid, int sproductgroupid,int codesub, string strconnection)
        //{
            
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[4];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@code", SqlDbType.Int);
        //    commandParameters[1].Value = coderoot;
        //    commandParameters[2] = new SqlParameter("@productgroup", SqlDbType.Int);
        //    commandParameters[2].Value = sproductgroupid;
        //    commandParameters[3] = new SqlParameter("@codesub", SqlDbType.Int);
        //    commandParameters[3].Value = codesub;
           
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUBBY_CODE, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb(int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
           
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL, commandParameters);

        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb(int companyid, int productgroupid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@productgroup", SqlDbType.Int);
        //    commandParameters[1].Value = productgroupid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL, commandParameters);
          
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        ////update 17/100
        //public IList<CategoryInfo> getAllSubWeb_SubFour(int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUBNOPRODUCTGROUPFOUR, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb_Sub(int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUBNOPRODUCTGROUP, commandParameters);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb_Sub(int companyid, int productgroupid,string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@productgroupid", SqlDbType.Int);
        //    commandParameters[1].Value = productgroupid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUB, commandParameters);
            
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb_SubFour(string lang, int companyid,int codesubfour, string strconnection)
        //{
           
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@codesubfour", SqlDbType.Int);
        //    commandParameters[1].Value = codesubfour;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUBBY_CODEFOUR, commandParameters);
        //    _logger.Info("SQL_GETSUBALL_SUBBY_CODEFOUR :" + SQL_GETSUBALL_SUBBY_CODEFOUR);
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb_Sub(string lang,int companyid,int codesub,string strconnection)
        //{
           
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@codesub", SqlDbType.Int);
        //    commandParameters[1].Value = codesub;
            

        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL_SUBBY_CODE, commandParameters);
          
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(1,rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
                   
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSearchTop(string lang, int companyid, string condition, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    string query = string.Format(SQL_GETALLSEARCHTOP, condition);
         

        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, query, commandParameters);
        //    int count = 1;
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(count, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //            count++;
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSearch(string lang,int companyid,string condition, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[1];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    string query = string.Format(SQL_GETALLSEARCH, condition);
        //    _logger.Info("CATEGORY SEARCH companyid :" + companyid);
        //    _logger.Info("CATEGORY SEARCH :" + query);

        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, query, commandParameters);
        //    int count = 1;
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(count, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //            count++;
        //        }
        //    }
        //    return list;
        //}
        //public IList<CategoryInfo> getAllSubWeb(int companyid, string lang, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALL, null);
        //    ArrayList list2 = new ArrayList();
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            int code = item.Code;
        //            if ((list2.Count == 0) || (list2.IndexOf(code) < 0))
        //            {
        //                list2.Add(code);
        //                CategoryInfo info2 = getInfoCodeWeb(strconnection, code, lang);
        //                list.Add(info2);
        //                list.Add(item);
        //            }
        //            else if (list2.IndexOf(code) >= 0)
        //            {
        //                list.Add(item);
        //            }
        //        }
        //    }
        //    return list;
        //}

        //public IList<CategoryInfo> getAllSubWeb(int coderoot, int companyid, string lang, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@code", SqlDbType.Int);
        //    commandParameters[1].Value = coderoot;
         
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETSUBALLBYCATEGORYID, commandParameters);
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}
   
        //public IList<CategoryInfo> getInfo(int newsid, int companyid, string strconnection)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter[] commandParameters = new SqlParameter[2];
        //    commandParameters[0] = new SqlParameter("@companyid", SqlDbType.Int);
        //    commandParameters[0].Value = companyid;
        //    commandParameters[1] = new SqlParameter("@id", SqlDbType.Int);
        //    commandParameters[1].Value = newsid;
           
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETINFO, commandParameters);
        //    if(rdr==null)
        //    {
                
        //    }
        //    else
        //    {
        //        int count = 1;
        //        while(rdr.Read())
        //        {
        //            CategoryInfo item = createObject(count, rdr);
        //            item.FullName = Util.getString(rdr, 21);
        //            item.Code_SubFour = Util.getInt32(rdr, 22);
        //            list.Add(item);
        //            count++;
        //        }
        //    }
        //    return list;
        //}

        //public CategoryInfo getInfoCode(string strconnection, int newsid)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
        //    parameter.Value = newsid;
            
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETINFO, new SqlParameter[] { parameter });
        //    if (rdr != null)
        //    {
        //        for (int i = 1; rdr.Read(); i++)
        //        {
        //            CategoryInfo item = createObject(i, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list[0];
        //}

        //public CategoryInfo getInfoCodeWeb(string strconnection, int newsid, string lang)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
        //    parameter.Value = newsid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETINFO, new SqlParameter[] { parameter });
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list[0];
        //}

        //public IList<CategoryInfo> getInfoWeb(string lang, string strconnection, int newsid)
        //{
        //    IList<CategoryInfo> list = new List<CategoryInfo>();
        //    SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
        //    parameter.Value = newsid;
        //    SqlDataReader rdr = SqlHelper.ExecuteReader(strconnection, CommandType.Text, SQL_GETINFO, new SqlParameter[] { parameter });
        //    if (rdr != null)
        //    {
        //        while (rdr.Read())
        //        {
        //            CategoryInfo item = createObject(1, rdr);
        //            list.Add(item);
        //        }
        //    }
        //    return list;
        //}

        //public int getMax(string strconnetion)
        //{
        //    int num = 1;
        //    try
        //    {
        //        SqlDataReader reader = SqlHelper.ExecuteReader(strconnetion, CommandType.Text, SQL_MAX, null);
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                object obj2 = reader.GetValue(0);
        //                reader.IsDBNull(0);
        //                if (obj2 == null)
        //                {
        //                    return 1;
        //                }
        //                return (num = reader.GetInt32(0) + 1);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        return num;
        //    }
        //    return num;
        //}

        //public long insert(ArrayList vparam, string strconnection)
        //{
        //    return SqlHelper.updateData(SQL_INSERT, vparam, strconnection);
        //}
        //public long insertDes(ArrayList vparam, string connection)
        //{
        //    return SqlHelper.updateData(SQL_COPYTOINSERT, vparam, connection);
        //}
        //public long insert(string name_vi, string name_en, string strconnection)
        //{
        //    ArrayList param = new ArrayList();
        //    param.Add(getMax(strconnection));
        //    param.Add(name_vi);
        //    param.Add(name_en);
        //    return SqlHelper.updateData(SQL_INSERT, param, strconnection);
        //}

        //public long update(ArrayList vparam, string strconnection)
        //{
        //    return SqlHelper.updateData(SQL_UPDATE, vparam, strconnection);
        //}

        //public long update(int id, string name_vi, string name_en, string strconnection)
        //{
        //    ArrayList param = new ArrayList();
        //    param.Add(id);
        //    param.Add(name_vi);
        //    param.Add(name_en);
        //    return SqlHelper.updateData(SQL_UPDATE, param, strconnection);
        //}
        
    }
}

