using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class LibroNewModel : HandlerListsLibro
    {    
        [BindProperty]
        public Libro libro { get; set; }

        public IActionResult OnGet()
        {
            PopulateEditorialsDropDownList();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            LibroManage am = new LibroManage();
            var r = await am.Add(libro);           

            if (r == null)
            {                
                return Page();
            }else{
                return RedirectToPage("/Libro/LibroList");
            }
            
        }
    }
}