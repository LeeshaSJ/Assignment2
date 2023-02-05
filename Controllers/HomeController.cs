using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object Context { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();      
        }

        [HttpPost]
        public IActionResult Login([Bind] Login ad)
        {
            db obj = new db();
            int res = obj.LoginCheck(ad);
            if (res == 1)
            {
                string str = ad.user_id;
                char firstChar = str[0];
                Console.WriteLine(firstChar);
                if (firstChar == 's')
                {
                    return RedirectToAction("Student", "Home");
                }
                else if (firstChar == 't')
                {
                    return RedirectToAction("Staff", "Home");
                }
            }
            else
            {
                TempData["msg"] = "Admin id or Password is wrong.!";
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Student()
        {
            return View();
        }

        public IActionResult Staff()
        {
            return View();
        }
        public IActionResult MyRequests()
        {
            return View();
        }
        public IActionResult StudentRequests()
        {
            return View();
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}