using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using BookListStorageLib;
using Finder;
using Logger;
namespace BookListServiceLib
{
   
        public class BookService : IBookService
        {
             /// <summary>
            /// private fields;
            /// </summary>
            private readonly IBookStorage bookStorage;
            private List<Book> books = new List<Book>();
           private readonly ILogger logger;




            /// <summary>
            /// Ctor for bookStorage's initialization
            /// </summary>
            /// <param name="bookStorage"></param>
            public BookService(IBookStorage bookStorage)
            {
                if (ReferenceEquals(bookStorage, null))
                {
                    throw new ArgumentException();
                }
                this.bookStorage = bookStorage;

            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="book"></param>

            public void AddBook(Book book)
            {
                if (ReferenceEquals(book, null))
                {
                    throw new ArgumentNullException();
                }
              
                books.Add(book);
                logger.Debug("Book {book.name} successfully added.");
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="book"></param>

            public void RemoveBook(Book book)
            {
                if (ReferenceEquals(book, null))
                {
                    throw new ArgumentNullException();
                }
                books.Remove(book);
                 logger.Debug("Book {book.name} successfully removd.");
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="parameter"></param>
            /// <returns></returns>
            public Book FindBook(IFinder parameter)
            {
                if (ReferenceEquals(parameter, null))
                {
                    throw new ArgumentNullException();
                }
                return parameter.FindBookByTeg();
            }


            public void Sort(IComparer<Book> comparator)
            {
                var booksArray = books.ToArray();

                if (ReferenceEquals(comparator, null))
                {
                    Array.Sort(booksArray);
                }
                else
                {
                    Array.Sort(booksArray, comparator);
                }
                books.Clear();
                books.AddRange(booksArray);
            }

            /// <summary>
            /// 
            /// </summary>
            public void Save()
            {
                bookStorage.SaveBooks(books);
                 logger.Debug("List of books saved to the storage");
            }
          

            public IEnumerable<Book> GetAllBooks()
            {
                logger.Debug("List of books loaded from storage");
                return bookStorage.GetBookList();
                 
            }




        }
    }

