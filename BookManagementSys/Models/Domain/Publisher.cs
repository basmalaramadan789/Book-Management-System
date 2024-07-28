using System.ComponentModel.DataAnnotations;

namespace BookManagementSys.Models.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string PublisherName { get; set; }
    }
}
