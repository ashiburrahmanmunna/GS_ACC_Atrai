#region using directive
using Atrai.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
#endregion

namespace Atrai.Model.Core.Common
{
    public static class Helper
    {

        static IServiceProvider services = null;
        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        public static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        //string conString = IHttpContextAccessor.HttpContext.Session.GetString("constring");
        //static string conString = @"Server=101.2.165.189\MSSQL2014;Database=GTRERP_DAP_LIVE; user id=sa; password=gTr@$#@456*&%^()gT#7; MultipleActiveResultSets=true";
        static string conString = AppData.DefaultConnectionString;

        //static string conString = @"Server=.;Database=InvoiceCoreDb; user id=sa; password=gtr@007; MultipleActiveResultSets=true";

        //Database=invoiceCoreDb; user id = sa; password=gtr@007; MultipleActiveResultSets=true


        //helper snippet to exec a procedure and map the result to a generic type of class
        public static List<T> ExecProcMapTList<T>(string commandText, SqlParameter[] sqlParameter = null) where T : class, new()
        {
            try
            {

                AppData.globalException = "";
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    cmd.Parameters.AddRange(sqlParameter);
                }
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(reader);


                connection.Close();

                //map datatable to a geniric class type list

                List<T> list = new List<T>();

                if (dataTable.Rows.Count > 0)
                {
                    var serializedMyObjects = JsonConvert.SerializeObject(dataTable);

                    list = (List<T>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<T>));
                }


                return list;

            }
            catch (Exception ex)
            {
                AppData.globalException = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static T ExecProcMapT<T>(string commandText, SqlParameter[] sqlParameter = null) where T : class, new()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    cmd.Parameters.AddRange(sqlParameter);
                }
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(reader);


                connection.Close();
                T obj = new T();
                //map datatable to a geniric class type list
                foreach (var row in dataTable.AsEnumerable())
                {


                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

                return obj;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static DataTable GetDataTable(string commandText, SqlParameter[] sqlParameter = null)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    cmd.Parameters.AddRange(sqlParameter);
                }
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                var dataTable = new DataTable();
                dataTable.Load(reader);


                connection.Close();

                return dataTable;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static List<T> ExecFnc<T>(string commandText, SqlParameter[] sqlParameter = null) where T : class, new()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.Text;
                if (sqlParameter != null)
                {
                    cmd.Parameters.AddRange(sqlParameter);
                }
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                //map datatable to a geniric class type list

                List<T> list = new List<T>();

