using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISwaggerDemo.Models;

namespace WebAPISwaggerDemo.Controllers
{
    public class AuthorsController : ApiController
    {
        static List<Authors> authorsList = LoadAuthors();

        /// <summary>
        /// Gets All Authors listed
        /// </summary>
        /// <returns>List of Authors</returns>
        public IHttpActionResult Get()
        {
            return Ok(authorsList);
        }

        /// <summary>
        /// Gets Authors details based Email
        /// </summary>
        /// <param name="id">Email address of Author</param>
        /// <returns>Authors Details</returns>
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Email address cannot be Null or Empty");
            }
            var getauthor = authorsList.Where(e => e.Email == id).SingleOrDefault();
            return Ok(getauthor);
        }

        /// <summary>
        /// Inserts Author Data
        /// </summary>
        /// <param name="authorData"></param>
        /// <returns></returns>
        public IHttpActionResult Post([FromBody]Authors authorData)
        {
            if (authorData == null)
            {
                return BadRequest();
            }
            authorsList.Add(authorData);
            return Ok();
        }

        /// <summary>
        /// Updates Author Data
        /// </summary>
        /// <param name="id">Email Id of Author</param>
        /// <param name="authorsdata"></param>
        public void Put(string id, [FromBody]Authors authorsdata)
        {
            foreach (var item in authorsList)
            {
                if (item.Email == id)
                {
                    item.Name = authorsdata.Name;
                    item.NoOfBooksWritten = authorsdata.NoOfBooksWritten;
                }
            }
        }

        /// <summary>
        /// Deletes Authors Data
        /// </summary>
        /// <param name="id">Email Id of Author</param>
        public void Delete(string id)
        {
            var delAuthors = authorsList.SingleOrDefault(e => e.Email == id);
            if (delAuthors != null)
            {
                authorsList.Remove(delAuthors);
            }
        }

        private static List<Authors> LoadAuthors()
        {
            var authors = new List<Authors>();
            authors.Add(new Authors() { Name = "Mithun Pattankar", Email = "mithun@test.com", NoOfBooksWritten = 5 });

            return authors;
        }
    }
}
