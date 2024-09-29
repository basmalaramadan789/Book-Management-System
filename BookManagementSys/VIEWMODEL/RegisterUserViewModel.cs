using System.ComponentModel.DataAnnotations;

namespace assigment.VIEWMODEL
{
    public class RegisterUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password  )]
        [Required]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("password")]
        public string confirmpassword { get; set; }
        public string Address { get; set; }
    }
}
