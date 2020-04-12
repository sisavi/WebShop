using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BasketEditCreateViewModel
    {
        public Basket Basket { get; set; } = default!;
        public SelectList? AccountSelectList { get; set; }
        
    }
}