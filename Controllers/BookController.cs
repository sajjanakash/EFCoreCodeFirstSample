using System.Collections.Generic;
using EFCoreCodeFirstSample.Models;
using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IDataRepository<Book> _dataRepository;

        public BookController(IDataRepository<Book> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Book> books = _dataRepository.GetAll();
            return Ok(books);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Book book = _dataRepository.Get(id);

            if (book == null)
            {
                return NotFound("The Book record couldn't be found.");
            }

            return Ok(book);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            _dataRepository.Add(book);
            return CreatedAtRoute(
                  "Get", 
                  new { Id = book.BookId },
                  book);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            Book bookToUpdate = _dataRepository.Get(id);
            if (bookToUpdate == null)
            {
                return NotFound("The Book record couldn't be found.");
            }

            _dataRepository.Update(bookToUpdate, book);
            return NoContent();
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Book book = _dataRepository.Get(id);
            if (book == null)
            {
                return NotFound("The Book record couldn't be found.");
            }

            _dataRepository.Delete(book);
            return NoContent();
        }
    }
}
