using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class AutorNewModel : PageModel
    {    
        [BindProperty]
        public Autore autore { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            AutorManage am = new AutorManage();
            var r = await am.Add(autore);           

            if (r == null)
            {                
                return Page();
            }else{
                return RedirectToPage("/Autor/Autor");
            }
            
        }
    }
}