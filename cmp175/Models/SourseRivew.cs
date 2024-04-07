using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cmp175.Models;


public class SourceReview
{
    public int Id { get; set; }
        
    public int SourceId { get; set; }
    public Source? Source { get; set; }
        
    public int UserId { get; set; }
    public IdentityUser? User { get; set; }
    
}