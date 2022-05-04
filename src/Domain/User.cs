using System.ComponentModel.DataAnnotations;

namespace Domain;

public class User
{
    [Key]
    public string Id { get; set; } = null!;
    public Role Role { get; set; } = null!; 
}
