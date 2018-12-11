using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using SCRA.Common.Reflection;
using SCRA.Common.Utilities;

namespace SCRA.Data.Common.Utilities
{
    public static class SqlCommandHelper
    {
        public static async Task<IList<object>> ExecuteQuery(string connectionString, string query, int? commandTimeout, object parameters, CancellationToken token)
        {
            return await Execute<object>(connectionString, query, CommandType.Text, commandTimeout, parameters, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(string connectionString, string query, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            return await Execute<T>(connectionString, query, CommandType.Text, commandTimeout, parameters, token);
        }

        public static async Task<IList<object>> ExecuteQuery(string connectionString, int? commandTimeout, string query, CancellationToken token)
        {
            return await ExecuteQuery(connectionString, query, commandTimeout, null, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(string connectionString, int? commandTimeout, string query, CancellationToken token) where T : new()
        {
            return await ExecuteQuery<T>(connectionString, query, commandTimeout, null, token);
        }

        public static async Task<IList<object>> ExecuteQuery(string connectionString, string query, CancellationToken token)
        {
            return await ExecuteQuery(connectionString, query, null, null, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(string connectionString, string query, CancellationToken token) where T : new()
        {
            return await ExecuteQuery<T>(connectionString, query, null, null, token);
        }

        public static async Task<IList<object>> ExecuteQuery(SqlConnection connection, string query, int? commandTimeout, object parameters, CancellationToken token)
        {
            return await Execute<object>(connection, query, CommandType.Text, commandTimeout, parameters, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(SqlConnection connection, string query, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            return await Execute<T>(connection, query, CommandType.Text, commandTimeout, parameters, token);
        }

        public static async Task<IList<object>> ExecuteQuery(SqlConnection connection, int? commandTimeout, string query, CancellationToken token)
        {
            return await ExecuteQuery(connection, query, commandTimeout, null, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(SqlConnection connection, int? commandTimeout, string query, CancellationToken token) where T : new()
        {
            return await ExecuteQuery<T>(connection, query, commandTimeout, null, token);
        }

        public static async Task<IList<object>> ExecuteQuery(SqlConnection connection, string query, CancellationToken token)
        {
            return await ExecuteQuery(connection, query, null, null, token);
        }

        public static async Task<IList<T>> ExecuteQuery<T>(SqlConnection connection, string query, CancellationToken token) where T : new()
        {
            return await ExecuteQuery<T>(connection, query, null, null, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(string connectionString, string name, int? commandTimeout, object parameters, CancellationToken token)
        {
            return await Execute<object>(connectionString, name, CommandType.StoredProcedure, commandTimeout, parameters, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(string connectionString, string name, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            return await Execute<T>(connectionString, name, CommandType.StoredProcedure, commandTimeout, parameters, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(string connectionString, string name, int? commandTimeout, CancellationToken token)
        {
            return await ExecuteMethodCall(connectionString, name, commandTimeout, null, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(string connectionString, string name, int? commandTimeout, CancellationToken token) where T : new()
        {
            return await ExecuteMethodCall<T>(connectionString, name, commandTimeout, null, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(string connectionString, string name, CancellationToken token)
        {
            return await ExecuteMethodCall(connectionString, name, null, null, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(string connectionString, string name, CancellationToken token) where T : new()
        {
            return await ExecuteMethodCall<T>(connectionString, name, null, null, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(SqlConnection connection, string name, int? commandTimeout, object parameters, CancellationToken token)
        {
            return await Execute<object>(connection, name, CommandType.StoredProcedure, commandTimeout, parameters, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(SqlConnection connection, string name, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            return await Execute<T>(connection, name, CommandType.StoredProcedure, commandTimeout, parameters, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(SqlConnection connection, string name, int? commandTimeout, CancellationToken token)
        {
            return await ExecuteMethodCall(connection, name, commandTimeout, null, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(SqlConnection connection, string name, int? commandTimeout, CancellationToken token) where T : new()
        {
            return await ExecuteMethodCall<T>(connection, name, commandTimeout, null, token);
        }

        public static async Task<IList<object>> ExecuteMethodCall(SqlConnection connection, string name, CancellationToken token)
        {
            return await ExecuteMethodCall(connection, name, null, null, token);
        }

        public static async Task<IList<T>> ExecuteMethodCall<T>(SqlConnection connection, string name, CancellationToken token) where T : new()
        {
            return await ExecuteMethodCall<T>(connection, name, null, null, token);
        }

        private static async Task<IList<T>> Execute<T>(SqlConnection connection, string cmdText, CommandType cmdType, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }

            IList<T> records = new List<T>();
            using (SqlCommand command = new SqlCommand(cmdText, connection) { CommandType = cmdType })
            {
                if (commandTimeout.HasValue)
                {
                    command.CommandTimeout = commandTimeout.Value;
                }

                PrepareCommandParameters(command, parameters);
                await ExecuteCommandReader(command, records, token);
            }

            return records;
        }

        private static async Task<IList<T>> Execute<T>(string connectionString, string cmdText, CommandType cmdType, int? commandTimeout, object parameters, CancellationToken token) where T : new()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                return await Execute<T>(connection, cmdText, cmdType, commandTimeout, parameters, token);
            }
        }

        private static void PrepareCommandParameters(SqlCommand command, object parameters)
        {
            if (parameters != null)
            {
                foreach (PropertyInfo propertyInfo in parameters.GetType().GetProperties())
                {
                    command.Parameters.Add(new SqlParameter(propertyInfo.Name, parameters.GetAt(propertyInfo.Name)));
                }
            }
        }

        private static async Task ExecuteCommandReader<T>(SqlCommand command, ICollection<T> records, CancellationToken token) where T : new()
        {
            try
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync(token))
                {
                    IList<string> names = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        names.Add(reader.GetName(i));
                    }

                    AnonymousBuilder anonymousBuilder = typeof(T) == typeof(object)
                        ? new AnonymousBuilder(names.ToArray())
                        : null;

                    foreach (IDataRecord record in reader)
                    {
                        IList<object> values = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            values.Add(record[i] != DBNull.Value ? record[i] : null);
                        }

                        T instance = anonymousBuilder != null
                            ? (T)anonymousBuilder.CreateInstance(values.ToArray())
                            : CreateTypedInstance<T>(values);

                        records.Add(instance);
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                LogHelper.Exception(ex);
                throw;
            }
            catch (Exception ex)
            {
                LogHelper.Exception(ex);
                throw;
            }
        }

        private static T CreateTypedInstance<T>(IList<object> values) where T : new()
        {
            T instance = new T();
            Type type = typeof(T);

            instance.CopyValues(type, values);

            return instance;
        }
    }
}
