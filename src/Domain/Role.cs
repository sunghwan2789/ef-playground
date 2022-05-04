using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Role
{
    [Key]
    public string Name { get; set; } = null!;
    public Permission[] Permissions { get; set; } = Array.Empty<Permission>();
}
