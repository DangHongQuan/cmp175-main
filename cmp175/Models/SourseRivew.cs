using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cmp175.Models;


public class SourseReview
{
    public int Id { get; set; }
        
    public int SourseId { get; set; }
    public Sourse? Sourse { get; set; }
        
    public int UserId { get; set; }
    public IdentityUser? User { get; set; }
    
}