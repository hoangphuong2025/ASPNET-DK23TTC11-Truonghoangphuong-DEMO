using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using NLog;

namespace web_connection
{
    public abstract class SqlHelper
    {

        public static Logger _logger = LogManager.GetCurrentClassLogger();    
        private static SqlDataAdapter csAdapter;
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        
        public static void CacheParameters(string cacheKey, params SqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static int ExecuteNonQuery(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
        }

        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int num = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return num;
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                int num = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return num;
            }
        }

        public static SqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            //_logger.Info("ExecuteReader cmdText :" + cmdText);
            SqlCommand cmd = new SqlCommand();

            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                cmd.CommandTimeout = 60;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return reader;
            }
            
            catch (Exception exception)
            {
       
                cmd.CommandTimeout = 60;
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
           
                return reader;
               
            }
         
        }

        public static object ExecuteReader_Loop(SqlConnection conn, CommandType cmdType, string cmdText, SqlTransaction trans, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, conn, trans, cmdType, cmdText, commandParameters);
                object obj2 = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj2;
            }
            catch (Exception exception)
            {
                _logger.Info("ExecuteReader_Loop Error :" + exception.Message);
            }
            return null;
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
            object obj2 = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return obj2;
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object obj2 = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return obj2;
            }
        }

        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] parameterArray = (SqlParameter[]) parmCache[cacheKey];
            if (parameterArray == null)
            {
                return null;
            }
            SqlParameter[] parameterArray2 = new SqlParameter[parameterArray.Length];
            int index = 0;
            int length = parameterArray.Length;
            while (index < length)
            {
                parameterArray2[index] = (SqlParameter) ((ICloneable) parameterArray[index]).Clone();
                index++;
            }
            return parameterArray2;
        }

        public static SqlConnection GetConnection(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        public static SqlConnection GetConnections(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
      
        public static DataSet getDataset(string query, string connectionString)
        {
            DataSet set2;
            _logger.Info("query getDataset:" + query);
            SqlConnection selectConnection = null;
            try
            {
                selectConnection = new SqlConnection(connectionString);
                SqlDataAdapter adapter = new SqlDataAdapter(query, selectConnection);
                
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                csAdapter = adapter;
                set2 = dataSet;
            }
            catch (Exception exception)
            {
                _logger.Info("getDataset Error :" + exception.Message);
                Console.WriteLine(exception.Message);
                set2 = null;
            }
            finally
            {
                if (selectConnection != null)
                {
                    selectConnection.Close();
                }
            }
            return set2;
        }

        public static DataSet getDatasetUpdate(string query, string strconnection, string tables)
        {
            try
            {
                SqlConnection selectConnection = new SqlConnection(strconnection);
                SqlDataAdapter adapter = new SqlDataAdapter(query, selectConnection);
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, tables);
                CsAdapter = adapter;
                return dataSet;
            }
            catch (Exception exception)
            {
                _logger.Info("SqlHelper getDatasetUpdate :" + exception.Message);
            }
            return null;
        }

        public static ArrayList GetQueryString(string query, string connectionString)
        {
            ArrayList list = new ArrayList();
            try
            {
                DataTable table = getDataset(query, connectionString).Tables[0];
                int count = table.Columns.Count;
                foreach (DataRow row in table.Rows)
                {
                    ArrayList list2 = new ArrayList();
                    for (int i = 0; i < count; i++)
                    {
                        string str = row[i].ToString();
                        list2.Add(str);
                    }
                    list.Add(list2);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return new ArrayList();
            }
            return list;
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
          
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        public static long updateData(String query, ArrayList param, string connectionString)
        {
            _logger.Info("QUERY :"+query);
            IDbCommand dbCommand = new SqlCommand();
            dbCommand.Connection = new SqlConnection(connectionString);
            try
            {
                dbCommand.CommandText = query;
                dbCommand.CommandType = CommandType.Text;
                int i = 0;
                foreach (Object objParam in param)
                {
                    IDbDataParameter p = dbCommand.CreateParameter();
                    p.ParameterName = "@" + i;
                    //_logger.Info("p.ParameterName:" + p.ParameterName);
                    p.Value = objParam;
                    dbCommand.Parameters.Add(p);
                    i++;
                }
                dbCommand.Connection.Open();
                int ii = dbCommand.ExecuteNonQuery();
                return ii;
            }
            catch (Exception ex)
            {
                _logger.Info("updateData error:" + ex.Message);
                return -1;
            }
            finally
            {
                dbCommand.Connection.Close();
            }
        }
        public static int updateData(string querystring, string connectionstring)
        {
           
            SqlConnection myConnection = new SqlConnection(connectionstring);
            SqlCommand myCommand = new SqlCommand(querystring, myConnection);

            // Mark the Command as a SPROC
            myCommand.CommandType = CommandType.Text;
            int rowsAffected = 0;
            myConnection.Open();
            try
            {
                rowsAffected = myCommand.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                _logger.Info("updateData :" + ee.Message);
                Console.WriteLine(ee.Message);
            }
            finally
            {
                myCommand.Connection.Close();

            }
            return rowsAffected;
        }

        public static int updateData(string querystring, string connectionstring, SqlCommand dbCommand)
        {
           
            int num;
            SqlConnection connection = new SqlConnection(connectionstring);
            dbCommand.CommandText = querystring;
            dbCommand.CommandType = CommandType.Text;
            connection.Open();
            try
            {
                num = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
            }
            finally
            {
                connection.Close();
            }
            return num;
        }

        public static long updateData(string query, ArrayList param, string connectionString, SqlCommand dbCommand)
        {
            _logger.Info("updateData Query :" + query);
            dbCommand.CommandText = query;
            dbCommand.CommandType = CommandType.Text;
            int num = 0;
            foreach (object obj2 in param)
            {
                IDbDataParameter parameter = dbCommand.CreateParameter();
                parameter.ParameterName = "@" + num;
                
                parameter.Value = obj2;
                dbCommand.Parameters.Add(parameter);
                num++;
            }
            int num2 = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return  num2;
        }

        public static SqlDataAdapter CsAdapter
        {
            get
            {
                return csAdapter;
            }
            set
            {
                csAdapter = value;
            }
        }
    }
}

