using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class AutorlibroNewModel : HandlerListsAutorlibro
    {         
        [BindProperty]
        public AutoresHasLibro libro { get; set; }

        public IActionResult OnGet()
        {
            PopulateAutorDropDownList();
            PopulateLibroDropDownList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            AutorlibroManage am = new AutorlibroManage();
            var r = await am.Add(libro);           

            if (r == null)
            {                
                return Page();
            }else{
                return RedirectToPage("/Autorlibro/AutorlibroList");
            }
            
        }
    }
}