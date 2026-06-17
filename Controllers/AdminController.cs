using bodata_calon_karyawan.Interface;
using bodata_calon_karyawan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bodata_calon_karyawan.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        private bool IsAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }

        // ===========================
        // LIST DATA
        // ===========================
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Auth");

            var data = await _adminService.GetAllAsync();

            return View(data);
        }

        // ===========================
        // DETAIL
        // ===========================
        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Auth");

            var data = await _adminService.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        // ===========================
        // EDIT
        // ===========================
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.IsEdit = true;

            if (!IsAdmin())
                return RedirectToAction("Index", "Auth");

            var data = await _adminService.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BiodataFormVM vm)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Auth");

            await _adminService.UpdateAsync(vm);

            TempData["Success"] = "Data berhasil diperbarui.";

            return RedirectToAction(nameof(Index));
        }

        // ===========================
        // DELETE
        // ===========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!IsAdmin())
                return RedirectToAction("Index", "Auth");

            await _adminService.DeleteAsync(id);

            TempData["Success"] = "Data berhasil dihapus.";

            return RedirectToAction(nameof(Index));
        }
    }
}