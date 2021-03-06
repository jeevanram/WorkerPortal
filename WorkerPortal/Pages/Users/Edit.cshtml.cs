using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerPortal.Core;
using WorkerPortal.Data;

namespace WorkerPortal.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserData _userData;
        [BindProperty]
        public User User { get; set; }
        [BindProperty(SupportsGet =true)]
        public string ErrorMessage { get; set; }

        public EditModel(IUserData userData)
        {
            _userData = userData;
            ErrorMessage = string.Empty;
        }

        public IActionResult OnGet(int? userId)
        {
            if (userId.HasValue)
            {
                User = _userData.GetUserByUserId(userId.Value);
            }
            else
            {
                User = new User();
            }
            if(User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (User.UserId != 0)
            {
                _userData.UpdateUser(User);
                _userData.Commit();
                TempData["StatusMessage"] = $"User updated successfully - Username {User.Username}";
                return RedirectToPage("./List");
            }
            else
            {
                User newuser = _userData.NewUser(User);
                if (newuser == null)
                {
                    ErrorMessage = "Username exist !";
                    return Page();
                }
                else
                {
                    _userData.Commit();
                    TempData["StatusMessage"] = $"User added successfully - Username {User.Username}";
                    return RedirectToPage("./List");
                }
            }
        }
    }
}
