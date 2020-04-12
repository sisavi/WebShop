using System;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace PublicApi.DTO.v1
{
    public class AccountDTO
    {
        public Guid Id { get; set; }
        [MinLength(1)][MaxLength(128)]
        public string FirstName { get; set; } = default!;
        [MinLength(1)][MaxLength(128)]
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        
        public AppUser AppUser { get; set; }
    }
}