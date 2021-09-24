using System;
using cdcore5.Domain.Entity;
using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace cdcore5.Domain.Abstracts{
    public class LibroManage{
        dbcore5Context db;

        public LibroManage(){
            db = new dbcore5Context();            
        }

        public async Task<Libro> Add(Libro obj ){          
            db.Add<Libro>(obj);
            await db.SaveChangesAsync();
            return obj;

        }

        public async Task<List<Libro>> ListAll(){          
             List<Libro> l = await db.Libros
                .AsNoTracking()
                .Include(e => e.Editoriales)
                .ToListAsync();
                return l;

        }

        public async Task<Libro> getData(int id){
            var res = await db.Libros.FindAsync(id);
            return res;

        }

        public async Task<bool> Delete(int id){
            var res = await db.Libros.FindAsync(id);
            bool rb = false;
            if(res!=null){
                db.Libros.Remove(res);
                await db.SaveChangesAsync();
                rb=true;
            }else{
                rb=false;
            }
            return rb;

        }

        public async Task<string> Update(Libro obj){            
            string  res = "";
            try{
                db.Entry(obj).State = EntityState.Modified;
                await db.SaveChangesAsync();

                res = "Editado correctamente";
            }catch(DbUpdateConcurrencyException e){
                res = ($"Error Editando autor: {e.Message}");                
            }
            
            return res;
        }        
    }
}
