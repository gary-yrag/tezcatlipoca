using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class AutorEditModel : PageModel
    {    
        //private readonly AutorManage _db;

        //public  AutorEditModel(AutorManage db_){
        //    _db = db_;
        //}

        [BindProperty]
        public Autore autore { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            AutorManage am = new AutorManage();
             autore = await am.getData(id);

            if (autore == null)
            {
                return RedirectToPage("./Autor/Autor");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
             AutorManage db = new AutorManage();
            string res = await db.Update(autore);

            return Page();
            
        }
    }
}