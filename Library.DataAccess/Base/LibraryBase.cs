using Library.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess
{
    public  class LibraryBase<T> : ILibraryBase<T> where T : class

    {
        private DbSet<T> _dbset;
        private LibraryContext _context;

        public LibraryBase(LibraryContext ctx) 
        {
            _context= ctx;
            _dbset = _context.Set<T>();
            //_dbset = Tools.Context.Set<T>();

        }

        public async Task<List<T>> GetAll()
        {
            return await _dbset.ToListAsync<T>();
        }
       
        public async Task<T> GetById(int id)
        {
        
            var list=await _context.FindAsync<T>(id);
            return list;
        }
        public async Task<bool> Insert(T entity)
        {
            _context.Add<T>(entity);
            var result= await _context.SaveChangesAsync();
            if (result > 0)
                return true;
            return false;

        }


        public async Task<bool> Update(T entity)
        {
          
           _context.Entry<T>(entity).State =EntityState.Modified;
            var result= await _context.SaveChangesAsync();
            if(result>0)
                return true;
            return false;
          
   
        }

        async Task ILibraryBase<T>.Delete(int id)
        {
             var findId =await GetById(id);
             _context.Remove<T>(findId);
             await _context.SaveChangesAsync();
        }

         async Task<IEnumerable<T>> ILibraryBase<T>.Select()
         {
          
            return await _dbset.ToListAsync();
         }
    }
}
