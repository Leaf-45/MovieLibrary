using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    internal interface IMovieWriter
    {
        public string addMovies(List<Movie> allMovies);
    }
}
