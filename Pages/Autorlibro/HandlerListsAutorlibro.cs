using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using cdcore5.Domain.Abstracts;

namespace cdcore5.Pages
{
    public class HandlerListsAutorlibro : PageModel
    {
        public SelectList selectAutoresSL {get;set;}
        public SelectList selectLibrosSL {get;set;}

        public void PopulateAutorDropDownList (object selectedAutor = null, object selectedLibro=null){
            AutorlibroManage am = new AutorlibroManage();
            selectAutoresSL = am.ListAllListAutores(selectedAutor);           
        }


        public void PopulateLibroDropDownList (object selectedLibro = null){
            AutorlibroManage am = new AutorlibroManage();
            selectLibrosSL = am.ListAllListLibros(selectedLibro);
        }

    }
}