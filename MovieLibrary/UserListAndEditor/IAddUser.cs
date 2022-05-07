using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IAddUser
    {
        void AddNewUser(MovieContext context);
    }
}
