using bodata_calon_karyawan.Models.Data;
using bodata_calon_karyawan.Models.Db;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bodata_calon_karyawan.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // GET
        public IActionResult Register()
        {
            return View();
        }

        // POST REGISTER
        [HttpPost]
        public async Task<IActionResult> Register(
            string email,
            string password,
            string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ViewBag.Error = "Konfirmasi password tidak sama";
                return View();
            }

            var cekEmail = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);

            if (cekEmail != null)
            {
                ViewBag.Error = "Email sudah terdaftar";
                return View();
            }

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // POST LOGIN
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {


            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.Email == email &&
                    x.Password == password);


            if (email == "admin@gmail.com" &&
                        password == "admin")
            {
                HttpContext.Session.SetString("Role", "Admin");

                return RedirectToAction("Index", "Admin");
            }

            if (user == null)
            {
                ViewBag.Error = "Email atau Password salah";
                return View("Index");
            }

            HttpContext.Session.SetString(
                "UserId",
                user.Id.ToString());

            return RedirectToAction("Index", "Form");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");

            return RedirectToAction("Index", "Auth");
        }
    }
}