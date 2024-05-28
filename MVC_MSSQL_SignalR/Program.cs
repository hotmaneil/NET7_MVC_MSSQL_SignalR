//using MVC_MSSQL_SignalR.HubClass;

using Hubs;
using MVC_MSSQL_SignalR.MiddlewareExtensions;
using SubscribeTableDependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// DI
builder.Services.AddSingleton<SQLServerHub>();
builder.Services.AddSingleton<SubscribeTestRecordTableDependency>();

//builder.Services
//	.AddSignalR()
//	.AddSqlServer(setting =>
//	{
//		setting.ConnectionString = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
//		setting.AutoEnableServiceBroker = true;
//		setting.TableSlugGenerator = hubType => hubType.Name;
//		setting.TableCount = 1;
//		setting.SchemaName = "TestRecord";
//	});

var app = builder.Build();
var connectionString = app.Configuration.GetConnectionString("DefaultConnection");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.MapHub<SQLServerHub>("/sqlServerHub");

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSqlTableDependency<SubscribeTestRecordTableDependency>(connectionString);

app.Run();
