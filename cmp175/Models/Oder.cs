using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cmp175.Models;


public class Oder
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public String ToltalPrice { get; set; }
    public String Name { get; set; }
    public String  Address { get; set; }
    public String Phone { get; set; }
    public string? UserId { get; set; }
    public IdentityUser? User { get; set; }
    public int SourceId { get; set; }
    public Source? Source { get; set; }
    
    
}