using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.Domain;


namespace BLL.App.DTO
{
    public class Comment : IDomainEntityId
    {
        
        [MaxLength(256)] public string CommentText { get; set; } = default!;
        
        public Guid ProductId { get; set; }
        
        public Product? Product { get; set; }
        public Guid Id { get; set; }
    }
}