using DAL.Base;

namespace Domain
{
    public class Picture : DomainEntity
    {

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        
        public byte[] ProductPicture { get; set; } = default!;
    }
}