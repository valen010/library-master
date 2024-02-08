﻿using Library.DataAccess;
using Library.DataAccess.Abstract;
using Library.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookStatusController : ControllerBase
    {
      
        private IBookStatusRepository _bookStatusService;
        private ILibraryBase<BookStatus> _libraryFacade;
        private LibraryContext _context;
        public BookStatusController(IBookStatusRepository bookStatusService, ILibraryBase<BookStatus> libraryFacade, LibraryContext context)
        {
            _bookStatusService = bookStatusService;
            _libraryFacade = libraryFacade;
            _context = context;
        }
        [HttpGet("{id:int}")]
        // [ActionName("BookById")]
        public async Task<IActionResult> GetByBookId(int id)
        {
           var result= await _bookStatusService.GetByBookId(id);
            if (result !=null)
                return Ok(result);
            return BadRequest("no record found");
        }
        [HttpGet("{id:int}")]
         //[ActionName("BookById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bookStatusService.GetById(id);
            if (result != null)
                return Ok(result);
            return BadRequest("no record found");

        }

        [HttpPut]
         public async Task<IActionResult> UpdateStatus([FromQuery]BookStatus entity)
         {
            /*var original = Tools.Context.BookStatuses.Find(1);
           Tools.Context.Entry(original).CurrentValues.SetValues(entity);
           var result =await Tools.Context.SaveChangesAsync();*/
            
            var result=await _libraryFacade.Update(entity);
             if(result)
             return Ok(result);
             return BadRequest();
         }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByMemberId(int id)
        {
            var result = await _bookStatusService.GetByMemberID(id);
            if (result != null)
                return Ok(result);
            return NotFound("Couldn't find any record");
            

        
        }
    }
}
