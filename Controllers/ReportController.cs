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
    public IActionResult Check(ReportViewModel model){
        ViewData["Address"] = Request.Form["Address"];
        ViewData["AptitudeTestContent"] = Request.Form["AptitudeTestContent"];
        ViewData["CommonSenseContent"] = Request.Form["CommonSenseContent"];
        ViewData["SpecialityContent"] = Request.Form["SpecialityContent"];
        ViewData["EssayContent"] = Request.Form["EssayContent"];
        ViewData["InterviewContent"] = Request.Form["InterviewContent"];
        ViewData["Advice"] = Request.Form["Advice"];
        return View(model);
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