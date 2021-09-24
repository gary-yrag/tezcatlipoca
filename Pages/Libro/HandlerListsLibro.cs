using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class HandlerListsLibro : PageModel
    {
        public SelectList selectEditorialSL {get;set;}

        public void PopulateEditorialsDropDownList (object selectedEditorial = null){
             EditorialManage am = new EditorialManage();
            selectEditorialSL = am.ListAllList(selectedEditorial);
        }

    }
}