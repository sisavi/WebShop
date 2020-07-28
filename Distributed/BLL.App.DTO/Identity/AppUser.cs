using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO.Identity
{

    public class AppUser : IDomainEntityId
    {

        // add your own fields
        [MaxLength(128)] [MinLength(1)] [Required] public string FirstName { get; set; } = default!;

        [MaxLength(128)] [MinLength(1)] [Required] public string LastName { get; set; } = default!;


        public Guid Id { get; set; }

        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
    }
}