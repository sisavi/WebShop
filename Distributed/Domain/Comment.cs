using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        [MaxLength(128)] public string CommentText { get; set; } = default!;
        
        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
    }
}