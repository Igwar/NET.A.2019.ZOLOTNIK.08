using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using BookListServiceLib;
using BookListStorageLib;
using Finder;

namespace BookTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookStorage bookStorage = new BinaryBookStorage("Storage10.bin");
            IBookService bookService = new BookService(bookStorage);
            bookService.AddBook(new Book("978-3-16-123451-0", "Dostoevski", "one", "Minsk", 2000, 1000, 100));
            bookService.AddBook(new Book("978-3-16-123452-1", "Strygacki", "two", "Gomel", 2001, 2000, 200));
            bookService.AddBook(new Book("978-3-16-123453-2", "Kosh", "three", "Brest", 2002, 3000, 300));
            bookService.AddBook(new Book("978-3-16-123454-3", "Bulgakov", "four", "Vitebsk", 2003, 4000, 400));

            var book = new List<Book>();
            book.Add(bookService.FindBook(new FindBookByName("one", bookService.GetAllBooks().ToList())));
            //book.Add(bookService.FindBook(new FindBookByIsbn("978-3-16-123455-4",
            //    bookService.GetAllBooks().ToList())));

            PrintBook(book);

            //bookService.Sort(null);
            //PrintBook(bookService.GetAllBooks());



            //bookService.Save();
            Console.ReadKey();
        }

        private static void PrintBook(IEnumerable<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book);
            Console.WriteLine();
        }

        private static void PrintBook(Book book)
        {
            Console.WriteLine(book);
        }
        public class FindBookByIsbn : IFinder
        {
            public string Isbn { get; }
            public List<Book> Books { get; }
            public FindBookByIsbn(string isbn, IEnumerable<Book> books)
            {
                Isbn = isbn;
                Books = books.ToList();
            }

           

            public Book FindBookByTeg()
            {
                return Books.FirstOrDefault(book => book.Isbn == Isbn);
            }
        }
        public class FindBookByName : IFinder
        {

            public string Name { get; }
            public List<Book> Books { get; }

            public FindBookByName(string name, List<Book> books)
            {
                Name = name;
                Books = books;
            }

            

            public Book FindBookByTeg()
            {
                return Books.FirstOrDefault(book => book.Name == Name);
            }
        }
        public class SortByName : IComparer<Book>
        {
            public int Compare(Book lhs, Book rhs)
            {
                if (ReferenceEquals(lhs, null))
                {
                    return 1;
                }
                if (ReferenceEquals(lhs, rhs))
                {
                    return 0;
                }
                return lhs.CompareTo(rhs);
            }
        }
    }
    }

