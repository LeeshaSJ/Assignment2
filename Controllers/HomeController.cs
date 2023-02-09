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
            ViewData["navbarVisibility"] = "index";
            return View();      
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind] LoginModel ad)
        {
            var user = await _context.User.FirstOrDefaultAsync(i => i.UserId == ad.user_id && i.Password == ad.Password);
            //db obj = new db();
            //int res = obj.LoginCheck(ad);
            if (user != null)
            {
                HttpContext.Session.SetString("userId", user.UserId);
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

        public IActionResult ClearSession()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("userName");
            
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Student()
        {
            ViewData["navbarVisibility"] = "student";
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");
            ViewData["sessionUserName"] = HttpContext.Session.GetString("userName");

            return View(await _context.Resources.ToListAsync());
        }

        /*[HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Home/StudentRequest")]
        public async Task<IActionResult> StudentRequest([Bind("Id")] RequestModel resources)
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
        }*/

        public IActionResult Staff()
        {
            ViewData["navbarVisibility"] = "teacher";
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");
            ViewData["sessionUserName"] = HttpContext.Session.GetString("userName");

            return View();
        }

        /*public IActionResult MyRequests()
        {
            return View();
        }*/

        public async Task<IActionResult> MyRequests()
        {
            ViewData["navbarVisibility"] = "student";
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");

            var requests = _context.Request
                .Include(res => res.Resource);

            var model = await requests.ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> StudentRequests()
        {
            ViewData["navbarVisibility"] = "teacher";
            //Get value from Session object.
            var sessionUserId = HttpContext.Session.GetString("userId");
            ViewData["sessionUserId"] = sessionUserId;

            var requests = _context.Request
                .Include(res => res.Resource);

            var model = from t in _context.Teacher
                        join r in requests on t.Units equals r.UnitId
                        select new Tuple<TeacherModel, RequestModel>(t, r);

            return View(await model.ToListAsync());
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}