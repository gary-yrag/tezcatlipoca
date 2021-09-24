using System;
using cdcore5.Domain.Entity;
using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace cdcore5.Domain.Abstracts{
    public class AutorlibroManage{
        dbcore5Context db;

        public AutorlibroManage(){
            db = new dbcore5Context();            
        }

        public async Task<AutoresHasLibro> Add(AutoresHasLibro obj ){  
            string sql = $"INSERT INTO autores_has_libros (autores_id,Libros_ISBN) VALUES({obj.AutoresId},{obj.LibrosIsbn})";
            int r = db.Database.ExecuteSqlRaw(sql);
            return obj;

        }

        public async Task<List<AutoresHasLibro>> ListAll(){            
             List<AutoresHasLibro> l = await db.AutoresHasLibros
                .AsNoTracking()
                .Include(e => e.Autores)
                .Include(e => e.LibrosIsbnNavigation)
                .ToListAsync();

                return l;

        }
        
        public async Task<bool> Delete(int AutoresId, int LibrosIsbn){
            bool rb = false;
            string sql = $"DELETE FROM autores_has_libros WHERE autores_id={AutoresId} AND Libros_ISBN={LibrosIsbn}";
            int r = db.Database.ExecuteSqlRaw(sql);
            await db.SaveChangesAsync();
             if(r>=1){
                 rb=true;
             }else{
                 rb=false;
             }

             return rb;

            
        }      

        public SelectList ListAllListAutores(object selectedAutor = null){         
            var Query = from d in db.Autores orderby d.Nombre select d;

            return new SelectList(Query.AsNoTracking(),
                        "Id", "Nombre", selectedAutor);

        }   

         public SelectList ListAllListLibros(object selectedLibro = null){         
            var Query = from d in db.Libros orderby d.Titulo select d;

            return new SelectList(Query.AsNoTracking(),
                        "Isbn", "Titulo", selectedLibro);
                        
        }        
    }
}
