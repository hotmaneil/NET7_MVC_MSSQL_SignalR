using DataModel;
using Hubs;
using ISubscribeTableDependency;
using TableDependency.SqlClient;

namespace SubscribeTableDependencies
{
	public class SubscribeTestRecordTableDependency: ISubscribeTestRecordTableDependency
	{
		SqlTableDependency<TestRecord> tableDependency;
		SQLServerHub _sqlServerHub;

		public SubscribeTestRecordTableDependency(SQLServerHub sqlServerHub)
		{
			this._sqlServerHub = sqlServerHub;
		}

		public void SubscribeTableDependency(string connectionString)
		{
			tableDependency = new SqlTableDependency<TestRecord>(connectionString);
			tableDependency.OnChanged += TableDependency_OnChanged;
			tableDependency.OnError += TableDependency_OnError;
			tableDependency.Start();
		}

		private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<TestRecord> e)
		{
			if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
			{
				_sqlServerHub.ReceiveSQLServerChange();
			}
		}

		private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
		{
			Console.WriteLine($"{nameof(TestRecord)} SqlTableDependency error: {e.Error.Message}");
		}
	}
}
