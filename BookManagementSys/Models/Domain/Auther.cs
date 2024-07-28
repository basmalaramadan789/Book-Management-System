using System.ComponentModel.DataAnnotations;

namespace BookManagementSys.Models.Domain
{
    public class Auther
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string  AutherName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}
