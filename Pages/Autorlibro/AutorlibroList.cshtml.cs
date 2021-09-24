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
    public class AutorlibroListModel : PageModel
    {
        private readonly ILogger<AutorlibroListModel> _logger;
       
        public AutorlibroListModel(ILogger<AutorlibroListModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]  
        public List<AutoresHasLibro> au { get; set; }  

        public async Task<IActionResult> OnGet()
        {
            AutorlibroManage am = new AutorlibroManage();
           
            au = await am.ListAll();
           
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int AutoresId, int LibrosIsbn){
            AutorlibroManage am = new AutorlibroManage();
            bool r = await am.Delete(AutoresId,LibrosIsbn);

            return RedirectToPage();
                        
        }
    }
}
