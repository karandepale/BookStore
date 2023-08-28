using BookStore.Book.Interfaces;
using BookStore.Book.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }

        // ADD BOOK:-
        [HttpPost]
        [Route("AddBook")]
        public IActionResult AddBook(BookAddModel model)
        {
            var result = bookRepo.AddBook(model);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book Added Successful", data = result });
            }
            else
            {
                return BadRequest(new { success = false, message = "Book Not Added.", data = result });
            }
        }



        // GET ALL BOOKS:-
        [HttpGet]
        [Route("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var result = bookRepo.GetAllBooks();
            if (result != null)
            {
                return Ok(new { success = true, message = "Book List Getting Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Books Not Found.", data = result });
            }
        }



        // GET BOOK BY ID:-
        [HttpGet]
        [Route("GetBookByID")]
        public IActionResult GetBookByID(long BookID)
        {
            var result = bookRepo.GetBookByID(BookID);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book By ID Getting Successful", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Book Not Found.", data = result });
            }
        }



        // UPDATE BOOK:-
        [HttpPut]
        [Route("UpdateBook")]
        public IActionResult UpdateBook(BookEditModel model, long BookID)
        {
            var result = bookRepo.UpdateBook(model, BookID);
            if (result != null)
            {
                return Ok(new { success = true, message = "Book Updated Successfully", data = result });
            }
            else
            {
                return NotFound(new { success = false, message = "Book Not Updated.", data = result });
            }
        }




    }
}
