using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LearningWebAppRazor.Data;
var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDBContext") ?? throw new InvalidOperationException("Connection string 'AppDBContext' not found.")));

var app = builder.Build();

// Ensure database is created and migrations are applied
//using( IServiceScope scope = app.Services.CreateScope() )
//{
//	AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
//	context.Database.EnsureCreated();
//	// Optionally, apply migrations
//	context.Database.Migrate();
//}
// Add this after app.Build() in Program.cs
try
{
	using( IServiceScope scope = app.Services.CreateScope() )
	{
		AppDBContext context = scope.ServiceProvider.GetRequiredService<AppDBContext>();
		bool canConnect = context.Database.CanConnect();
		if( !canConnect )
		{
			throw new Exception( "Cannot connect to database" );
		}
	}
}
catch( Exception ex )
{
	// Log the exception or handle it appropriately
	Console.WriteLine( $"Database connection error: {ex.Message}" );
}
// Configure the HTTP request pipeline.
if( !app.Environment.IsDevelopment() )
{
	app.UseExceptionHandler( "/Error" );
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
