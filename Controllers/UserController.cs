using BankSmall.Data;
using BankSmall.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSmall.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService userService;

        public UserController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            this.userService = userService;
        }

        // GET: عرض القائمة
        public async Task<IActionResult> Index()
        {
            var vm = new ViewModel
            {
                NewUser = new User(),
                Users = await userService.GetAllAsync()
            };
            return View(vm);
        }

        // GET: صفحة الإضافة
        public IActionResult Create()
        {
            return View();
        }

        // POST: إنشاء مستخدم جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await userService.AddAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: صفحة التعديل
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var user = await _context.Users.FindAsync(id.Value);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: تنفيذ التعديل
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // POST: حذف
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _context.Users.FindAsync(id);
            if (u != null)
            {
                _context.Users.Remove(u);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
