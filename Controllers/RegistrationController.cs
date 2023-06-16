using System.Net.Cache;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;

namespace Paperless_Empire.Controllers;
public class RegistrationController : Controller
{
    public IActionResult Index(){
        return View();
    }

    [HttpPost]
    public IActionResult ToCheck(){
        ViewData["Number"] = Request.Form["Number"];
        ViewData["Department"] = Request.Form["Department"];
        ViewData["Grade"] = Request.Form["Grade"];
        ViewData["Class"] = Request.Form["Class"];
        ViewData["Name"] = Request.Form["Name"];
        ViewData["Date"] = Request.Form["Date"];
        ViewData["Period"] = Request.Form["Period"];
        ViewData["Subject"] = Request.Form["Subject"];
        ViewData["Activity"] = Request.Form["Activity"];
        ViewData["Company"] = Request.Form["Company"];
        return View("Check");
    }
    public async Task<IActionResult> Send(){
        //ここにデータベース追加処理を書いてね
        //終わったらページ表示させるように非同期でよろしく
        return View("Complete");
    }
}
