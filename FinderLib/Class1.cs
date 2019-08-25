using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLib;

namespace Finder
{
    public interface IFinder
    {
        Book FindBookByTeg();
    }
}