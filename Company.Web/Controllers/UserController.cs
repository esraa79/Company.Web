using Company.Data.Enitity;
using Company.Service.Interfaces.Department.DTO;
using Company.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Company.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public UserController(UserManager<ApplicationUser> userManager,
                               ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string searchInp)
        {
            List<ApplicationUser> users;
            if (string.IsNullOrEmpty(searchInp))
                users = await _userManager.Users.ToListAsync();
            else
                users = await _userManager.Users
                    .Where(user => user.NormalizedEmail.Trim().Contains(searchInp.Trim().ToUpper()))
                    .ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(string? Id, string ViewName = "Details")
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is null)
                return NotFound();
            if(ViewName=="Update")
            {
                var userViewModel = new UserUpdateViewModel
                {
                    Id = user.Id,
                    UserName=user.UserName
                };
                return View(ViewName, userViewModel);
            }
            return View(ViewName, user);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string? Id)
        {

            return await Details(Id, "Update");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string? Id, UserUpdateViewModel AppUser)
        {
            if (Id != AppUser.Id)
                return NotFound();
                    

           if(ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByIdAsync(Id);
                    if(user is null)
                        return NotFound();
                    user.UserName = AppUser.UserName;
                    user.NormalizedUserName = AppUser.UserName.ToUpper();
                    var result= await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User Updated Successfuly");
                        return RedirectToAction("Index");
                    }

                    foreach (var error in result.Errors)
                        _logger.LogError(error.Description);


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

           return View(AppUser);
        }

        public async Task<IActionResult> Delete(string? Id)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(Id);
                if (user is null)
                    return NotFound();
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));

                foreach (var error in result.Errors)
                    _logger.LogError(error.Description);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
