using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using cdcore5.Domain.Entity;
using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class EditorialEditModel : PageModel
    {   
        [BindProperty]
        public Editoriale editorial { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditorialManage am = new EditorialManage();
             editorial = await am.getData(id);

            if (editorial == null)
            {
                return RedirectToPage("./Editorial/EditorialList");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(){
            if(!ModelState.IsValid){
                return Page();
            }
            EditorialManage db = new EditorialManage();
            string res = await db.Update(editorial);

            return Page();            
        }
    }
}