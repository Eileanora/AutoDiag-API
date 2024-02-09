using System.Collections;
using IntelligentDiagnostician.DataModels.Models;

namespace IntelligentDiagnostician.DataModels.Models;

public class User : PrimaryKeyBaseEntity
{
    public string Fname { get; set; } = string.Empty;
    public string Lname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public int RoleId { get; set; }
    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
    public ICollection<Error> Errors { get; set; } = new List<Error>();
}
