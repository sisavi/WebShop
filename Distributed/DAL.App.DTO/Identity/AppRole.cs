using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;

namespace DAL.App.DTO.Identity
{
    public class AppRole :  IDomainEntityId
    {
        [MaxLength(256)] public string DisplayName { get; set; } = default!;

        public Guid Id { get; set; }
    }

}