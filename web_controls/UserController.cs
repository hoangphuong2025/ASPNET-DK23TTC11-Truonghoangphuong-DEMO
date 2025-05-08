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
    public class UserController : BaseController<UsersInfo>
    {
         public UserController():base("")
          {
              connectionString = ConfigurationManager.ConnectionStrings["strConnection"].ConnectionString;
          }

         internal UserController(string connectionString)
              : base(connectionString)
          {
          }

         private string SQL_SELECT_BYID = @"SELECT     
                                               [UserId]
                                              ,[Name]
                                              ,[UserLogin]
                                              ,[UserPass]
                                              ,[UserKindOfId]
                                              ,[UserStatusId]
                                              ,[Edate]
                                              ,[Mdate]
                                              ,[NickChat]
                                              ,[Tel]
                                              ,[Address]
                                              ,[KindofBusinessId]
                                              ,[Confirms]
                                              ,[CodeUserId]
                                              ,[CompanyId]
                                              ,[Picture]
                                              ,[NickSkyper]
	                                        FROM [tb_Users] WHERE UserId=@UserId";

         private string SQL_CHECK_LOGIN = @"SELECT     
                                               [UserId]
                                              ,[Name]
                                              ,[UserLogin]
                                              ,[UserPass]
                                              ,[UserKindOfId]
                                              ,[UserStatusId]
                                              ,[Edate]
                                              ,[Mdate]
                                              ,[NickChat]
                                              ,[Tel]
                                              ,[Address]
                                              ,[KindofBusinessId]
                                              ,[Confirms]
                                              ,[CodeUserId]
                                              ,[CompanyId]
                                              ,[Picture]
                                              ,[NickSkyper]
	                                        FROM [tb_Users] WHERE UserLogin=@UserLogin AND UserPass=@UserPass";
         private string SQL_CHECK_USEREXIST = @"SELECT     
                                               [UserId]
                                              ,[Name]
                                              ,[UserLogin]
                                              ,[UserPass]
                                              ,[UserKindOfId]
                                              ,[UserStatusId]
                                              ,[Edate]
                                              ,[Mdate]
                                              ,[NickChat]
                                              ,[Tel]
                                              ,[Address]
                                              ,[KindofBusinessId]
                                              ,[Confirms]
                                              ,[CodeUserId]
                                              ,[CompanyId]
                                              ,[Picture]
                                              ,[NickSkyper]
	                                        FROM [tb_Users] WHERE UserLogin=@UserLogin";
         private string SQL_DELETE = @"DELETE  FROM [tb_Users] WHERE UserId IN {0}";
         private string SQL_ALL = @"SELECT     
                                     [UserId]
                                    ,[Name]
                                    ,[UserLogin]
                                    ,[UserPass]
                                    ,[UserKindOfId]
                                    ,[UserStatusId]
                                    ,[Edate]
                                    ,[Mdate]
                                    ,[NickChat]
                                    ,[Tel]
                                    ,[Address]
                                    ,[KindofBusinessId]
                                    ,[Confirms]
                                    ,[CodeUserId]
                                    ,[CompanyId]
                                    ,[Picture]
                                    ,[NickSkyper]
	                                FROM [tb_Users] Order BY Name ASC";
         private string SQL_ALL_COMPANYID = @"SELECT     
                                     [UserId]
                                    ,[Name]
                                    ,[UserLogin]
                                    ,[UserPass]
                                    ,[UserKindOfId]
                                    ,[UserStatusId]
                                    ,[Edate]
                                    ,[Mdate]
                                    ,[NickChat]
                                    ,[Tel]
                                    ,[Address]
                                    ,[KindofBusinessId]
                                    ,[Confirms]
                                    ,[CodeUserId]
                                    ,[CompanyId]
                                    ,[Picture]
                                    ,[NickSkyper]
	                                FROM [tb_Users] Where [CompanyId]=@CompanyId Order BY Name ASC";

         private string SQL_LIVECONTACT = @"SELECT     
                                     [UserId]
                                    ,[Name]
                                    ,[UserLogin]
                                    ,[UserPass]
                                    ,[UserKindOfId]
                                    ,[UserStatusId]
                                    ,[Edate]
                                    ,[Mdate]
                                    ,[NickChat]
                                    ,[Tel]
                                    ,[Address]
                                    ,[KindofBusinessId]
                                    ,[Confirms]
                                    ,[CodeUserId]
                                    ,[CompanyId]
                                    ,[Picture]
                                    ,[NickSkyper]
	                                FROM [tb_Users] Where UserId !=CodeUserId AND UserStatusId>0 Order BY Name ASC";
         private string SQL_CATEGORYUSER = @"SELECT     
                                     [UserId]
                                    ,[Name]
                                    ,[UserLogin]
                                    ,[UserPass]
                                    ,[UserKindOfId]
                                    ,[UserStatusId]
                                    ,[Edate]
                                    ,[Mdate]
                                    ,[NickChat]
                                    ,[Tel]
                                    ,[Address]
                                    ,[KindofBusinessId]
                                    ,[Confirms]
                                    ,[CodeUserId]
                                    ,[CompanyId]
                                    ,[Picture]
                                    ,[NickSkyper]
	                                FROM [tb_Users] Where CompanyId=@CompanyId AND UserStatusId>0 Order BY Name ASC ";

         private string SQL_CREATE = @"Declare @UserId int; Declare @ERR int; 
                                     INSERT INTO [tb_Users]
                                            ([Name]
                                            ,[UserLogin]
                                            ,[UserPass]
                                            ,[UserKindOfId]
                                            ,[UserStatusId]
                                            ,[Edate]
                                            ,[Mdate]
                                            ,[NickChat]
                                            ,[Tel]
                                            ,[Address]
                                            ,[KindofBusinessId]
                                            ,[Confirms]
                                            ,[CodeUserId]
                                            ,[CompanyId]
                                            ,[Picture]
                                            ,[NickSkyper])
                                        VALUES(@Name,
	                                        @UserLogin,
	                                        @UserPass,
	                                        @UserKindOfId,
	                                        @UserStatusId,
	                                        @Edate,
	                                        @Mdate,
	                                        @NickChat,
	                                        @Tel,
	                                        @Address,
	                                        @KindofBusinessId,
	                                        @Confirms,
	                                        @CodeUserId,
	                                        @CompanyId,
	                                        @Picture,
	                                        @NickSkyper);
                                  SELECT @UserId=@@IDENTITY; SELECT @ERR=@@ERROR;";
         
         private string SQL_UPDATE_BY_ID = @"UPDATE [tb_Users]
                                       SET [Name]=@Name,
	                                        [UserLogin]=@UserLogin,
	                                        [UserPass]=@UserPass,
	                                        [UserKindOfId]=@UserKindOfId,
	                                        [UserStatusId]=@UserStatusId,
	                                        [Edate]=@Edate,
	                                        [Mdate]=@Mdate,
	                                        [NickChat]=@NickChat,
	                                        [Tel]=@Tel,
	                                        [Address]=@Address,
	                                        [KindofBusinessId]=@KindofBusinessId,
	                                        [Confirms]=@Confirms,
	                                        [CodeUserId]=@CodeUserId,
	                                        [CompanyId]=@CompanyId,	                                       
	                                        [Picture]=@Picture,
	                                        [NickSkyper]=@NickSkyper	                                                                          
                                     WHERE [UserId]=@UserId";
         private string SQL_ALL_SEARCH = @"SELECT     
                                            [UserId]
                                    ,[Name]
                                    ,[UserLogin]
                                    ,[UserPass]
                                    ,[UserKindOfId]
                                    ,[UserStatusId]
                                    ,[Edate]
                                    ,[Mdate]
                                    ,[NickChat]
                                    ,[Tel]
                                    ,[Address]
                                    ,[KindofBusinessId]
                                    ,[Confirms]
                                    ,[CodeUserId]
                                    ,[CompanyId]
                                    ,[Picture]
                                    ,[NickSkyper] FROM [tb_Users] WHERE {0}";

         public void Insert(ref UsersInfo usersInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(usersInfo, ref parms, false);
             SqlCommand cmd = new SqlCommand();

             foreach (SqlParameter parm in parms)
             {
              
                 cmd.Parameters.Add(parm);
             }

             // Create the connection to the database
             using (SqlConnection conn = new SqlConnection(this.connectionString))
             {
                 // Insert the order status
                 strSQL.Append(SQL_CREATE);

                 conn.Open();
                 cmd.Connection = conn;
                 cmd.CommandType = CommandType.Text;
                 cmd.CommandText = strSQL.Append("SELECT @UserId, @ERR").ToString();

                 // Read the output of the query, should return error count
                 using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                 {
                     // Read the returned @ERR
                     rdr.Read();
                     // If the error count is not zero throw an exception
                     if (rdr.GetInt32(1) != 0)
                         throw new ApplicationException("DATA INTEGRITY ERROR ON ORDER INSERT - ROLLBACK ISSUED");
                     else
                         usersInfo.UserId= rdr.GetInt32(0);
                 }
                 //Clear the parameters
                 cmd.Parameters.Clear();
             }
         }
         public List<UsersInfo> CheckByLoginId(string username,string password)
         {
             try
             {
                 //_logger.Info("CheckByLoginId:" + SQL_CHECK_LOGIN);
                 SqlParameter[] param = new SqlParameter[2];
                 param[0] = new SqlParameter("@UserLogin", SqlDbType.VarChar);
                 param[0].Value = username;
                 param[1] = new SqlParameter("@UserPass", SqlDbType.NVarChar);
                 param[1].Value = password;
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_CHECK_LOGIN, param);
                 if (rdr.HasRows)
                 {
                     return  Rows2Objects(rdr);
                    
                 }
             }
             catch (SqlException ex)
             {
                 _logger.Info("Error CheckByLoginId:"+ex.Message);
             }
             return null;
         }
         public List<UsersInfo> CheckByExistUser(string username)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserLogin", SqlDbType.VarChar);
                 param[0].Value = username;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_CHECK_USEREXIST, param);
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
         public UsersInfo GetById(int userid)
         {
             try
             {

                 SqlParameter[] param = new SqlParameter[1];
                 param[0] = new SqlParameter("@UserId", SqlDbType.Int);
                 param[0].Value = userid;

                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_SELECT_BYID, param);
                 if (rdr.HasRows)
                 {
                     UsersInfo info = Row2Object(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 return null;
             }
             return null;
         }
         public List<UsersInfo> GetAllSearch(string condition)
         {
             try
             {
                 string query = string.Format(SQL_ALL_SEARCH, condition);
                 
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text,query ,null);
                 if (rdr.HasRows)
                 {
                     List<UsersInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<UsersInfo> GetAll()
         {
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL, null);
                 if (rdr.HasRows)
                 {
                     List<UsersInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<UsersInfo> GetAll(int  companyid)
         {
             SqlParameter paramId = new SqlParameter("@CompanyId", SqlDbType.Int);
             paramId.Value = companyid;
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_ALL_COMPANYID, paramId);
                 if (rdr.HasRows)
                 {
                     List<UsersInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<UsersInfo> GetUserCategory(int companyid)
         {
             SqlParameter paramId = new SqlParameter("@CompanyId", SqlDbType.Int);
             paramId.Value = companyid;
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_CATEGORYUSER, paramId);
                 if (rdr.HasRows)
                 {
                     List<UsersInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public List<UsersInfo> GetLiveContact()
         {
             
             try
             {
                 SqlDataReader rdr = SqlHelper.ExecuteReader(connectionString, CommandType.Text, SQL_LIVECONTACT, null);
                 if (rdr.HasRows)
                 {
                     List<UsersInfo> info = Rows2Objects(rdr);
                     return info;
                 }
             }
             catch (SqlException ex)
             {
                 throw ex;
             }
             return null;
         }
         public void Update(UsersInfo usersInfo)
         {
             StringBuilder strSQL = new StringBuilder();

             List<SqlParameter> parms = new List<SqlParameter>();
             Object2Row(usersInfo, ref parms, false);
             SqlParameter paramId = new SqlParameter("@UserId", SqlDbType.Int);
             paramId.Value = usersInfo.UserId;
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

