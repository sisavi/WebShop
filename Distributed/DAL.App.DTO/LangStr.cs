using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using ee.itcollege.sisavi.Contracts.Domain;


namespace DAL.App.DTO
{
    public class LangStr : IDomainEntityId
    {
        public Guid Id { get; set; }

        public ICollection<LangStrTranslation>? Translations { get; set; }
        
        [InverseProperty(nameof(Category.CategoryName))]
        public ICollection<Category>? CategoryNames { get; set; }
        
        
        [InverseProperty(nameof(Product.Description))]
        public ICollection<Product>? Descriptions { get; set; }

        [InverseProperty(nameof(Product.ProductName))]
        [JsonIgnore]
        public ICollection<Product>? ProductNames { get; set; }

    }
}