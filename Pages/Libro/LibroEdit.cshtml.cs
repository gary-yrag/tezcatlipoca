using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class LibroEditModel : HandlerListsLibro
    {    
        [BindProperty]
        public Libro libro { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            LibroManage am = new LibroManage();
            libro = await am.getData(id);

            if(libro==null){
                 return RedirectToPage("./Libro/LibroList");
            }             
            PopulateEditorialsDropDownList(libro.Isbn);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            LibroManage am = new LibroManage();
            string r = await am.Update(libro);           

            if (r.IndexOf("Error")>=0)
            {                
                return Page();
            }else{
                return RedirectToPage("/Libro/LibroList");
            }
            
        }
    }
}