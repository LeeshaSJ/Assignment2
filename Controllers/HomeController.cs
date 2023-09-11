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
                TempData["msg"] = "Login Successful!";
            }
            else
            {
                ViewData["navbarVisibility"] = "index";
                TempData["msg"] = "Incorrect username or password!";
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

        [HttpPost]
        [Route("Home/StudentItemRequest")]
        public async Task<IActionResult> StudentItemRequest([FromBody] StudentRequestModel resources)
        {
            try
            {
                if (User != null)
                {
                    var userId = HttpContext.Session.GetString("userId");
                    RequestModel requestModel = new RequestModel();
                    requestModel.ResourceId = resources.Id;
                    requestModel.StudentId = userId;
                    requestModel.UnitId = resources.Unit;

                    _context.Request.Add(requestModel);
                    await _context.SaveChangesAsync();
                    return Ok("Success");
                }
            }
            catch (Exception e)
            {
                return Error();
            }
            
            return BadRequest();
        }

        [HttpPost]
        [Route("Home/RequestApproval")]
        public async Task<IActionResult> RequestApproval([FromBody] RequestUpdateModel request)
        {
            try
            {
                if (request != null)
                {
                    var userId = HttpContext.Session.GetString("userId");
                    var requestData = _context.Request.FirstOrDefault(i => i.RequestId == request.RequestId);
                    requestData.IsApproval = request.IsApproval;
                   
                    _context.Request.Update(requestData);
                    await _context.SaveChangesAsync();
                    return Ok("Success");
                }
            }
            catch (Exception e)
            {
                return Error();
            }
            
            return BadRequest();
        }

        [HttpPost]
        [Route("Home/Allocate")]
        public async Task<IActionResult> Allocate([FromBody] ResourceAllocationModel allocation)
        {
            if (User == null)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AllocationModel allocationModel = new AllocationModel();
            allocationModel.AllocationDate = DateTime.Now.Date;
            allocationModel.ReturnDate = DateTime.Now.Date.AddDays(7);
            allocationModel.StudentId = allocation.StudentId;
            allocationModel.ResourceId = allocation.ResourceId;

            _context.Allocation.Add(allocationModel);
            await _context.SaveChangesAsync();

            return Ok("Allocation successful");
        }

        [HttpGet]
        public IActionResult GetAllocations(string resourceId)
        {
            var data = _context.Allocation.FirstOrDefault(a => a.ResourceId == resourceId);
            return Json(data);
        }

        public IActionResult Staff()
        {
            ViewData["navbarVisibility"] = "teacher";
            //Get value from Session object.
            ViewData["sessionUserId"] = HttpContext.Session.GetString("userId");
            ViewData["sessionUserName"] = HttpContext.Session.GetString("userName");

            return View();
        }

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

            var requests = _context.Request.Where(i=>i.IsApproval==null)
                .Include(res => res.Resource);

            var model = await (from t in _context.Teacher
                        join r in requests on t.Units equals r.UnitId
                        select new Tuple<TeacherModel, RequestModel>(t, r)).ToListAsync();

            return View(model);
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}