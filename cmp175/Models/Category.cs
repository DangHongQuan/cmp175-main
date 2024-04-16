using System.ComponentModel.DataAnnotations;

namespace cmp175.Models;

public class Category
{
    public int Id { get; set; }
    [Required, StringLength(100)] 
    public string Name { get; set; }
    public int? SourceId { get; set; }
    public Source? Source { get; set; }
    
}