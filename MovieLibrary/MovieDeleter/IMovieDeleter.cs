using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IMovieDeleter
    {
        void DeleteMovie(MovieContext movie);
    }
}
