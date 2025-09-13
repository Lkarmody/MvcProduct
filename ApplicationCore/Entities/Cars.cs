using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Cars
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? Year { get; set; }
    public string? Color { get; set; }
    public bool Ownership { get; set; }
}
