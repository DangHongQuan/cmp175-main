

using System.ComponentModel.DataAnnotations;

namespace cmp175.Models;

public class Comment
{
    public int id { get; set; }
    [Required, StringLength(100)] 
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Title { get; set; }
    public string? Message { get; set; }


    
}

