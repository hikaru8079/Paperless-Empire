using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;

namespace Paperless_Empire.Controllers;
public class ReportController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Check()
    {
        return View();
    }
    public IActionResult Entry()
    {
        return View();
    }
}