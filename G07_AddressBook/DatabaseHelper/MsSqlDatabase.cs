using System.Data.SqlClient;
using DatabaseHelper.Generic;

namespace DatabaseHelper
{
	public sealed class MsSqlDatabase : Database<SqlConnection, SqlCommand, SqlDataReader>
	{
		public MsSqlDatabase(string connectionString) : base(connectionString)
		{

		}
	}
}