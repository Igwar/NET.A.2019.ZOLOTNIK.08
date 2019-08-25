using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using BookListStorageLib;
using Finder;
namespace BookListServiceLib
{
   
        public class BookService : IBookService
        {
             /// <summary>
            /// private fields;
            /// </summary>
            private readonly IBookStorage bookStorage;
            private List<Book> books = new List<Book>();
          




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



            public void AddBook(Book book)
            {
                if (ReferenceEquals(book, null))
                {
                    throw new ArgumentNullException();
                }

                books.Add(book);

            }


            public void RemoveBookFromShop(Book book)
            {
                if (ReferenceEquals(book, null))
                {
                    throw new ArgumentNullException();
                }
                books.Remove(book);
            }


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


            public void Save()
            {
                bookStorage.SaveBooks(books);
            }


            public IEnumerable<Book> GetAllBooks()
            {
                return bookStorage.GetBookList();
            }




        }
    }

