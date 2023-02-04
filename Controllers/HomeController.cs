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

     
        public IActionResult Login()
        {
            return View();
                
        }
     
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            //errrorrrrrrrrrrr whyyyyyyyyyyyyyyy dkdkkow (●'◡'●)😒＞﹏＜(；′⌒`)(；′⌒`)
            var issuccess = LoginCheck.UserModel(username, password);


            if (issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in", username);

                TempData["username"] = "Ahmed";
                return RedirectToAction("Index", "Layout");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return View();
            }
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