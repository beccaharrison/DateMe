using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateMe.Models;

public class Major
{
    [Key]
    [Required]
    public int MajorId { get; set; }
    public string? MajorName { get; set; }
}