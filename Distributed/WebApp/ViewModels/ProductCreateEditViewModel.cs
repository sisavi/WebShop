
using System;
using System.Collections.Generic;
using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class ProductCreateEditViewModel
    {
        public Product Product { get; set; }
        
        public Guid? CampaignId { get; set; }

        public double ProductPrice { get; set; } = default!;
        
        public string? CategoryName { get; set; }
        
        public SelectList? CategoryNameSelectList { get; set; }
        
        //public SelectList? PriceSelectList { get; set; } = default!;
        public SelectList? CampaignNameSelectList { get; set; }
        
        
    }
}