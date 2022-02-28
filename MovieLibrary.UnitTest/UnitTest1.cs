using Xunit;

namespace MovieLibrary.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void ExceptionCheck_FileNotFoundException_Failure()
        {
            // Arrange
            MovieLibrary.Executable movie = new MovieLibrary.Executable();
            // Act and Assert
            Assert.Throws<System.IO.FileNotFoundException>(() => Executable.askForAction(""));
        }
    }
}