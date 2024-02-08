using Library.DataAccess.Abstract;
using Library.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Concrete
{
    public class BookStatusRepository : IBookStatusRepository
    {
        ILibraryBase<BookStatus> _bookStatusRepository;
        protected LibraryContext _context;

        public BookStatusRepository(ILibraryBase<BookStatus> bookStatusRepository, LibraryContext context)
        {
            _bookStatusRepository = bookStatusRepository;
            _context = context;
           
        }

     
        public async Task Delete(int id)
        {
            await _bookStatusRepository.Delete(id);
        }

        public async Task<List<BookStatus>> GetAll()
        {
            
                var list= await _bookStatusRepository.GetAll();
                 return list;
        }
     
        public async Task<BookStatus> GetByBookId(int id)
        {
          
            var ıd = _context.BookStatuses.First(x => x.BookId == id).Id;
            var list = await _bookStatusRepository.GetById(ıd);
            return list;
        }



        public  Task<BookStatus> GetById(int id)
        {
           return  _bookStatusRepository.GetById(id);
           
        }

        public async Task<BookStatus> GetByMemberID(int id)
        {
            var statusId =_context.BookStatuses.First(x => x.MemberId == id).Id;
            var list = await _bookStatusRepository.GetById(statusId);
            return list;
        }

        public Task<bool> Insert(BookStatus entity)
        {
            return _bookStatusRepository.Insert(entity);
        }

        public Task<IEnumerable<BookStatus>> Select()
        {
            return _bookStatusRepository.Select();
        }

        public Task<bool> Update(BookStatus entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return _bookStatusRepository.Update(entity);
        }
     


        /*List<BookStatus> ILibraryFacade<BookStatus>.GetAll()
        {
            throw new NotImplementedException();
        }*/
    }
}
