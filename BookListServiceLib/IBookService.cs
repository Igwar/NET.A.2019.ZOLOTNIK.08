using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
using Finder;
namespace BookListServiceLib
{
   public interface IBookService
    {/// <summary>
     /// Adds book to list
     /// </summary>
     /// <param name="book"></param>
        void AddBook(Book book);

        /// <summary>
        /// Removes book from list
        /// </summary>
        /// <param name="book"></param>
        void RemoveBookFromShop(Book book);

        /// <summary>
        /// Finds book in list
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Book FindBook(IFinder parameter);

        /// <summary>
        /// Sorts by some teg
        /// </summary>
        /// <param name="comparator"></param>
        void Sort(IComparer<Book> comparator);

        /// <summary>
        /// Saves information about books
        /// </summary>
        void Save();

        /// <summary>
        /// Returns list of books
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks();
    }
}
