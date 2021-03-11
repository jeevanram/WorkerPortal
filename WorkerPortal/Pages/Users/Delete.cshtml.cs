using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkerPortal.Core;
using WorkerPortal.Data;

namespace WorkerPortal.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserData userData;
        public User User { get; set; }

        public DeleteModel(IUserData userData)
        {
            this.userData = userData;
        }
        public IActionResult OnGet(int userId)
        {
            User = userData.GetUserByUserId(userId);
            if(User == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int userId)
        {
            User = userData.Delete(userId);
            userData.Commit();
            if(User == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["StatusMessage"] = $"{User.Username} deleted successfully";
            return RedirectToPage("./List");
        }
    }
}
