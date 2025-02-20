﻿using ISubscribeTableDependency;

namespace MVC_MSSQL_SignalR.MiddlewareExtensions
{
	public static class ApplicationBuilderExtension
	{
		public static void UseSqlTableDependency<T>(
			this IApplicationBuilder applicationBuilder, 
			string connectionString)
		   where T : ISubscribeTestRecordTableDependency
		{
			var serviceProvider = applicationBuilder.ApplicationServices;
			var service = serviceProvider.GetService<T>();
			service.SubscribeTableDependency(connectionString);
		}
	}
}
