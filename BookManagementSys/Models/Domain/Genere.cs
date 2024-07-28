using System.ComponentModel.DataAnnotations;

namespace BookManagementSys.Models.Domain
{
    public class Genere
    {
        public  int Id { get; set; }
        [Required,MaxLength(100)]
        public string GenreName { get; set; }
    }
}
