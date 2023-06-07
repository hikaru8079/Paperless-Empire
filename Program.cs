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
app.UseFileServer();
app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();