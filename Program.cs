using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient();
var app = builder.Build();
if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePages();
app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
void ConfigureServices(IServiceCollection services)
{
    // ...

    services.AddAuthentication(options =>
    {
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddGoogle(options =>
    {
        options.ClientId = "460495496695-5heioc6j9rsmvd4uoudcbmehmloinofu.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

    // ...
}
app.Run();