using System.Collections;
using AutoDiag.DataModels.Models;
using Microsoft.AspNetCore.Identity;

namespace AutoDiag.DataModels.Models;

public class AppUser :IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Reading>? Readings { get; set; }
    public ICollection<Fault>? Errors { get; set; }
}
