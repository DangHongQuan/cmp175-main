using System.ComponentModel.DataAnnotations;
namespace cmp175.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Email { get; set; }
    }
}