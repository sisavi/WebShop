using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.ViewModels
{
    public class AccountEditCreateViewModels
    {
        public Account Account { get; set; } = default!;

        public SelectList? AppUsersSelectList { get; set; }
    }
}