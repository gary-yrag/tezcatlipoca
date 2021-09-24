using System;
using cdcore5.Domain.Entity;
using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace cdcore5.Domain.Abstracts{
    public class EditorialManage{
        dbcore5Context db;

        public EditorialManage(){
            db = new dbcore5Context();            
        }

        public async Task<Editoriale> Add(Editoriale obj ){
           
            db.Add<Editoriale>(obj);
            await db.SaveChangesAsync();
            return obj;

        }

        public IQueryable<Editoriale> ListAll(){
            return db.Set<Editoriale>();
            
        }

        public SelectList ListAllList(object selectedEditorial = null){
           
            var editorialQuery = from d in db.Editoriales orderby d.Nombre select d;
            return new SelectList(editorialQuery.AsNoTracking(),
                        "Id", "Nombre", selectedEditorial);
        }

        public async Task<Editoriale> getData(int id){
            var res = await db.Editoriales.FindAsync(id);
            return res;
        }

        public async Task<bool> Delete(int id){
            var res = await db.Editoriales.FindAsync(id);
            bool rb = false;
            if(res!=null){
                db.Editoriales.Remove(res);
                await db.SaveChangesAsync();
                rb=true;
            }else{
                rb=false;
            }
            return rb;
        }

        public async Task<string> Update(Editoriale obj){
           
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
