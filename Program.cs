using DDVTracker.Data;
using DDVTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DDVTracker;
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Extensions.AspNetCore.Configuration.Secrets;

var builder = WebApplication.CreateBuilder(args);

// Configure Key Vault
var keyVaultUri = Environment.GetEnvironmentVariable("VaultUri");
if (string.IsNullOrEmpty(keyVaultUri))
{
    throw new ArgumentNullException("VaultUri", "The Azure Key Vault URI is not set in the environment variables.");
}

var keyVaultEndpoint = new Uri(keyVaultUri);
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Load configuration based on environment
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

if (builder.Environment.IsProduction())
{
    // Register Azure Blob Storage service for production
    builder.Services.AddSingleton<IFileStorageService, AzureBlobStorageService>();
}
else
{
    // Register local file storage service for development
    builder.Services.AddSingleton<IFileStorageService, LocalFileStorageService>();
}

// Add a filter to show detailed database errors in development
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Register the DreamlightDbContext for both environments
builder.Services.AddDbContext<DreamlightDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["azureblob:blob"]!, preferMsi: true);
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