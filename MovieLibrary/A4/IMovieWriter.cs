using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal interface IMovieWriter
    {
        string[] addMovies(String file, List<String[]> allMovies);
    }
}
