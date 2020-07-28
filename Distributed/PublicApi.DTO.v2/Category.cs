using System;
using System.Collections.Generic;
using BLL.App.DTO;
using ee.itcollege.sisavi.Contracts.Domain;

namespace PublicApi.DTO.v2
{
    public class Category : IDomainEntityId
    {
        public string CategoryName { get; set; } = default!;
        public Guid Id { get; set; }
    }
}