using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cmp175.Models;


public class Oder
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public DateTime OderDateTime { get; set; }
    public decimal ToltalPrice { get; set; }
    public string UserId { get; set; }
    public IdentityUser? User { get; set; }
    public int SourseId { get; set; }
    public Sourse Sourse { get; set; }
    
    
}