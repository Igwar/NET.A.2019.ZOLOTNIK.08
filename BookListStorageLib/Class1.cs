using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using System.IO;
namespace BookListStorageLib
{
    public class BinaryBookStorage :IBookStorage
    {
     

        /// <summary>
        /// Field path is the way of file
        /// </summary>
        private readonly string path;


     

        public BinaryBookStorage(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Incorrect");
            }

            this.path = path;

        }



      
        public IEnumerable<Book> GetBookList()
        {
            List<Book> books = new List<Book>();
            using (var br = new BinaryReader(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    var book = Reader(br);
                    books.Add(book);
                }
            }

            return books;
        }

      

        /// <inheritdoc />
        public void SaveBooks(IEnumerable<Book> booksSave)
        {

            using (var bw = new BinaryWriter(File.Open(path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in booksSave)
                {
                    Writer(bw, book);
                }
            }
        }

        

       




        private static void Writer(BinaryWriter binary, Book book)
        {
            binary.Write(book.Isbn);
            binary.Write(book.Author);
            binary.Write(book.Name);
            binary.Write(book.PublishingHouse);
            binary.Write(book.Year);
            binary.Write(book.Price);
            binary.Write(book.Pages);
        }

        private static Book Reader(BinaryReader binary)
        {
            var isbn = binary.ReadString();
            var author = binary.ReadString();
            var name = binary.ReadString();
            var publish = binary.ReadString();
            var year = binary.ReadInt32();
            var price = binary.ReadDouble();
            var pages = binary.ReadInt32();

            return new Book(isbn, author, name, publish, year, price, pages);
        }
        
    }
}