                foreach (var row in dt.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static DataSet ExecProcMapDS(string commandText, SqlParameter[] sqlParameter = null) /*where T : class, new()*/
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.StoredProcedure;
                if (sqlParameter != null)
                {
                    cmd.Parameters.AddRange(sqlParameter);
                }
                connection.Open();

                // Get the SQL query string
                string queryString = "Exec " + commandText;
                if (cmd.Parameters.Count > 0)
                {
                    queryString += " " + string.Join(", ", cmd.Parameters.Cast<SqlParameter>().Select(p => $"{GetParameterValueString(p)}"));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        private static string GetParameterValueString(SqlParameter parameter)
        {
            if (parameter.Value == null || DBNull.Value.Equals(parameter.Value))
            {
                return "NULL";
            }
            else if (parameter.Value is string || parameter.Value is DateTime)
            {
                return $"'{parameter.Value}'";
            }
            else
            {
                return parameter.Value.ToString();
            }
        }
        public static DataSet ExecProcMapDS(string commandText) /*where T : class, new()*/
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public static string GTRDate(string strDate)
        {
            if (strDate.Length == 0)
            {
                return "";
            }
            DateTime dt = DateTime.Parse(strDate);
            return string.Format("{0:dd}", dt) + "-" + string.Format("{0:MMM}", dt) + "-" + string.Format("{0:yyyy}", dt);
        }

        public static Int64 GTRCountingDataLarge(string commandText)
        {
            Int64 Result = 0;
            if (commandText.Length == 0 || commandText == string.Empty)
            {
                return Result;
            }

            try
            {
                SqlConnection connection = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();

                Result = (Int64)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                //throw exception to front caller
                throw (ex);
            }

            return Result;
        }

        public static string ExecProc(string commandText, SqlParameter[] sqlParameter = null)
        {
            //SqlConnection connection = new SqlConnection(conString);
            //connection.ConnectionTimeout("15");

            //SqlConnection connectionString = new SqlConnection(conString);


            try
            {
                AppData.globalException = "";
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(commandText, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (sqlParameter != null)
                    {
                        cmd.Parameters.AddRange(sqlParameter);

                    }
                    // Setting command timeout to 1 second  
                    cmd.CommandTimeout = 1000;
                    try
                    {
                        //string abc =  cmd.execu();

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Command Successfull");
                        return "1";
                    }

                    catch (SqlException e)
                    {
                        Console.WriteLine("Got expected SqlException due to command timeout ");
                        Console.WriteLine(e);
                        return e.Message.ToString();
                    }
                }

                //    SqlCommand cmd = new SqlCommand(commandText, connection);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    if (sqlParameter != null)
                //    {
                //        cmd.Parameters.AddRange(sqlParameter);

                //    }
                //    connection.Open();

                //    cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                AppData.globalException = ex.Message;
                Console.WriteLine(ex.Message);
                return ex.ToString();
            }
            //finally
            //{
            //    connection.Close();
            //}

        }

        public static void GTRSaveDataWithSQLCommand(ArrayList sqlQuery)
        {
            if (sqlQuery.Count == 0)
            {
                throw (new Exception("Empty SQL Query."));
            }

            SqlConnection connection = new SqlConnection(conString);

            SqlCommand cmd;

            connection.Open();

            //Open Connection
            //GTRConnectionOpen();
            cmd = connection.CreateCommand();
            cmd.CommandTimeout = 1200;

            SqlTransaction tran = connection.BeginTransaction();
            cmd.Connection = connection;
            cmd.Transaction = tran;

            try
            {
                //Passing Query & Connection Object to initialize Command
                for (int i = 0; i < sqlQuery.Count; i++)
                {
                    cmd.CommandText = sqlQuery[i].ToString();
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                try
                {
                    tran.Rollback();
                }
                catch (SqlException sqlex)
                {
                    if (tran.Connection != null)
                    {
                        Console.WriteLine("An exception of type " + sqlex.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }
                throw (ex);
            }
            finally
            {
                //Close Connection
                connection.Close();
            }
        }

        public static string ExecCommand(string commandText)
        {
            try
            {
                SqlConnection connection = new SqlConnection(conString);

                SqlCommand cmd = new SqlCommand(commandText, connection);
                cmd.CommandType = CommandType.Text;

                connection.Open();

                cmd.ExecuteNonQuery();
                return "1";
            }
            catch (SqlException ex)
            {

                Console.WriteLine(ex.Message);
                return ex.ToString();
            }


        }

        public static void PutTempData<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        public static T GetTempData<T>(this ITempDataDictionary tempData, string key) where T : class
        {
            object o;
            tempData.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }


        public static string ConvertDataSetasJSON(DataSet dataSet)
        {
            return JsonConvert.SerializeObject(dataSet);
        }

    }

    public static class DataTableConverter<T> where T : new()
    {
        public static List<T> ConvertDataTableToObject(DataTable dataTable)
        {
            List<T> objectsList = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T obj = new T();

                foreach (DataColumn col in dataTable.Columns)
                {
                    var property = typeof(T).GetProperty(col.ColumnName);
                    if (property != null && row[col] != DBNull.Value)
                    {
                        object value = Convert.ChangeType(row[col], property.PropertyType);
                        property.SetValue(obj, value);
                    }
                }

                objectsList.Add(obj);
            }

            return objectsList;
        }


        //public static List<T> ConvertDataTableToObject(DataTable dataTable)
        //{
        //    List<T> objectsList = new List<T>();

        //    foreach (DataRow row in dataTable.Rows)
        //    {
        //        T obj = new T();

        //        foreach (DataColumn col in dataTable.Columns)
        //        {
        //            var property = typeof(T).GetProperty(col.ColumnName);
        //            if (property != null && row[col] != DBNull.Value)
        //            {
        //                Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //                object value = Convert.ChangeType(row[col], propertyType);
        //                property.SetValue(obj, value);
        //            }
        //        }

        //        objectsList.Add(obj);
        //    }

        //    return objectsList;
        //}


    }

}
