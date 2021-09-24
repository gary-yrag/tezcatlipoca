using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class EditorialListModel : PageModel
    {
        private readonly ILogger<EditorialListModel> _logger;
       
        public EditorialListModel(ILogger<EditorialListModel> logger)
        {
            _logger = logger;
        }       
        public IQueryable<Editoriale> au { get; set; }  

        public IActionResult OnGet()
        {
            EditorialManage am = new EditorialManage();           
            au = am.ListAll();
           
            return Page();

        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id){
            EditorialManage am = new EditorialManage();
            bool r = await am.Delete(Id);

            return RedirectToPage();
           
        }
    }
}
