using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WorkerPortal.Core;
using WorkerPortal.Data;

namespace WorkerPortal.Pages.Users
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IUserData _userData;

        //OutputModel
        public IEnumerable<User> Users { get; set; }
        [BindProperty(SupportsGet =true)] // Act as both input and output model
        public string SearchTerm { get; set; }
        [TempData]
        public string StatusMessage { get; set; }

        public ListModel(IConfiguration config, IUserData userData)
        {
            _config = config;
            _userData = userData;
        }
        //public void OnGet(string searchTerm)//searchTerm - InputModel
        public void OnGet()
        {
            Users = _userData.GetUsersByUsername(SearchTerm);
        }
    }
}
