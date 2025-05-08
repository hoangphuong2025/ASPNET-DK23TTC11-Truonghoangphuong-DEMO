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
    public class ProductController : BaseController<ProductInfo>
    {
       static private 
                string SQuerySelect = "[Id],[UserId],[NameVi],[NameEn],[NameChi],[Price],"+
	                                  "[PriceSales],[Edate],[Mdate],[CategoryId],[SubCategoryId],"+
	                                  "[BrunchId],[UnitId],[Weight],[ProductGroupId],[ProductCode],"+
	                                  "[StatusId],[ServiceProviderId],[ShortDesVi],[ShortDesEn],[ShortDesChi],"+
	                                  "[DescriptionVi],[DescriptionEn],[DescriptionChi],[CompanyId],[StoreId],"+
	                                  "[Indexs],[Picture],[SubCategorySubId],[StyleId],[TypeId],[ColorId]," +
                                      "[DescriptionGuide],[DescriptionVideo],[CodeColor],[PictureColor]," +
                                      "[SpecificationVi],[SpecificationEn],"+
                                      "[AccesoriesVi],[AccesoriesEn]";
       public ProductController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

        internal ProductController(string connectionString)
              : base(connectionString)
          {
          }
        private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_Product]
                                           ([UserId],[NameVi],[NameEn],[NameChi],[Price],[PriceSales],[Edate],[Mdate],
	                                        [CategoryId],[SubCategoryId],[BrunchId],[UnitId],[Weight],[ProductGroupId],
	                                        [ProductCode],[StatusId],[ServiceProviderId],
	                                        [ShortDesVi],[ShortDesEn],[ShortDesChi],[DescriptionVi],
	                                        [DescriptionEn],[DescriptionChi],[CompanyId],[StoreId],
	                                        [Indexs],[Picture],[SubCategorySubId],[StyleId],[TypeId],[ColorId],[DescriptionGuide],
	                                        [DescriptionVideo],[CodeColor],[PictureColor],
                                            [SpecificationVi],[SpecificationEn],[AccesoriesVi],[AccesoriesEn])
                                        VALUES(@UserId,@NameVi,@NameEn, @NameChi,
	                                        @Price,@PriceSales, @Edate,@Mdate,@CategoryId,@SubCategoryId,@BrunchId,
	                                        @UnitId,@Weight,@ProductGroupId,@ProductCode,
                                            @StatusId,@ServiceProviderId,@ShortDesVi,@ShortDesEn,@ShortDesChi,
	                                        @DescriptionVi,@DescriptionEn,@DescriptionChi,@CompanyId,@StoreId,@Indexs,@Picture,
                                            @SubCategorySubId,@StyleId, @TypeId,@ColorId,@DescriptionGuide,
                                            @DescriptionVideo,@CodeColor,@PictureColor, @SpecificationVi,
                                            @SpecificationEn,@AccesoriesVi, @AccesoriesEn);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
        private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Product]
                                        SET [UserId]=@UserId,[NameVi]=@NameVi,[NameEn]=@NameEn,[NameChi]=@NameChi,
	                                        [Price]=@Price,[PriceSales]=@PriceSales,[Edate]=@Edate,[Mdate]=@Mdate,
                                            [CategoryId]=@CategoryId,[SubCategoryId]=@SubCategoryId,
	                                        [BrunchId]=@BrunchId,[UnitId]=@UnitId,
	                                        [Weight]=@Weight,[ProductGroupId]=@ProductGroupId,
	                                        [ProductCode]=@ProductCode],[StatusId]=@StatusId,
	                                        [ServiceProviderId]=@ServiceProviderId,[ShortDesVi]=@ShortDesVi,
	                                        [ShortDesEn]=@ShortDesEn,[ShortDesChi]=@ShortDesChi,
	                                        [DescriptionVi]=@DescriptionVi,[DescriptionEn]=@DescriptionEn,
	                                        [DescriptionChi]=@DescriptionChi,[CompanyId]=@CompanyId,
	                                        [StoreId]=@StoreId,[Indexs]=@Indexs,[Picture]=@Picture,
                                            [SubCategorySubId]=@SubCategorySubId,[StyleId]=@StyleId,[TypeId]=@TypeId,	                                      
	                                        [ColorId]=@ColorId,[DescriptionGuide]=@DescriptionGuide,
	                                        [DescriptionVideo]=@DescriptionVideo,[CodeColor]=@CodeColor,
                                            [PictureColor]=@PictureColor , [SpecificationVi]=@SpecificationVi,
                                            [SpecificationEn]=@SpecificationEn,[AccesoriesVi]=@Accesoriesvi,
                                            [AccesoriesEn]=@AccesoriesEn WHERE Id=@Id";
                                          
        private string SQL_SELECT_BYID = @"SELECT " + SQuerySelect + " FROM [tb_Product] WHERE Id=@Id";
        private string SQL_SELECT_SEARCH = @"SELECT  "   + SQuerySelect + " FROM [tb_Product] {0}";
        private string SQL_SELECT_SEARCH_TOP = @"SELECT  Top 8" + SQuerySelect + " FROM [tb_Product] {0}";
        private string SQL_SELECT_SEARCH_WEB = @"SELECT "+ SQuerySelect +" FROM [view_allproductweb] {0}";
        private string SQL_SELECT_BYIDOTHER = @"SELECT  "+ SQuerySelect +" FROM [tb_Product] WHERE Id!=@Id {0}";
        private string SQL_SELECT_ALL = @"SELECT  "+ SQuerySelect +" FROM [tb_Product] Order by Mdate DESC, NameVi ASC";
        private string SQL_SELECT_ALL_SEARCH = @"SELECT "+ SQuerySelect +" FROM [tb_Product] {0}";
        private string SQL_SELECT_ALL_SEARCH_TOP = @"SELECT  {0}   "+ SQuerySelect +" FROM [tb_Product] {1}";
        private string SQL_SELECT_ALL_WEB = @"SELECT  "+ SQuerySelect +" FROM [tb_Product] WHERE [StatusId] not like '0' Order by Mdate DESC, NameVi ASC";
        private string SQL_DELETE   = @"DELETE  FROM [tb_Product] WHERE Id in {0}";
        private string SQL_DELETEALL = @"DELETE FROM [tb_Product] {0}";
        private string SQL_SELECT_BY_CATEGORYID = @"SELECT    "+ SQuerySelect +" FROM [tb_Product] WHERE CategoryId=@CategoryId";
        private string SQL_TOP_SELECT_BY_CATEGORYID = @"SELECT {0}   " + SQuerySelect + "   FROM [tb_Product] WHERE CategoryId=@CategoryId";
             private string SQL_SELECT_BY_LISTPRICE = @"SELECT   "+ SQuerySelect+" FROM [tb_Product] WHERE StyleId=@StyleId AND StatusId Not like '%0%'";
        private string SQL_SELECT_BY_SUBCATEGORYID = @"SELECT "+ SQuerySelect+" FROM [tb_Product] WHERE SubCategoryId=@SubCategoryId";
        private string SQL_SELECT_BY_SUBCATEGORYID_SUB = @"SELECT   "+ SQuerySelect+" FROM [tb_Product] WHERE SubCategorySubId=@SubCategorySubId";
        private string SQL_SELECT_BY_ROOT_SUB = @"SELECT "+ SQuerySelect+ "  FROM [tb_Product] WHERE CategoryId=@CategoryId AND SubCategoryId=@SubCategoryId";

        public void Insert(ref ProductInfo productInfo)
        {
            StringBuilder strSQL = new StringBuilder();

            List<SqlParameter> parms = new List<SqlParameter>();
            Object2Row(productInfo, ref parms, false);
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
                        productInfo.Id = rdr.GetInt32(0);
                       
                }
                //Clear the parameters
                cmd.Parameters.Clear();
            }
        }
        public void Update(ProductInfo productInfo)
        {
            StringBuilder strSQL = new StringBuilder();
            List<SqlParameter> parms = new List<SqlParameter>();
            Object2Row(productInfo, ref parms, false);
            SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
            paramId.Value = productInfo.Id;
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
        public long DeleteAll(string companyid)
        {
            string query = string.Format(SQL_DELETEALL, companyid);
            return SqlHelper.updateData(query, connectionString);
        }
        public List<ProductInfo> GetByIdother(int id,string condition)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;
                string query = string.Format(SQL_SELECT_BYIDOTHER, condition);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query, param);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        public ProductInfo GetById(int id)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                if (rdr.HasRows)
                {
                    ProductInfo info = Row2Object(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        public List<ProductInfo> GetBySearchTop(string condition)
        {
            try
            {

                string query = string.Format(SQL_SELECT_SEARCH_TOP, condition);
                //  _logger.Info("search .............product:"+query);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, null);
                if (rdr != null && rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               // _logger.Info(ex.Message);
                return new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetBySearch(string condition)
        {
            try
            {
                string query = string.Format(SQL_SELECT_SEARCH, condition);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,
                     query, null);
                if (rdr!=null&&rdr.HasRows)
                {
                   return  Rows2Objects(rdr);
                }
            }
            catch (SqlException ex){               
                return new List<ProductInfo>();
            }
            return new List<ProductInfo>();
        }

        public List<ProductInfo> GetBySearchWeb(string condition)
        {
            try
            {

                string query = string.Format(SQL_SELECT_SEARCH_WEB, condition);
             
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, null);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               return new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetByCategoryId(int categoryid)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryId", SqlDbType.Int);
                param[0].Value = categoryid;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_CATEGORYID, param);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                return  new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetTopByCategoryId(int top,int categoryid)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@CategoryId", SqlDbType.Int);
                param[0].Value = categoryid;
                string query = string.Format(SQL_TOP_SELECT_BY_CATEGORYID, " top " + top);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, param);
                if (rdr!=null&&rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                return new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetBySubCategoryId(int categoryid)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SubCategoryId", SqlDbType.Int);
                param[0].Value = categoryid;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_SUBCATEGORYID, param);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               return new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetBySubSubCategoryId(int categoryid)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@SubCategorySubId", SqlDbType.Int);
                param[0].Value = categoryid;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_SUBCATEGORYID_SUB, param);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               return new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetAll()
        {
            try
            {
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_ALL, null);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               return  new List<ProductInfo>();
            }
            return null;
        }
        public List<ProductInfo> GetAllSearch(string condition)
        {
            try
            {
                string query = string.Format(SQL_SELECT_ALL_SEARCH, condition);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, null);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                return new List<ProductInfo>();
            }
            return new List<ProductInfo>();
        }
        public List<ProductInfo> GetAllSearchTop(string top,string condition)
        {
            try
            {
                string query = string.Format(SQL_SELECT_ALL_SEARCH_TOP,top, condition);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, query, null);
                if (rdr.HasRows)
                {
                    List<ProductInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        //public List<ProductInfo> GetAllWeb()
        //{
           
        //    try
        //    {
        //        SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_ALL_WEB, null);
        //        if (rdr.HasRows)
        //        {
        //            List<ProductInfo> info = Rows2Objects(rdr);
        //            return info;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    return null;
        //}
        //public List<ProductInfo> GetByListPrice(int pricelistid)
        //{
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[1];
        //        param[0] = new SqlParameter("@StyleId", SqlDbType.Int);
        //        param[0].Value = pricelistid;
        //        SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BY_LISTPRICE, param);
        //        if (rdr.HasRows)
        //        {
        //            List<ProductInfo> info = Rows2Objects(rdr);
        //            return info;
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }
        //    return null;
        //}
    }
}


