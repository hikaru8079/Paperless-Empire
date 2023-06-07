
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = "460495496695-5heioc6j9rsmvd4uoudcbmehmloinofu.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
    }
}