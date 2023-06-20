using Microsoft.AspNetCore.Mvc;
namespace Paperless_Empire.Controllers;

public class RegistrationController : Controller
{
    public IActionResult Index(){
        return View();
    }

    //[HttpPost]
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
    public async Task<IActionResult> Complete(RegistrationViewModel model){
        //ここにデータベース追加処理を書いてね
        //多分ViewDataを使って渡してあげればいいかも？
        //無理なら変数に代入してあげるのもアリ
        //終わったらページ表示させるように非同期でよろしく
        return View();
    }
}
