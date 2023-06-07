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

//app.UseFileServer();
//app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();