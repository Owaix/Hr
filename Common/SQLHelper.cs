using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Common
{
    /// <summary>
    /// Support Controller class to execute storedprocedure on database
    /// </summary>
    public class SqlHelper
    {
        private static SqlConnection _DefaultSqlConnection;
        /// <summary>
        /// 
        /// </summary>
        public static SqlConnection DefaultSqlConnection
        {
            get { return _DefaultSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); }
            set { _DefaultSqlConnection = value; }
        }

        /// <summary>
        /// Execute a SqlCommand (that is loaded with all required objects) against the database, specified in 
        /// the connection string
        /// </summary>
        /// <remarks>
        /// e.g.:  
        ///  int result = ExecuteNonQuery(sqlCommand);
        /// </remarks>
        /// <param name="sqlCommand">A valid SqlCommand object loaded with SqlConnection, CommandType, CommandText and others</param>
        /// <returns>An int representing the number of row affected by the command</returns>
        public static object ExecuteNonQuery(SqlCommand sqlCommand)
        {
            // Validating SqlCommand
            if (sqlCommand == null) throw new Exception("Error in provided parameter <SqlCommand>. Please review your SqlCommand object.");

            // Validating Connection
            if (sqlCommand.Connection == null) throw new Exception("Error in provided Connection. Please set SqlCommand.Connection = new SqlConnection(string ConnectionString); or in other ways.");

            // Validating CommandText
            if (string.IsNullOrEmpty(sqlCommand.CommandText)) throw new Exception("Error in provided Command Text. Please set SqlCommand.CommandText = \"Some SQL query or StoredProcedure name\"; or in other ways.");

            using (sqlCommand)
            {
                try
                {
                    // Finally, execute the command
                    object retval = sqlCommand.ExecuteNonQuery();
                    //sqlCommand.ExecuteXmlReader();
                    // If @@Identity returned from SP then return @@Identity
                    for (int i = 0; i < sqlCommand.Parameters.Count; i++)
                    {
                        if (sqlCommand.Parameters[i].Direction == ParameterDirection.ReturnValue)
                        {
                            if (sqlCommand.Parameters[i].Value != null)
                                retval = sqlCommand.Parameters[i].Value;
                            break;
                        }
                    }

                    if (sqlCommand.CommandText.Contains("Logs_") == false)
                    {  
                        new Entities.Logs().Log_SQL_NonQuery("", sqlCommand.CommandText, retval);
                    }
                    return retval;
                }
                catch (Exception ex)
                {
                    throw new Exception("SQL Execution failed. " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Execute a SqlCommand (that returns a Dataset) against the database, specified in connection string.
        /// </summary>
        /// <param name="commandType">The CommandType (stored procedure or text).</param>
        /// <param name="commandText">The stored procedure name or T-SQL command.</param>
        /// <returns>A dataset containing the resultset generated by the command.</returns>
        public static DataSet ExecuteDataset(SqlCommand sqlCommand)
        {
            // Validating SqlCommand
            if (sqlCommand == null) throw new Exception("Error in provided parameter <SqlCommand>. Please review your SqlCommand object.");

            // Validating Connection
            if (sqlCommand.Connection == null) throw new Exception("Error in provided Connection. Please set SqlCommand.Connection = new SqlConnection(string ConnectionString); or in other ways.");

            // Validating CommandText
            if (string.IsNullOrEmpty(sqlCommand.CommandText)) throw new Exception("Error in provided Command Text. Please set SqlCommand.CommandText = \"Some Transact-SQL query or StoredProcedure name\"; or in other ways.");


            using (sqlCommand.Connection)
            {
                sqlCommand.CommandTimeout = 0;
                using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        sqlCommand.Connection.Open();
                        da.Fill(ds);

                        //new Entities.Logs().Log_SQL_Select($"Tables:{ds.Tables.Count},Columns:{ds.Tables[0].Columns.Count},Rows:{ds.Tables[0].Rows.Count}", sqlCommand.CommandText);

                        return ds;
                    }
                    catch (Exception ex)
                    { throw new Exception(ex.Message); }
                    finally
                    {
                        sqlCommand.Connection.Close();
                        da.Dispose();
                        ds.Dispose();
                    }///End finally
                }///End using (SqlDataAdapter
            }///End using (sqlCommand.Connection)
        }
    }
}
