using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Paperless_Empire.Controllers;



public class ReportController : Controller
{
    public async  Task<IActionResult> Test(){
        using (var httpClient = new HttpClient()){
            //./auth/meエンドポイントにリクエストを送信
            var response = await httpClient.GetAsync("https://paperless-empire-test.azurewebsites.net/.auth/me"); 
            //応答処理
            if (response.IsSuccessStatusCode){
                //コンテンツ読み取り
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);

                //jsonからの認証情報取得
                var authInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(content);

                //必要な認証情報を取得
                var providerName = authInfo[0].provider_name;  
                var userId = authInfo[0].user_id;
                var accessToken = authInfo[0].access_token;
                var expiresOn = authInfo[0].expires_on;

                ViewBag.providerName = providerName;
                ViewBag.userId = userId;
                ViewBag.accessToken = accessToken;
                ViewBag.expiresOn = expiresOn;

                return View();
            }else{
                var statusCode = response.StatusCode;
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {statusCode} - {errorMessage}");

            }
            
        }
        return View();
    }
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult Check()
    {

        return View();
    }
    public IActionResult Entry()
    {
        
        return View();
    }
    public IActionResult Complete()
    {
        return View();
    }
    


}

