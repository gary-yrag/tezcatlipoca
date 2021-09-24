using System;
using cdcore5.Domain.Entity;
using System.Collections.Generic; 
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace cdcore5.Domain.Abstracts{
    public class AutorManage{
        dbcore5Context db;

        public AutorManage(){
            db = new dbcore5Context(); 
                       
        }

        public async Task<Autore> Add(Autore obj ){         
            db.Add<Autore>(obj);
            await db.SaveChangesAsync();

            return obj;

        }

        public IQueryable<Autore> ListAll(){

            return db.Set<Autore>();  

        }

        public async Task<Autore> getData(int id){
            var res = await db.Autores.FindAsync(id);

            return res;

        }

        public async Task<bool> Delete(int id){
            var res = await db.Autores.FindAsync(id);
            bool rb = false;
            if(res!=null){
                db.Autores.Remove(res);
                await db.SaveChangesAsync();
                rb=true;
            }else{
                rb=false;
            }

            return rb;

        }

        public async Task<string> Update(Autore obj){          
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
