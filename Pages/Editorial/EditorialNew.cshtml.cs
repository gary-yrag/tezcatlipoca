using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class EditorialNewModel : PageModel
    {    
        [BindProperty]
        public Editoriale editorial { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid){
                return Page();
            }

            EditorialManage am = new EditorialManage();
            var r = await am.Add(editorial);           

            if (r == null)
            {                
                return Page();
            }else{
                return RedirectToPage("/Editorial/EditorialList");
            }
            
        }
    }
}