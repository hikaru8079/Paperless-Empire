using Paperless_Empire.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Paperless_Empire.Controllers;
public class RegistrationController : Controller{
    private IConfiguration _configuration;
    public RegistrationController(IConfiguration configuration){
            _configuration = configuration;
    }
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Check(RegistrationModel Model){
        //完了ボタンを押すとモデルの値が全部nullになるのでセッションに入力情報を格納
        var modelData = JsonConvert.SerializeObject(Model);
        HttpContext.Session.SetString("RegistrationModel", modelData);
        //
        return View(Model);
    }
    public async Task<IActionResult> Complete(RegistrationModel Model){
        var modelData = HttpContext.Session.GetString("RegistrationModel");
        var model = JsonConvert.DeserializeObject<RegistrationModel>(modelData!);
        /*
        ↑より下で、Slack送信文の上にデータベース追加処理を書いてね
        これとSlack送信が終わったらページ表示させるように同期処理するか処理中ページを用意する
        */
        //↓教師へ承認案内Slack通知送信
        var Client = new HttpClient();
        var token = _configuration.GetConnectionString("SLACK_TOKEN");
        string channel = "#slackapi-test";
        var text = $"【公欠届承認案内】\n新着の公欠届があります。\n\n----概要----\n学籍番号: {model!.Number}\n氏名: {model.Name}\n公欠日: {model.Date}\n\n詳細をこちらのURLから承認ページへアクセスし、承認/却下操作を行ってください。\nhttps://paperless-empire.site/TeachingStaff";
        var data = new StringContent($"token={token}&channel={channel}&text={text}",Encoding.UTF8,"application/x-www-form-urlencoded");
        var response = await Client.PostAsync("https://slack.com/api/chat.postMessage", data);
        var responseInString = await response.Content.ReadAsStringAsync();
        var ParsedR = JObject.Parse(responseInString);
        Console.WriteLine(ParsedR);
        //最後にセッションから値を削除
        HttpContext.Session.Remove("RegistrationModel");
        return View();
    }
}