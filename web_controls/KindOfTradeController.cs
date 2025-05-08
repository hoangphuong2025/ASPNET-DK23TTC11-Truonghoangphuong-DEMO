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
    public class KindOfTradeController : BaseController<KindOfTradeInfo>
    {
        public KindOfTradeController()
            : base("")
        {
            connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        }

        internal KindOfTradeController(string connectionString)
            : base(connectionString)
        {
        }

        private string SQL_SELECT_BYID = @"SELECT     
                                             [Id]
                                            ,[CompanyId]
                                            ,[NameVi]
                                            ,[NameEn]
                                            ,[Indexs]
                                            ,[ShortDesVi]
                                            ,[ShortDesEn]
                                            ,[DesVi]
                                            ,[DesEn]
                                            ,[ColorCode]     
                                            ,[IconImg] 
                                            ,[Picture] 
	                                        FROM [tb_KindofTrade] WHERE Id=@Id";
        private string SQL_DELETE = @"DELETE  FROM [tb_KindofTrade] WHERE Id IN {0}";
        private string SQL_ALL    = @"SELECT     
                                         [Id]
                                        ,[CompanyId]
                                        ,[NameVi]
                                        ,[NameEn]
                                        ,[Indexs]
                                        ,[ShortDesVi]
                                        ,[ShortDesEn]
                                        ,[DesVi]
                                        ,[DesEn]
                                        ,[ColorCode]     
                                        ,[IconImg] 
                                        ,[Picture]                                 
	                                    FROM [tb_KindofTrade] Order BY Indexs ASC";
        private string SQL_SEARCH = @"SELECT     
                                         [Id]
                                        ,[CompanyId]
                                        ,[NameVi]
                                        ,[NameEn]
                                        ,[Indexs]
                                        ,[ShortDesVi]
                                        ,[ShortDesEn]
                                        ,[DesVi]
                                        ,[DesEn]	                                        
                                        ,[ColorCode]     
                                        ,[IconImg] 
                                        ,[Picture]                              
	                                    FROM [tb_KindofTrade] {0}";
        private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_KindofTrade]
                                           ([CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                      
	                                        [Indexs],
                                            [ShortDesVi],
                                            [ShortDesEn],
                                            [DesVi],
                                            [DesEn],
                                            [ColorCode],
                                            [IconImg],[Picture])
                                        VALUES(@CompanyId,
	                                        @NameVi,
	                                        @NameEn,	                                     
	                                        @Indexs,
	                                        @ShortDesVi,
	                                        @ShortDesEn,
	                                        @DesVi,
                                            @DesEn,
                                            @ColorCode,@IconImg,@Picture);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
        private string SQL_UPDATE_BY_ID = @"UPDATE [tb_KindofTrade]
                                       SET  [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                        
	                                        [Indexs]=@Indexs,
	                                        [ShortDesVi]=@ShortDesVi,
	                                        [ShortDesEn]=@ShortDesEn,
	                                        [DesVi]=@DesVi,
	                                        [DesEn]=@DesEn,
	                                        [ColorCode]=@ColorCode,
                                            [IconImg]=@IconImg,
                                            [Picture]=@Picture
                                      WHERE [Id]=@Id";
        
        public void Insert(ref KindOfTradeInfo categoryInfo)
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
                        categoryInfo.Id = rdr.GetInt32(0);
                }
                //Clear the parameters
                cmd.Parameters.Clear();
            }
        }
        public KindOfTradeInfo GetById(int id)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                if (rdr.HasRows)
                {
                    KindOfTradeInfo info = Row2Object(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        public List<KindOfTradeInfo> GetSearch(string condition)
        {
            try
            {
                string squery = string.Format(SQL_SEARCH, condition);
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, squery, null);
                if (rdr.HasRows)
                {
                    List<KindOfTradeInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
               return new List<KindOfTradeInfo>();
            }
            return null;
        }
        public List<KindOfTradeInfo> GetAll()
        {
            try
            {
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                if (rdr.HasRows)
                {
                    List<KindOfTradeInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        
        public void Update(KindOfTradeInfo KindOfTradeInfo)
        {
            StringBuilder strSQL = new StringBuilder();

            List<SqlParameter> parms = new List<SqlParameter>();
            Object2Row(KindOfTradeInfo, ref parms, false);
            SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
            paramId.Value = KindOfTradeInfo.Id;
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
