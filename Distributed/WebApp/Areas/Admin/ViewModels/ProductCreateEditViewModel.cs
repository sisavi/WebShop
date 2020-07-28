
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class ProductCreateEditViewModel
    {
        public Product Product { get; set; }
        
        public SelectList CategoryNameSelectList { get; set; } = default!;
        
    }
}