using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cmp175.Models;

public class ContentDetail
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string name { get; set; }
    public string title { get; set; }
    public string  Description { get; set; }
    public string Code { get; set; }
    public int ExampleId { get; set; }
    [ForeignKey("ExampleId")]
    public Example Example { get; set; }
}