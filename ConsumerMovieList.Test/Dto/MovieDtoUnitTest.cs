using Consumer.MovieList.Api.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsumerMovieList.Test.Dto
{
    [TestClass]
    public class MovieDtoUnitTest
    {
        [TestMethod]
        public void MovieDto_When_Instantiated_ShouldBe_Null()
        {
            var MovieDto = new MovieDto();

            Assert.AreNotSame(null, MovieDto);
        }

        [TestMethod]
        public void MovieDto_When_Not_Null()
        {
            var MovieDto = new MovieDto
            {
                Producer = "Producer Test",
                Studio = "Studio Test",
                Title = "Title Test"
            };

            Assert.AreNotEqual(null, MovieDto);
        }

        [TestMethod]
        public void MovieDto_When_Winner_ShouldBe_False()
        {
            var MovieDto = new MovieDto();

            Assert.AreEqual(false, MovieDto.Winner);
        }

        [TestMethod]
        public void MovieDto_When_Year_ShouldBe_Zero()
        {
            var MovieDto = new MovieDto();

            Assert.AreEqual(0, MovieDto.Year);
        }
    }
}
