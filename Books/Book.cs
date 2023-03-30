using C__Final.AuthorName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final.Books
{
    public class Book : IEquatable<Book>
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.Id = counter;

        }
        public int Id { get; private set; }

        public string Name { get; set; }

        public int AuthorId { get; set; }
        public string Genre { get; set; }

        public uint PageCount {get; set; }

        public uint Price { get; set; }

        public bool Equals(Book? other)
        {
            return other?.Id == this.Id;
        }

        public override string ToString()
        {
            return $"{Id}\n{Name}\n{AuthorId}\n{Genre}\n{PageCount}\n{Price}";
        }
    }
}
