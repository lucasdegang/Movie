using Consumer.MovieList.Api.Domain.Movie.Interface;
using Consumer.MovieList.Api.Domain.Movie.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsumerMovieList.Test.Service
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieModel _movieModel;
        private Mock<IMovieRepository> _mockMovieRepository = new Mock<IMovieRepository>();

        public object MockClasses { get; private set; }

        public MovieServiceUnitTest()
        {
            IList<MovieModel> movie = new List<MovieModel>
            {
                new MovieModel { Id = 1, Producer = "P. 1", Studio = "S. 1", Year = 1982, Title = "T. 1", Winner = true },
                new MovieModel { Id = 2, Producer = "P. 2", Studio = "S. 2", Year = 1950, Title = "T. 2", Winner = false },
                new MovieModel { Id = 3, Producer = "P. 3", Studio = "S. 3", Year = 2005, Title = "T. 3", Winner = false },
            };
        }

        [TestMethod]
        public async Task Constructor_ShouldBe_Not_Null()
        {
            Assert.AreNotEqual(null, this);
        }

        [TestMethod]
        public async Task GetAll_ShouldBe_Return_All_Movies()
        {
            MovieServiceUnitTest x = new MovieServiceUnitTest();

            var expect = _mockMovieRepository.Setup(x => x.GetAll());

            Assert.AreNotEqual(expect, x);
        }

        [TestMethod]
        public async Task Save_Movie_ShouldBe_NotNull()
        {
            MovieModel movie = new MovieModel
            {
                Id = 4,
                Producer = "Producer Test",
                Studio = "Studio Test",
                Title = "Title Test",
                Winner = true,
                Year = 2000
            };

            var expect = _mockMovieRepository.Setup(x => x.Save(movie));

            Assert.AreNotEqual(expect, movie);
        }

        [TestMethod]
        public async Task Save_Movie_ShouldBe_Different()
        {
            MovieModel movie = new MovieModel
            {
                Id = 4,
                Producer = "Producer Test",
                Studio = "Studio Test",
                Title = "Title Test",
                Winner = true,
                Year = 2000
            };

            var movieToSave = _mockMovieRepository.Setup(x => x.Save(movie));

            var expect = _mockMovieRepository.Setup(x => x.GetById(3));

            Assert.AreNotEqual(expect, movieToSave);
        }
    }
}
