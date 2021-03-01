using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoterPortal.Core;
using VoterPortal.Data;

namespace VoterPortal.Pages.Users
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
