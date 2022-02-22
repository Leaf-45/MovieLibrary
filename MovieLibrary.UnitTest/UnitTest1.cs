using Xunit;

namespace MovieLibrary.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ExceptionCheck_FileNotFoundException_Failure()
        {
            // Arrange
            MovieLibrary.Program movie = new MovieLibrary.Program();
            // Act and Assert
            Assert.Throws<System.IO.FileNotFoundException>(() => Program.askForAction(""));
        }
    }
}