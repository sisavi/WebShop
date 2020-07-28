using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.ViewModels
{
    public class ProductIndexViewModel
    {
        
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        
        public IEnumerable<Campaign>? Campaigns { get; set; }
        
        
    }
}