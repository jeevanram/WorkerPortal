using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerPortal.Core;
using WorkerPortal.Data;

namespace WorkerPortal.Pages.Users
{
    public class DetailModel : PageModel
    {
        private readonly IUserData _userData;
        public new User User { get; set; }
        
        public DetailModel(IUserData userData)
        {
            _userData = userData;
        }

        public IActionResult OnGet(int userId)
        {
            User = _userData.GetUserByUserId(userId);  
            if(User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
