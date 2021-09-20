namespace Consumer.MovieList.Api.Domain.Movie.Model
{
    public class MovieModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Producer { get; set; }
        public bool Winner { get; set; }
    }
}
