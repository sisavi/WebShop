using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.Domain;
using Microsoft.AspNetCore.Identity;

namespace Domain.App.Identity
{
    public class AppRole : IdentityRole<Guid>, IDomainEntityId
    {
        [MaxLength(256)]
        public string? DisplayName { get; set; }
    }

}