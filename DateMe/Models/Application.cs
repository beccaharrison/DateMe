using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DateMe.Models;

public class Application
{
    [Key]
    [Required]
    public int ApplicationId {get; set;}
    [Required(ErrorMessage = "Sorry, you need to enter a first name")]
    public string FirstName {get; set;}
    public string? LastName {get; set;}

    [Range(0, 130, ErrorMessage = "You must enter a valid age")]
    public int Age { get; set; } = 0;
    [MaxLength(15)]
    public string? PhoneNumber {get; set;}
    [ForeignKey("MajorID")]
    public int? MajorId {get; set;}
    public Major? Major {get; set;}
    public bool CreeperStalker {get; set;}
    
}