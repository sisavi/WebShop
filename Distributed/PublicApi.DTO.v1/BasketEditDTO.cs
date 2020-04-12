using System;

namespace PublicApi.DTO.v1
{
    public class BasketEditDTO
    {
        public Guid Id { get; set; }


        public Guid AccountId { get; set; } = default!;

    }
}