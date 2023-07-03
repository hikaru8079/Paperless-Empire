using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;

namespace Paperless_Empire.Controllers;
public class StaffController : Controller{
    public IActionResult Index(){
        return View();
    }
    public IActionResult Detail(){
        return View();
    }
    public IActionResult ReportView(){
        return View();
    }
}