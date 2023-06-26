using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;
namespace Paperless_Empire.Controllers;

public class RegistrationController : Controller{
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Check(RegistrationViewModel model){
        ViewData["Number"] = Request.Form["Number"];
        ViewData["Department"] = Request.Form["Department"];
        ViewData["Grade"] = Request.Form["Grade"];
        ViewData["Class"] = Request.Form["Class"];
        ViewData["Name"] = Request.Form["Name"];
        ViewData["Date"] = Request.Form["Date"];
        ViewData["Subject1"] = Request.Form["Subject1"];
        ViewData["Subject2"] = Request.Form["Subject2"];
        ViewData["Subject3"] = Request.Form["Subject3"];
        ViewData["Subject4"] = Request.Form["Subject4"];
        ViewData["Activity"] = Request.Form["Activity"];
        ViewData["Company"] = Request.Form["Company"];
        return View(model);
    }
    public async Task<IActionResult> Complete(RegistrationViewModel model,string[] args){
        //ここにデータベース追加処理を書いてね
        //多分値はViewDataを使って渡してあげればいいかも？
        //無理なら変数に代入してあげるのもアリ
        //終わったらページ表示させるように同期処理するか処理中ページを用意する

        //↓はSlackのメッセージ送信関数を動かすんで動かすときにコメント解除してね
        Rootobject rootobject = SendMessageToSlack("クラウド環境のWebアプリケーションからテストだよ～ん");
        return View();
    }
    public static WebClient s_webClient = new WebClient();
    public static Rootobject SendMessageToSlack(string? text){
        var data = new NameValueCollection();
            data["token"] = "xoxb-5471836121122-5504690798032-F18Lkywn3kMEXqLlSG5rlNra";
            data["channel"] = "#slackapi-test";
            data["text"] = text;
            var response = s_webClient.UploadValues("https://slack.com/api/chat.postMessage", "POST", data);
            string responseInString = Encoding.UTF8.GetString(response);
            return JsonSerializer.Deserialize<Rootobject>(responseInString);
    }
}

//なんかよくわからんが必要なクラスらしい
public class Rootobject{
    public bool ok { get; set; }
    public string? channel { get; set; }
    public string? ts { get; set; }
    public Message? message { get; set; }
}
public class Message{
    public string? bot_id { get; set; }
    public string? type { get; set; }
    public string? text { get; set; }
    public string? user { get; set; }
    public string? ts { get; set; }
    public string? team { get; set; }
    public Bot_Profile? bot_profile { get; set; }
}
public class Bot_Profile{
    public string? id { get; set; }
    public bool deleted { get; set; }
    public string? name { get; set; }
    public int updated { get; set; }
    public string? app_id { get; set; }
    public Icons? icons { get; set; }
    public string? team_id { get; set; }
}
public class Icons{
    public string? image_36 { get; set; }
    public string? image_48 { get; set; }
    public string? image_72 { get; set; }
}