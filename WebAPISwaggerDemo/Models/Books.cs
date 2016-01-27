using System;
using System.Collections.Generic;

namespace WebAPISwaggerDemo.Models
{
    /// <summary>
    /// Represents Books
    /// </summary>
    public class Books
    {
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int ISBN { get; set; }        
    }
}
