using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dashboard_project.Areas.Identity.Data;

// Add profile data for application users by adding properties to the Dashboard_projectUser class
public class Dashboard_projectUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

