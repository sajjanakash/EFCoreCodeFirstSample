using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class BookManager : IDataRepository<Book>
    {
        readonly BookContext _bookContext;

        public BookManager(BookContext context)
        {
            _bookContext = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _bookContext.Books.ToList();
        }

        public Book Get(long id)
        {
            return _bookContext.Books
                  .FirstOrDefault(e => e.BookId == id);
        }

        public void Add(Book entity)
        {
            _bookContext.Books.Add(entity);
            _bookContext.SaveChanges();
        }

        public void Update(Book book, Book entity)
        {
            book.BookTitle = entity.BookTitle;
            book.Price = entity.Price;
	    book.PublisherId = entity.PublisherId;
            

            _bookContext.SaveChanges();
        }

        public void Delete(Book book)
        {
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
