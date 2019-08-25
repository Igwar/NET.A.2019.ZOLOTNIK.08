using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;
namespace BookListStorageLib
{
    public interface IBookStorage
    {
        /// <summary>
        /// Reads book list from file
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetBookList();

        /// <summary>
        /// Writes books into list
        /// </summary>
        /// <param name="books"></param>
        void SaveBooks(IEnumerable<Book> books);
    }
}
