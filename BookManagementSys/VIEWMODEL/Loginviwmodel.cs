using System.ComponentModel.DataAnnotations;

namespace assigment.VIEWMODEL
{
    public class Loginviwmodel
    {
        [Required ]
        public string Username { get; set; }
        [DataType(DataType.Password  )]
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set;}
    }
}
