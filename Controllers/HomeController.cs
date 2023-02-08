using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyDBContext _context;
        public object Context { get; private set; }

        public HomeController(ILogger<HomeController> logger, MyDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();      
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] Login ad)
        {
           
            var user = await _context.UserModel.FirstOrDefaultAsync(i => i.Id == ad.user_id && i.Password == ad.Password);
            //db obj = new db();
            //int res = obj.LoginCheck(ad);
            if (user !=null)
            {
                HttpContext.Session.SetString("userId", user.Id);
                HttpContext.Session.SetString("userName", user.FullName);

                string str = ad.user_id;
                char firstChar = str[0];
                //Console.WriteLine(firstChar);
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

        public async Task<IActionResult> Student()
        {
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");
            ViewData["sessionUserName"] = HttpContext.Session.GetString("userName");

            return View(await _context.Resources.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Home/StudentRequest")]
        public async Task<IActionResult> StudentRequest([Bind("Id")] ResourceRequest resources)
        {
            if (resources == null )
            {
                return NotFound();
            }

            //try
            //{
            //    //var user = await _context.UserModel.Where(i=>i.Email==email&& i.Password==password);
            //    var user = await _context.Res.FindAsync(id);
            //    if (user != null)
            //    {
            //        user.FullName = userModel.FullName;
            //        user.Email = userModel.Email;
            //        user.Department = userModel.Department;

            //        await _context.SaveChangesAsync();
            //    }

            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!UserModelExists(userModel.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Staff()
        {
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");
            ViewData["sessionUserName"] = HttpContext.Session.GetString("userName");

            return View();
        }

        /*public IActionResult MyRequests()
        {
            return View();
        }*/

        public async Task<IActionResult> MyRequests(string searchTerm)
        {
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");

            var requests = _context.Request
                .Include(res => res.Resource);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                requests = (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Request, Models.Resources?>)requests.Where(r => r.StudentId.Contains(searchTerm));
            }

            var model = await requests.ToListAsync();

            return View(model);
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