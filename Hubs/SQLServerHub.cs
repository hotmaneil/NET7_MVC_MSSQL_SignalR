using Manager;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace Hubs
{
	public class SQLServerHub : Hub
	{
		TestRecordManager _testRecordManager;

		public SQLServerHub(IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			_testRecordManager = new TestRecordManager(connectionString);
		}

		/// <summary>
		/// 接收SQL Server Table資料變更
		/// </summary>
		/// <returns></returns>
		public async Task ReceiveSQLServerChange()
		{
			var testRecord = _testRecordManager.GetLatTestRecord();
			await Clients.All.SendAsync("GetLastNewTestRecord", testRecord);
		}
	}
}
