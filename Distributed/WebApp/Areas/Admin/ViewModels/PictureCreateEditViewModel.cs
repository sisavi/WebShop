using BLL.App.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Admin.ViewModels
{
    public class PictureCreateEditViewModel
    {
        public Picture Picture { get; set; } = default!;
        
        public SelectList? ProductSelectList { get; set; } = default!;
    }
}