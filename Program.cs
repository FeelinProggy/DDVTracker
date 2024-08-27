using DDVTracker.Data;
using DDVTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Storage.Blobs;
using Azure.Security.KeyVault.Secrets;


var builder = WebApplication.CreateBuilder(args);

//// Start Azurite only in non-production environments
//AzuriteController azuriteController = null;
//if (!builder.Environment.IsProduction())
//{
//    azuriteController = new AzuriteController();
//    azuriteController.Start();
//}
//
// Load configuration based on environment
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

string connectionString;
string blobStorageConnectionString;

if (builder.Environment.IsProduction())
{
    // Retrieve the VaultUri from environment variables
    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
    builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

    // Retrieve the connection string from Key Vault
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in Key Vault.");

    // Configure Entity Framework to use SQL Server with the connection string
    builder.Services.AddDbContext<DreamlightDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Retrieve the Blob Storage connection string from Key Vault
    var secretClient = new SecretClient(keyVaultEndpoint, new DefaultAzureCredential());
    KeyVaultSecret secret = secretClient.GetSecret("BlobStorageConnectionString");
    blobStorageConnectionString = secret.Value;

    // Add the Blob Storage connection string to the configuration
    builder.Configuration["AzureBlobStorage:ConnectionString"] = blobStorageConnectionString;
}
else
{
    // Get the connection string from configuration for non-production environments
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    // Configure Entity Framework to use SQL Server with the connection string
    builder.Services.AddDbContext<DreamlightDbContext>(options =>
        options.UseSqlServer(connectionString));

    // Get the Blob Storage connection string from configuration
    blobStorageConnectionString = builder.Configuration.GetConnectionString("BlobStorageConnectionString")
        ?? throw new InvalidOperationException("Azure Storage connection string 'BlobStorageConnectionString' not found in configuration.");

    // Add the Blob Storage connection string to the configuration
}

// Add a filter to show detailed database errors in development
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity services with default settings
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>() // Add role management
    .AddEntityFrameworkStores<DreamlightDbContext>(); // Use Entity Framework for Identity

// Configure authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
               policy => policy.RequireRole(IdentityHelper.Master, IdentityHelper.Admin));
    options.AddPolicy("RequireModeratorRole",
               policy => policy.RequireRole(IdentityHelper.Master, IdentityHelper.Admin, IdentityHelper.Moderator));
});

// Add MVC controllers with views
builder.Services.AddControllersWithViews();

// Configure Identity options
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._";
    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline

// Redirect HTTP requests to HTTPS
app.UseHttpsRedirection();

// Serve static files (e.g., CSS, JavaScript, images)
app.UseStaticFiles();

// Configure routing
app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Define the default route for MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Enable Razor Pages
app.MapRazorPages();

// Create a service scope to resolve scoped services
using (var serviceScope = app.Services.GetRequiredService<IServiceProvider>().CreateScope())
{
    // Create roles
    await IdentityHelper.CreateRoles(serviceScope.ServiceProvider, IdentityHelper.Master, IdentityHelper.Admin, IdentityHelper.Moderator, IdentityHelper.User);

    // Create default user
    await IdentityHelper.CreateDefaultUser(serviceScope.ServiceProvider, IdentityHelper.Master);
}
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
// Run the application
app.Run();

//// Stop Azurite when the application stops
//if (azuriteController != null)
//{
//    azuriteController.Stop();
//}