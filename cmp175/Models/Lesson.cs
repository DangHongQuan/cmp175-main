using System.ComponentModel.DataAnnotations;

namespace cmp175.Models;

public class Lesson
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
}