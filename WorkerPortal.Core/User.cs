
using System.ComponentModel.DataAnnotations;

namespace WorkerPortal.Core
{
    public class User
    {
        public int UserId { get; set; }
        [Required, StringLength(50)]
        public string FirstName { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Email { get; set; }
        [Required, StringLength(15)]
        public string Phone { get; set; }
        [Required, StringLength(100)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required, StringLength(20)]
        public string City { get; set; }
        [Required, StringLength(20)]
        public string County { get; set; }
        [Required, StringLength(2)]
        public string State { get; set; }
        [Required, StringLength(5)]
        public string PostalCode { get; set; }
        [Required, StringLength(20)]
        public string Country { get; set; }
        [Required, StringLength(20)]
        public string Username { get; set; }
        public string Password { get; set; }
    }                                               
}
