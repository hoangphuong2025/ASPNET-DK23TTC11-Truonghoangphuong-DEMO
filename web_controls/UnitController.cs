using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using web_connection;
using web_controls.Base;
using web_model;

namespace food_controls
{
    public class UnitController : BaseController<UnitsInfo>
    {
         public UnitController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal UnitController(string connectionString)
              : base(connectionString)
          {
          }
         private string SQL_SELECT_BYID = @"SELECT     
                                             [Id]
                                            ,[Name]
                                            ,[Quantity]
                                            ,[CompanyId] FROM [tb_Units] WHERE Id=@Id";
         private string SQL_SELECT_ALL = @"SELECT     
                                             [Id]
                                            ,[Name]
                                            ,[Quantity]
                                            ,[CompanyId] FROM [tb_Units] Order By Name ASC";
         private string SQL_INSERT = @"Declare @Id int; Declare @ERR int; 
                                     INSERT INTO [tb_Units]
                                           ([Name]
                                            ,[Quantity]
                                            ,[CompanyId])
                                        VALUES(@Name,
	                                        @Quantity,
	                                        @CompanyId);
                                  SELECT @Id=@@IDENTITY; SELECT @ERR=@@ERROR;";
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Units]
                                        SET [Name]=@Name,
	                                        [Quantity]=@Quantity	                                       
                                     WHERE [Id]=@Id";
         private string SQL_DELETE = @"DELETE FROM [tb_Units] WHERE  Id IN {0}";
         public void Insert(ref UnitsInfo unitsInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(unitsInfo, ref parms, false);
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
                         unitsInfo.Id = rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public void Update(UnitsInfo unitsInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(unitsInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@Id", SqlDbType.Int);
             paramId.Value = unitsInfo.Id;
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
         public List<UnitsInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_ALL,null);
                 if (rdr.HasRows)
                 {
                     return  Rows2Objects(rdr);
                    
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public UnitsInfo GetById(int unitid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@Id", SqlDbType.Int);
                 param[0].Value = unitid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     UnitsInfo info = Row2Object(rdr);
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
