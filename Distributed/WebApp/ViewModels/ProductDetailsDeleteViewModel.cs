using System.Collections.Generic;
using BLL.App.DTO;

namespace WebApp.ViewModels
{
    public class ProductDetailsDeleteViewModel
    {
        public IEnumerable<Category>? Categories { get; set; }
           
        public Product Product { get; set; }
        
        public string? CategoryName { get; set; }
        
    }
}