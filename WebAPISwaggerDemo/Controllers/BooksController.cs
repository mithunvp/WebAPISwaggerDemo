using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using WebAPISwaggerDemo.Models;

namespace WebAPISwaggerDemo.Controllers
{
    /// <summary>
    /// Books API for performing CRUD
    /// </summary>
    public class BooksController : ApiController
    {
        static List<Books> booksList = LoadBooks();
        
        /// <summary>
        /// Gets All Books listed
        /// </summary>
        /// <returns>List of Books</returns>
        public IHttpActionResult Get()
        {
            return Ok(booksList);
        }

        /// <summary>
        /// Gets Books details based ISBN
        /// </summary>
        /// <param name="id">ISBN number of Book</param>
        /// <returns>Book Details</returns>
        public IHttpActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest("ISBN number cannot be 0");
            }
            var getBook = booksList.Where(e => e.ISBN == id).SingleOrDefault();
            return Ok(getBook);
        }

        /// <summary>
        /// Inserts Book data
        /// </summary>
        /// <param name="booksData">Books object</param>
        /// <returns>Response status of 200</returns>
        public IHttpActionResult Post([FromBody]Books booksData)
        {
            if (booksData == null)
            {
                return BadRequest();
            }
            booksList.Add(booksData);
            return Ok();
        }

        /// <summary>
        /// Updates Books data based on Id
        /// </summary>
        /// <param name="id">ISBN</param>
        /// <param name="booksdata">Books details</param>
        public void Put(int id, [FromBody]Books booksdata)
        {   
            foreach (var item in booksList)
            {
                if (item.ISBN == id)
                {
                    item.Title = booksdata.Title;
                    item.PublishedDate = booksdata.PublishedDate;
                }
            }
        }
        
        /// <summary>
        /// Deletes Books Data
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var delBooks = booksList.SingleOrDefault(e => e.ISBN == id);
            if (delBooks != null)
            {
                booksList.Remove(delBooks);
            }
        }

        private static List<Books> LoadBooks()
        {
            var books = new List<Books>();
            books.Add(new Books() { Title = "Intro to ASP.NET 5", ISBN = 123456, PublishedDate = DateTime.Now.AddMonths(-12) });

            return books;
        }
    }
}
