using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace BLL.App.DTO.Identity
{
    public class AppRole :  IDomainEntityId
    {
        
        [MinLength(1)]
        [MaxLength(256)]
        [Required]
        public string DisplayName { get; set; } = default!;

        public Guid Id { get; set; }
    }

}