using BookStore.Book.Entity;
using BookStore.Book.Model;

namespace BookStore.Book.Interfaces
{
    public interface IBookRepo
    {
        public BookEntity AddBook(BookAddModel model);
        public List<BookEntity> GetAllBooks();
        public BookEntity GetBookByID(long BookID);
        public BookEntity UpdateBook(BookEditModel model, long BookID);
    }
}
