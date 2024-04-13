using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmp175.Models;

public class ExampleContent
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string Name { get; set; }
    public string Content { get; set; }
    public string imgExample { get; set; }
    public string Description { get; set; }
    public int ExampleId { get; set; }
    [ForeignKey("ExampleId")]
    public Example Example { get; set; }
}