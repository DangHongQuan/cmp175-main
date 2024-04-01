using System.ComponentModel.DataAnnotations;
using LTW_Projeck_CPM174.Models;

namespace cmp175.Models;

public class Example
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}