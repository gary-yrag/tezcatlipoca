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
    public class LibroListModel : PageModel
    {
        private readonly ILogger<LibroListModel> _logger;
       
        public LibroListModel(ILogger<LibroListModel> logger)
        {
            _logger = logger;
        }
       
        public List<Libro> au { get; set; }  

        public async Task<IActionResult> OnGet()
        {
            LibroManage am = new LibroManage();          
            au = await am.ListAll();           
            return Page();

        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id){
            LibroManage am = new LibroManage();
            bool r = await am.Delete(Id);

            return RedirectToPage();
            
        }
    }
}
