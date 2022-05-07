using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    internal class AddUser : IAddUser
    {
        public void AddNewUser(MovieContext context) 
        { 
            User user = new User();
            user.Age = setUserAge();
            user.Gender = setUserGender();
            user.ZipCode = setUserZipCode();
            MovieUtility movieUtility = new MovieUtility();
            user.Occupation = movieUtility.getOccupation(context); 
            context.Add(user);
            context.SaveChanges();
        }

        

        private int setUserAge() 
        {
            Console.WriteLine("Enter the user's age");
            string input = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(input, out number) || number < 1 || number > 121)
            {
                Console.WriteLine("The age was invalid please try again");
                input = Console.ReadLine();
            }
            return number;
        }

        private string setUserGender() 
        {
            Console.WriteLine("Enter the user's Gender M/F");
            string input = Console.ReadLine().ToUpper().Substring(0,1);
            while (string.IsNullOrEmpty(input) || (input != "M" && input != "F")) 
            {
                Console.WriteLine("The gender was invalid please try again");
                input = Console.ReadLine();
            }
            return input;
        }

        private string setUserZipCode() 
        {
            Console.WriteLine("Enter the user's zip code");
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) || input.Length != 5 || !int.TryParse(input, out int number)) 
            {
                Console.WriteLine("The zip code was invalid please try again");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
