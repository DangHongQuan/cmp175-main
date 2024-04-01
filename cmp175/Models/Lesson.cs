using System.ComponentModel.DataAnnotations;

namespace LTW_Projeck_CPM174.Models;

public class Lesson
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
}