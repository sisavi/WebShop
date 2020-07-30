using System;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;
using Microsoft.AspNetCore.Http;

namespace BLL.App.DTO
{
    public class Picture : IDomainEntityId
    {

        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        
        public string Name { get; set; } = default!;
        public string? PictureName { get; set; } = default!;
        public string? ImagePath { get; set; }
        public IFormFile ImageFail { get; set; }  = default!;
        public Guid Id { get; set; }
    }
}