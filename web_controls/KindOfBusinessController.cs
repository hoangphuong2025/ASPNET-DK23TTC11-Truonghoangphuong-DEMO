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
    public class KindOfBusinessController : BaseController<KindOfBusinessInfo>
    {
        public KindOfBusinessController()
            : base("")
        {
            connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
        }

        internal KindOfBusinessController(string connectionString)
            : base(connectionString)
        {
        }

        private string SQL_SELECT_BYID = @"SELECT     
                                            [Id],
                                            [CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                      
	                                        [Indexs]
	                                        FROM [tb_KindofBusiness] WHERE Id=@Id";
        private string SQL_DELETE = @"DELETE  FROM [tb_KindofBusiness] WHERE Id IN {0}";
        private string SQL_ALL    = @"SELECT     
                                        [Id],
                                        [CompanyId],
	                                    [NameVi],
	                                    [NameEn],	                                      
	                                    [Indexs] FROM [tb_KindofBusiness] Order BY Indexs ASC";
     
        private string SQL_CREATE = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_KindofBusiness]
                                           ([CompanyId],
	                                        [NameVi],
	                                        [NameEn],	                                      
	                                        [Indexs])
                                        VALUES(@CompanyId,
	                                        @NameVi,
	                                        @NameEn,	                                     
	                                        @Indexs);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
        private string SQL_UPDATE_BY_ID = @"UPDATE [tb_KindofBusiness]
                                       SET  [NameVi]=@NameVi,
	                                        [NameEn]=@NameEn,	                                        
	                                        [Indexs]=@Indexs	                                                                             
                                      WHERE [Id]=@Id";
        
        public void Insert(ref KindOfBusinessInfo categoryInfo)
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
        public KindOfBusinessInfo GetById(int id)
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = id;

                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                if (rdr.HasRows)
                {
                    KindOfBusinessInfo info = Row2Object(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
     
        public List<KindOfBusinessInfo> GetAll()
        {
            try
            {
                SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                if (rdr.HasRows)
                {
                    List<KindOfBusinessInfo> info = Rows2Objects(rdr);
                    return info;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return null;
        }
        
        public void Update(KindOfBusinessInfo kindOfBusinessInfo)
        {
            StringBuilder strSQL = new StringBuilder();

            List<SqlParameter> parms = new List<SqlParameter>();
            Object2Row(kindOfBusinessInfo, ref parms, false);
            SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
            paramId.Value = kindOfBusinessInfo.Id;
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
