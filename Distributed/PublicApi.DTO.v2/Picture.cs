using System;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.Domain;
using Microsoft.AspNetCore.Http;

namespace PublicApi.DTO.v2
{
    public class Picture : IDomainEntityId
    {

        public Guid ProductId { get; set; }
        public string Name { get; set; } = default!;
        public string? PictureName { get; set; }
        public IFormFile ImageFail { get; set; } = default!;
        public Guid Id { get; set; }
    }
}