using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;
using System.Text.Encodings.Web;
using System.Security.Claims;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;

namespace Paperless_Empire.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            // ユーザーが認証済みの場合、アカウント情報を参照して利用します。
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            // アクセストークンを使用してGoogle APIにリクエストを送信し、ユーザーの情報を取得します。
            return View();
        }
        else
        {
            // ユーザーが認証されていない場合、認証ページにリダイレクトします。
            return Challenge();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
