using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Paperless_Empire.Models;
using System.Diagnostics;
namespace Paperless_Empire.Controllers;

public class HomeController : Controller{

    //ここからロギングとエラー用Exception表示用構文
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger){
        _logger = logger;
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    //ここまで定型文

    //最初のホームページにアクセスした時に走るメソッド
    public IActionResult Index(){
        //Googleアカウントの情報を取得(下のメソッドを走らせる)
        GoogleUserInfo userInfo = GetGoogleUserInfoFromHeaders(Request).Result;
        //ビューモデルを作成し、取得したGoogleアカウントの情報を格納
        var viewModel = new GoogleAccountViewModel{
            Name = userInfo.Name,
            Email = userInfo.Email,
        };
        //格納した情報を渡した上でホームページ(Index.cshtml)を表示
        return View(viewModel);
    }
    //App Serviceでの認証セッションからGoogleアカウント情報を取得、利用するメソッド
    public async Task<GoogleUserInfo> GetGoogleUserInfoFromHeaders(HttpRequest request){
        //使わないけどIDトークン
        var idToken = request.Headers["X-MS-TOKEN-GOOGLE-ID-TOKEN"].FirstOrDefault();
        //EasyAuthのセッションのアクセストークンを取得するための固有リクエストヘッダを差し込んで、変数に代入
        var accessToken = request.Headers["X-MS-TOKEN-GOOGLE-ACCESS-TOKEN"].FirstOrDefault();
        //OAuth APIでアカウント情報をHTTP通信にて取得
        using (var httpClient = new HttpClient()){
            var endpoint = "https://www.googleapis.com/oauth2/v3/userinfo";
            var userInfoRequest = new HttpRequestMessage(HttpMethod.Get, endpoint);
            userInfoRequest.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var userInfoResponse = await httpClient.SendAsync(userInfoRequest);
            if (userInfoResponse.IsSuccessStatusCode){
                var content = await userInfoResponse.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<GoogleUserInfo>(content);
                return userInfo!;
            }else{
                throw new Exception("Google API request failed.");
            }
        }
    }
}

//ビューモデルにユーザ情報を渡すためのクラス
public class GoogleUserInfo{
    public string? Name { get; set; }
    public string? Email { get; set; }
    // 他のプロパティも必要な場合は追加
}