//add1
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
//add1
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
//add2
var services = builder.Services;
var configuration = builder.Configuration;
builder.Services.AddHttpClient();
services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "460495496695-5heioc6j9rsmvd4uoudcbmehmloinofu.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });
//add2
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//add3
app.UseStatusCodePages();
//app.UseFileServer();
app.UseAuthentication();
app.UseHttpLogging();
//add3
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();