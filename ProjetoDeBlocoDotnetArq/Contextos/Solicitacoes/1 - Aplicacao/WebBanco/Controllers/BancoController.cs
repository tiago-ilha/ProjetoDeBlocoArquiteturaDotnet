using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebBanco.Controllers
{
    public class BancoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}