using BookStore.Book.Context;
using BookStore.Book.Entity;
using BookStore.Book.Interfaces;
using BookStore.Book.Model;

namespace BookStore.Book.Services
{
    public class BookRepo : IBookRepo
    {
        private readonly BookContext bookContext;
        public BookRepo(BookContext bookContext)
        {
            this.bookContext = bookContext;
        }


        //ADD BOOK:-
        public BookEntity AddBook(BookAddModel model)
        {
            try
            {
                BookEntity bookEntity = new BookEntity();
                bookEntity.BookName = model.BookName;
                bookEntity.Description = model.Description;
                bookEntity.Author = model.Author;
                bookEntity.Quantity = model.Quantity;
                bookEntity.DiscountPrice = model.DiscountPrice;
                bookEntity.ActualPrice = model.ActualPrice;

                bookContext.Book.Add(bookEntity);
                bookContext.SaveChanges();

                if (bookEntity != null)
                {
                    return bookEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }



        //Get ALL BOOKS:-
        public List<BookEntity> GetAllBooks()
        {
            try
            {
                var result = bookContext.Book.ToList();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        // GET BOOK BY ID:-
        public BookEntity GetBookByID(long BookID)
        {
            try
            {
                var result = bookContext.Book.FirstOrDefault
                    (data => data.BookID == BookID);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        //UPDATE BOOK:-
        public BookEntity UpdateBook(BookEditModel model, long BookID)
        {
            try
            {
                var bookEntity = bookContext.Book.FirstOrDefault
                    (data => data.BookID == BookID);
                if (bookEntity != null)
                {
                    bookEntity.BookName = model.BookName;
                    bookEntity.Description = model.Description;
                    bookEntity.Author = model.Author;
                    bookEntity.Quantity = model.Quantity;
                    bookEntity.DiscountPrice = model.DiscountPrice;
                    bookEntity.ActualPrice = model.ActualPrice;

                    bookContext.SaveChanges();
                    return bookEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }



        //DELETE BOOK:-
        public void DeleteBook(long BookID)
        {
            try
            {
                var result = bookContext.Book.FirstOrDefault
                    (data => data.BookID == BookID);
                if (result != null)
                {
                    bookContext.Book.Remove(result);
                    bookContext.SaveChanges();
                }
                else
                {
                    result = null;
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }


    }
}
