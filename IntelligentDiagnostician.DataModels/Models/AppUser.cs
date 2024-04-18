using System.Collections;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.AspNetCore.Identity;

namespace IntelligentDiagnostician.DataModels.Models;

public class AppUser :IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public ICollection<Reading> Readings { get; set; }
}
