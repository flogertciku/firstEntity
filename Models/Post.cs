#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace firstEntity.Models;
public class Post
{
    [Key]
    public int PostId { get; set; }
    [Required]
    [MinLength(4,ErrorMessage =" Content duhet te jete me i gjate se 3 shkronja")]
    public string Content { get; set; } 

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
                
