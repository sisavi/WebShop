using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class BasketViewModel
    {
        public Basket? Basket { get; set; }
        public BLL.App.DTO.Order? Order { get; set; }
        public IEnumerable<ProductInBasket>? Products { get; set; }
        public double SubTotal { get; set; }
        public SelectList? DeliveryTypeSelectList { get; set; }

    }
}