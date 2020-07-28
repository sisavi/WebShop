using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{

    public class AppUser : IdentityUser<Guid>, IDomainEntityId
    {

        // add your own fields
        [MaxLength(128)] [MinLength(1)] public string FirstName { get; set; } = default!;

        [MaxLength(128)] [MinLength(1)] public string LastName { get; set; } = default!;
        

        
    }
}