using System.ComponentModel.DataAnnotations;

namespace cmp175.Models;

public class ContentDetail
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string name { get; set; }
    public string title { get; set; }
    public string  Description { get; set; }
    public string Code { get; set; }
    public int ExampleContentId { get; set; }
    public ExampleContent ExampleContent { get; set; }
}