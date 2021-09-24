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
    public class AutorModel : PageModel
    {
        private readonly ILogger<AutorModel> _logger;
       
        public AutorModel(ILogger<AutorModel> logger)
        {
            _logger = logger;
        }


        //[BindProperty]  
        public IQueryable<Autore> au { get; set; }  

        public IActionResult OnGet()
        {
            AutorManage am = new AutorManage();
            //IQueryable<Autore> au = am.ListAll();
            au = am.ListAll();
            //_context.Au.Add(au);
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int Id){
            AutorManage am = new AutorManage();
            bool r = await am.Delete(Id);

            return RedirectToPage();
            //return view();
        }
    }
}
