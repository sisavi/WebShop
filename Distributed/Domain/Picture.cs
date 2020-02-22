namespace Domain
{
    public class Picture
    {
        public int PictureId { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
        
        public byte[] ProductPicture { get; set; } = default!;
    }
}