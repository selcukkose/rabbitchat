using System;
using RabbitChatConfig;
using Npgsql;

namespace RabbitChatData.Helpers
{
	public class ConnectionHelper : IDisposable
	{
		/// <summary>
		///	Database connection.
		/// </summary>
		private static NpgsqlConnection connection;

		public ConnectionHelper()
		{
			connection = new NpgsqlConnection(ConfigHelper.DbConnectionString);
		}

		public static ConnectionHelper GetConnectionHelper ()
		{
			return new ConnectionHelper();
		}

		public void OpenConnection()
		{
			connection.Open();
		}

		public void CloseConnection()
		{
			connection.Close();
		}

		public NpgsqlConnection GetConnection ()
		{
			return connection;
		}

		public void Dispose()
		{
			// throw new NotImplementedException();
		}
	}
}
