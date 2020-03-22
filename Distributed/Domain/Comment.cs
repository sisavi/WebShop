using System.ComponentModel.DataAnnotations;
using DAL.Base;

namespace Domain
{
    public class Comment : DomainEntity
    {
        
        [MaxLength(128)] public string CommentText { get; set; } = default!;
        
        public int ProductId { get; set; }
        
        public Product? Product { get; set; }
    }
}