using Microsoft.AspNetCore.Mvc;
using System.Text;
using Paperless_Empire.Models;
namespace Paperless_Empire.Controllers;
public class RegistrationController : Controller{
    public IActionResult Index(RegistrationModel Model){
        return View();
    }

    [HttpPost]
    public IActionResult Check(RegistrationModel Model){
        //Model.Number = Request.Form["Number"];
        //Model.Department = Request.Form["Department"];
        //Model.Grade = Request.Form["Grade"];
        //Model.Class = Request.Form["Class"];
        //Model.Name = Request.Form["Name"];
        //Model.Date = Request.Form["Date"];
        //Model.Subject1 = Request.Form["Subject1"];
        //Model.Subject2 = Request.Form["Subject2"];
        //Model.Subject3 = Request.Form["Subject3"];
        //Model.Subject4 = Request.Form["Subject4"];
        //Model.Activity = Request.Form["Activity"];
        //Model.Company = Request.Form["Company"];
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