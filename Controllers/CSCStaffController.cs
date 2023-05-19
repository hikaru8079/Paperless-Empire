using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Paperless_Empire.Models;

namespace Paperless_Empire.Controllers;
public class CSCStaffController : Controller
{
    public IActionResult Index(){
        return View();
    }
}