using System;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.sisavi.Domain.Base;
using Microsoft.AspNetCore.Http;

namespace Domain.App
{
    public class Picture : DomainEntityId
    {

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }

        public string Name { get; set; } = default!;
        public string? PictureName { get; set; }
        
        [NotMapped]
        public IFormFile ImageFail { get; set; } = default!;
    }
}