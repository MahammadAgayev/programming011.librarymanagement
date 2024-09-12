using LibraryManagement.Core.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishedYear { get; set; }
        public int PageCount { get; set; }
        public Genre Genre { get; set; }
    }
}
