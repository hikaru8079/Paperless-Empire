using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;

namespace Paperless_Empire.Controllers;
public class TeachingStaffController : Controller
{
    public IActionResult Index(){
        return View();
    }
}