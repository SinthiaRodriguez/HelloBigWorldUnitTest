using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebAppNetCore5.Controllers
{
    public class FamilyTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
