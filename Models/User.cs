#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace firstEntity.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [MinLength(4,ErrorMessage =" Emri duhet te jete me i gjate se 3 shkronja")]

    public string Name { get; set; }
    public string Email { get; set; }  
    public int Height { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
