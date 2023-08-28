using BookStore.Book.Entity;
using BookStore.Book.Model;

namespace BookStore.Book.Interfaces
{
    public interface IBookRepo
    {
        public BookEntity AddBook(BookAddModel model);
    }
}
