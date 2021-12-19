using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.DAL
{
    public class MySqlDbHelper
    {
        #region("Variables")
        static string connectionString = "";
        static string GetConnectionString()
        {
            return connectionString;
        }
        #endregion

        #region("Methods")
        internal static DataTable GetAllDataBySP(string procedureName)
        {
            DataTable dt = null;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return dt;
        }
        public static DataSet GetAllDataBySP(string procedureName, MySqlParameter[] param)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            bool IsSPParamLoggingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["SPParameterLoggingEnabled"].ToString());

            if (IsSPParamLoggingEnabled)
            {
                String parameters = String.Empty;

                foreach (var parameter in param)
                {
                    parameters += parameter.ParameterName + ": " + parameter.Value + "| ";
                }

                //AppLogger.LogInfo(string.Format("StoredProcedure Name: {0} || Parameters ==> {1}", procedureName, parameters));
            }

            DataSet ds = null;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            watch.Stop();
            //AppLogger.LogInfo(string.Format("StoredProcedure Name: {0} || Time elapsed: {1}", procedureName, watch.ElapsedMilliseconds / 1000.0));

            return ds;
        }
        public static DataSet GetAllDataBySP(string procedureName, MySqlParameter[] param, string strConnectionString)
        {
            strConnectionString = string.IsNullOrEmpty(strConnectionString) ? GetConnectionString() : strConnectionString;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            bool IsSPParamLoggingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["SPParameterLoggingEnabled"].ToString());

            if (IsSPParamLoggingEnabled)
            {
                String parameters = String.Empty;

                foreach (var parameter in param)
                {
                    parameters += parameter.ParameterName + ": " + parameter.Value + "| ";
                }

                //AppLogger.LogInfo(string.Format("StoredProcedure Name: {0} || Parameters ==> {1}", procedureName, parameters));
            }

            DataSet ds = null;
            using (MySqlConnection con = new MySqlConnection(strConnectionString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            watch.Stop();
            //AppLogger.LogInfo(string.Format("StoredProcedure Name: {0} || Time elapsed: {1}", procedureName, watch.ElapsedMilliseconds / 1000.0));

            return ds;
        }

        public static DataSet GetAllDataBySPReturnDataSet(string procedureName, string connString = null)
        {
            DataSet ds = null;
            connString = string.IsNullOrEmpty(connString) ? GetConnectionString() : connString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return ds;
        }

        // This function will be used to execute R(CRUD) operation of parameterless commands
        internal static DataTable ExecuteSelectCommand(string procedureName, CommandType cmdType)
        {
            DataTable dt = null;
            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = procedureName;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }
        // This function will be used to execute R(CRUD) operation of parameterized commands
        internal static DataTable ExecuteParamerizedSelectCommand(string procedureName, CommandType cmdType, MySqlParameter[] param, string strConnectionString = "")
        {
            DataTable dt = null;

            string connString = string.Empty;
            if (strConnectionString == "")
                connString = GetConnectionString();
            else
                connString = strConnectionString;
            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }
        // This function will be used to execute CUD(CRUD) operation of parameterized commands
        internal static bool ExecuteNonQuery(string procedureName, CommandType cmdType, MySqlParameter[] param, string strConnectionString = "")
        {
            int retVal = 0;
            string connString = string.Empty;
            if (strConnectionString == "" || strConnectionString == string.Empty)
                connString = GetConnectionString();
            else
                connString = strConnectionString;

            using (MySqlConnection con = new MySqlConnection(connString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        retVal = cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return (retVal > 0);
        }

        internal static int ExecuteScalar(string procedureName, CommandType cmdType, MySqlParameter[] param, string connStr = null)
        {

            int retVal = 0;
            connStr = string.IsNullOrEmpty(connStr) ? GetConnectionString() : connStr;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        var value = cmd.ExecuteScalar();
                        if (value != DBNull.Value)
                        {
                            retVal = Convert.ToInt32(value);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return retVal;
        }

        internal static void ExecuteQuery(string query, CommandType cmdType, string connStr = null)
        {
            //int retVal = 0;
            connStr = string.IsNullOrEmpty(connStr) ? GetConnectionString() : connStr;
            using (MySqlConnection con = new MySqlConnection(connStr))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = query;

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        internal static object ExecuteScalar(string procedureName, MySqlParameter[] param, string strConnectionString = null)
        {

            object retVal = null;
            strConnectionString = string.IsNullOrEmpty(strConnectionString) ? GetConnectionString() : strConnectionString;
            using (MySqlConnection con = new MySqlConnection(strConnectionString))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        retVal = cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return retVal;
        }

        internal static DataSet ExecuteParamerizedSelectCommandDataSet(string procedureName, CommandType cmdType, MySqlParameter[] param)
        {
            DataSet ds = null;

            using (MySqlConnection con = new MySqlConnection(GetConnectionString()))
            {
                using (MySqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandType = cmdType;
                    cmd.CommandText = procedureName;
                    cmd.Parameters.AddRange(param);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            ds = new DataSet();
                            da.Fill(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }

            return ds;
        }

        #endregion
       
        public static IDataReader GetAllDataInReaderBySP(string procedureName, MySqlParameter[] param)
        {
            try
            {
                var _idbConnection = new MySqlConnection(GetConnectionString());

                var sqlCommand = new MySqlCommand(procedureName, _idbConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = procedureName;
                sqlCommand.Parameters.AddRange(param);
                sqlCommand.Connection.Open();

                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public static IDataReader GetAllDataInReaderBySP(string procedureName, MySqlParameter[] param, string strConnectionString = null)
        {
            try
            {
                strConnectionString = string.IsNullOrEmpty(strConnectionString) ? GetConnectionString() : strConnectionString;
                var _idbConnection = new MySqlConnection(strConnectionString);

                var sqlCommand = new MySqlCommand(procedureName, _idbConnection);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = procedureName;
                sqlCommand.Parameters.AddRange(param);
                sqlCommand.Connection.Open();

                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
