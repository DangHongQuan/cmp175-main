using System.ComponentModel.DataAnnotations;
namespace cmp175.Models;


public class Source
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string NameSource { get; set; }
    public string Price { get; set; }
    public string Description { get; set; }
    public string quantityVideo { get; set; }
    public string TimeVideo { get; set; }
    public string? imageUrl { get; set; }
    public bool paid { get; set; }
    public string lessonId { get; set; }
    public string category { get; set;}

}
