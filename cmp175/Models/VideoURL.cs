﻿namespace cmp175.Models;


public class VideoURL
{
    public int id { get; set; }
    public string? videoURL { get; set; }
    public string? Name { get; set; }
    public int? SourseId { get; set; }
    public Sourse? Sourse { get; set; }
}