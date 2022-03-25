using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.A9
{
    internal interface IMediaSearch
    {
        void mediaSearch(List<String[]> movieList, List<String[]> showList, List<String[]> videoList);
    }
}
