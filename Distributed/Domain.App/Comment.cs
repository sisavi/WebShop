using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Domain.Base;

namespace Domain.App
{
    public class Comment : DomainEntityIdMetadata
    {
        
        [MaxLength(256)] public string CommentText { get; set; } = default!;
        
        public Guid ProductId { get; set; }
        
        public Product? Product { get; set; }
    }
}