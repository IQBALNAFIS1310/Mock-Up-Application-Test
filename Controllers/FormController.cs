using bodata_calon_karyawan.Interface.ViewModels;
using bodata_calon_karyawan.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace bodata_calon_karyawan.Controllers
{
    public class FormController : Controller
    {
        private readonly IFormService _formService;

        public FormController(IFormService formService)
        {
            _formService = formService;
        }

        // ==========================
        // INDEX (READ ONLY)
        // ==========================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToAction("Index", "Auth");

            var userId = Guid.Parse(userIdStr);

            var vm = await _formService.GetFormAsync(userId);

            ViewBag.HasBiodata = vm != null;

            return View(vm);
        }

        // ==========================
        // CREATE
        // ==========================
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.IsEdit = false;
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToAction("Index", "Auth");

            var userId = Guid.Parse(userIdStr);

            if (await _formService.HasBiodataAsync(userId))
                return RedirectToAction(nameof(Index));

            return View(new BiodataFormVM());
        }

        // ==========================
        // SAVE
        // ==========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BiodataFormVM vm)
        {
            var userIdStr = HttpContext.Session.GetString("UserId");

            if (string.IsNullOrEmpty(userIdStr))
                return RedirectToAction("Index", "Auth");

            var userId = Guid.Parse(userIdStr);

            await _formService.SaveAsync(vm, userId);

            TempData["Success"] = "Biodata berhasil disimpan.";

            return RedirectToAction(nameof(Index));
        }


    }
}