using Dapper;
using DataModel;
using System.Data.SqlClient;

namespace Manager
{
	public class TestRecordManager
	{
		string _connectionString;
		internal readonly SqlConnection _connection;

		public TestRecordManager(string ConnectionString)
		{
			this._connectionString = ConnectionString;
			_connection = new SqlConnection(ConnectionString);
		}

		/// <summary>
		/// 取得最新一筆測試紀錄
		/// </summary>
		/// <returns></returns>
		public TestRecord GetLatTestRecord()
		{
			TestRecord data = new TestRecord();

			string sql = @"
			SELECT TOP(1) *
			FROM [dbo].[TestRecord]
			ORDER BY Id DESC";

			var query = _connection.Query<TestRecord>(sql);
			if (query.Any())
				data = query.First();

			return data;
		}
	}
}
