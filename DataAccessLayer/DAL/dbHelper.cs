using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAL
{
    public class dbHelper
    {
        string connectionString = ConfigurationManager.ConnectionStrings["commonModal"].ConnectionString;

        #region Generic Metho to Get Data from Database
        /// <summary>
        /// Note:   This is a generic method that will be used to retrive data from Database using Dictionary as parameters.
        /// Author: Sohail Arshed
        /// Date:   01-18-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataTable GetDataByValueInDataTable(string SPName, Dictionary<string, string> values)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return dt;
        }

        /// <summary>
        /// Note:   This is a generic method that will be used to retrive data from Database using Dictionary as parameters.
        /// Author: Sohail Arshed
        /// Date:   03-29-2019
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet GetDataByValueInDataSet(string SPName, Dictionary<string, string> values)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return ds;
        }

        /// <summary>
        /// Note:   This is a generic method that will be used to retrive data from Database using Dictionary as parameters.
        /// Author: Sohail Arshed
        /// Date:   03-29-2019
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public DataSet GetDataByValueInDataSet(string SPName, string DtParam, DataTable dt, Dictionary<string, string> values)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                cmd.Parameters.AddWithValue("@" + DtParam, dt);

                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return ds;
        }

        /// <summary>
        /// Note:   This is a generic method that will be used to retrive data from Database using parameters.
        /// Author: Sohail Arshed
        /// Date:   2019-02-23
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="sqlParameterCollection"></param>
        /// <returns></returns>
        public DataTable GetDataByValue(string SPName, List<SqlParameter> sqlParameterCollection)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddRange(sqlParameterCollection.ToArray());
                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return dt;
        }

        /// <summary>
        /// Note:   This is generic method that will be used to get all record from database.
        /// Author: Sohail Arshed
        /// Date:   01-18-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <returns></returns>

        public DataTable GetData(string SPName)
        {
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return dt;
        }

        public DataSet GetAllData(string SPName)
        {
            DataSet ds = new DataSet();
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                Conn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return ds;
        }

        #endregion

        #region Generic Methods to Save Data in Database.

        /// <summary>
        /// Note:   This Generic method that will be used to save data in Database using Datatable and list of parameters in form of Dictionary and will return values as well.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="DtParam"></param>
        /// <param name="dt"></param>
        /// <param name="values"></param>
        /// <returns></returns>

        public DataTable SaveChangesWithReturnDT(string SPName, string DtParam, DataTable dt, Dictionary<string, string> values)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dtReturn = new DataTable();
            try
            {
                cmd.Parameters.AddWithValue("@" + DtParam, dt);
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtReturn);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

            return dtReturn;
        }

        /// <summary>
        /// Note:   This is the generic method used to save data in Database using Datatable.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="ProcName"></param>
        /// <param name="ProcUDTable"></param>
        /// <param name="dt"></param>
        public void SaveChanges(string ProcName, string ProcUDTable, DataTable dt)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(ProcName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    cmd.Parameters.AddWithValue(ProcUDTable, dt);
                    cmd.ExecuteNonQuery();
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

        /// <summary>
        /// Note:   This method will be used to save data in database using group of parameters with the help of dictionary.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="values"></param>
        public void SaveChanges(string SPName, Dictionary<string, string> values)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Note:   This method used Datatable and Dictionary objects used to Save Data.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="dtParam"></param>
        /// <param name="dt"></param>
        /// <param name="values"></param>
        public void SaveChanges(string SPName, string dtParam, DataTable dt, Dictionary<string, string> values)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                cmd.Parameters.AddWithValue("@" + dtParam, dt);
                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Note:   This method used to Save data in database using SQL parameters in the form of list.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="sqlParameterCollection"></param>
        public void SaveChanges(string SPName, List<SqlParameter> sqlParameterCollection)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (sqlParameterCollection != null)
                {
                    cmd.Parameters.AddRange(sqlParameterCollection.ToArray());
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Note:   This method used to save Data in database with the help of SQL parameters and Datatable.
        /// Author: Sohail Arshed
        /// Date:   05-03-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="dtParam"></param>
        /// <param name="dtName"></param>
        /// <param name="sqlParameterCollection"></param>
        public void SaveChanges(string SPName, string dtParam, DataTable dtName, List<SqlParameter> sqlParameterCollection)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (sqlParameterCollection != null)
                {
                    cmd.Parameters.AddRange(sqlParameterCollection.ToArray());
                    cmd.Parameters.AddWithValue("@" + dtParam, dtName);
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Note:   This method used to Save data in Database using Datatable and SQL Parametes list and Dictionary objects.
        /// Author: Sohail Arshed
        /// Date:   03-05-2018
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="dtParam"></param>
        /// <param name="dtName"></param>
        /// <param name="values"></param>
        /// <param name="sqlParameterCollection"></param>
        public void SaveChanges(string SPName, string dtParam, DataTable dtName, Dictionary<string, string> values, List<SqlParameter> sqlParameterCollection)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (sqlParameterCollection != null)
                {
                    cmd.Parameters.AddRange(sqlParameterCollection.ToArray());
                    cmd.Parameters.AddWithValue("@" + dtParam, dtName);
                    foreach (KeyValuePair<string, string> data in values)
                    {
                        cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                    }
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        #endregion

        /// <summary>
        /// Note:   This method used to Delete data in Database using Datatable and SQL Parametes list.
        /// Author: Sohail Arshed
        /// Date:   2019-02-23
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="dtParam"></param>
        /// <param name="dt"></param>
        /// <param name="values"></param>
        public void DeleteRecords(string SPName, string dtParam, DataTable dt, Dictionary<string, string> values)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                cmd.Parameters.AddWithValue("@" + dtParam, dt);
                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// Note:   This method used to Delete data in Database using Datatable and Dictionary objects.
        /// Author: Sohail Arshed
        /// Date:   2019-02-23
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="dtParam"></param>
        /// <param name="dt"></param>
        /// <param name="sqlParameterCollection"></param>
        public void DeleteRecords(string SPName, string dtParam, DataTable dt, List<SqlParameter> sqlParameterCollection)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                if (sqlParameterCollection != null)
                {
                    cmd.Parameters.AddRange(sqlParameterCollection.ToArray());
                    Conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SPName"></param>
        /// <param name="values"></param>
        public void DeleteRecords(string SPName, Dictionary<string, string> values)
        {
            SqlConnection Conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(SPName, Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (KeyValuePair<string, string> data in values)
                {
                    cmd.Parameters.AddWithValue("@" + data.Key, data.Value);
                }

                Conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
