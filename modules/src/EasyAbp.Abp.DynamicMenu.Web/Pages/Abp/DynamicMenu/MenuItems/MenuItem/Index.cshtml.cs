using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.Abp.DynamicMenu.Web.Pages.Abp.DynamicMenu.MenuItems.MenuItem
{
    public class IndexModel : DynamicMenuPageModel
    {
        [BindProperty(SupportsGet = true)]
        public string ParentId { get; set; }

        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
