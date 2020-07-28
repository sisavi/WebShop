using System;
using System.ComponentModel.DataAnnotations;
using ee.itcollege.sisavi.Contracts.DAL.Base;
using ee.itcollege.sisavi.Contracts.Domain;


namespace DAL.App.DTO
{
    public class Comment : IDomainEntityId
    {
        
        [MaxLength(256)] public string CommentText { get; set; } = default!;
        
        public Guid ProductId { get; set; }
        
        public Product? Product { get; set; }
        public Guid Id { get; set; }
    }
}