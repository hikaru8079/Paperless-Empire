using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paperless_Empire.Models;
using System.Diagnostics;
namespace Paperless_Empire.Controllers;

public class HomeController : Controller{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Index(){
        // Googleアカウントの情報を取得(下のメソッドを走らせる)
        GoogleUserInfo userInfo = GetGoogleUserInfoFromHeaders(Request).Result;
        // ビューモデルを作成し、Googleアカウントの情報を格納
        var viewModel = new GoogleAccountViewModel{
            Name = userInfo.Name,
            Email = userInfo.Email,
        };
        return View(viewModel);
    }

    public async Task<GoogleUserInfo> GetGoogleUserInfoFromHeaders(HttpRequest request){
        var idToken = request.Headers["X-MS-TOKEN-GOOGLE-ID-TOKEN"].FirstOrDefault();
        var accessToken = request.Headers["X-MS-TOKEN-GOOGLE-ACCESS-TOKEN"].FirstOrDefault();
        using (var httpClient = new HttpClient()){
            var endpoint = "https://www.googleapis.com/oauth2/v3/userinfo";
            var userInfoRequest = new HttpRequestMessage(HttpMethod.Get, endpoint);
            userInfoRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var userInfoResponse = await httpClient.SendAsync(userInfoRequest);
            if (userInfoResponse.IsSuccessStatusCode){
                var content = await userInfoResponse.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<GoogleUserInfo>(content);
                return userInfo;
            }else{
                throw new Exception("Google API request failed.");
            }
        }
    }
}

public class GoogleUserInfo{
    public string? Name { get; set; }
    public string? Email { get; set; }
    // 他のプロパティも必要な場合は追加
}