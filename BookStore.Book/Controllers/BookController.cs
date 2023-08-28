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

    }
}
