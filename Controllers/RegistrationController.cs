using Microsoft.AspNetCore.Mvc;
using System.Text;
using Paperless_Empire.Models;
namespace Paperless_Empire.Controllers;
public class RegistrationController : Controller{
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult Check(RegistrationModel Model){
        return View(Model);
    }
    public async Task<IActionResult> Complete(RegistrationModel Model){
        //ここにデータベース追加処理を書いてね
        //多分値はViewDataを使って渡してあげればいいかも？
        //無理なら変数に代入してあげるのもアリ
        //終わったらページ表示させるように同期処理するか処理中ページを用意する
        //↓教師へ承認案内Slack通知送信
        var Number = Model.Number;
        var Name = Model.Name;
        var Date = Model.Date;
        var Client = new HttpClient();
        string token = "xoxb-5471836121122-5504690798032-1owJCC6U5C28HnA6DDl2sllU";
        string channel = "#slackapi-test";
        string text = $"【公欠届承認案内】\n新着の公欠届があります。\n\n----概要----\n学籍番号: {Number}\n氏名: {Name}\n公欠日: {Date}\n\n詳細をこちらのURLから承認ページへアクセスし、承認/却下操作を行ってください。\nhttps://paperless-empire.site/TeachingStaff";
        var data = new StringContent($"token={token}&channel={channel}&text={text}", Encoding.UTF8, "application/x-www-form-urlencoded");
        var response = await Client.PostAsync("https://slack.com/api/chat.postMessage", data);
        var responseInString = await response.Content.ReadAsStringAsync();
        return View();
    }
}