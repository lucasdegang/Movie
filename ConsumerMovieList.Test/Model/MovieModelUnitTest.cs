using Consumer.MovieList.Api.Domain.Movie.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsumerMovieList.Test.Model
{
    [TestClass]
    public class MovieModelUnitTest
    {
        [TestMethod]
        public void MovieModel_When_Instantiated_ShouldBe_Null()
        {
            var movieModel = new MovieModel();

            Assert.AreNotSame(null, movieModel);
        }

        [TestMethod]
        public void MovieModel_When_Not_Null()
        {
            var movieModel = new MovieModel
            {
                Id = 1,
                Producer = "Producer Test",
                Studio = "Studio Test",
                Title = "Title Test"
            };

            Assert.AreNotEqual(null, movieModel);
        }

        [TestMethod]
        public void MovieModel_When_Winner_ShouldBe_False()
        {
            var movieModel = new MovieModel();

            Assert.AreEqual(false, movieModel.Winner);
        }

        [TestMethod]
        public void MovieModel_When_Year_ShouldBe_Zero()
        {
            var movieModel = new MovieModel();

            Assert.AreEqual(0, movieModel.Year);
        }
    }
}
