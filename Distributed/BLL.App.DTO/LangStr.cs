using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ee.itcollege.sisavi.Contracts.Domain;


namespace BLL.App.DTO
{
    public class LangStr : IDomainEntityId
    {
        public Guid Id { get; set; }
        
        [InverseProperty(nameof(Category.CategoryName))]
        public ICollection<Category>? CategoryNames { get; set; }
        
        
        [InverseProperty(nameof(Product.Description))]
        public ICollection<Product>? Descriptions { get; set; }

        public ICollection<LangStrTranslation>? Translations { get; set; }

        [InverseProperty(nameof(Product.ProductName))]
        public ICollection<Product>? ProductNames { get; set; }

    }
}