namespace Consumer.MovieList.Api.Dto
{
    public class MovieDto
    {
        // Head input file: year;title;studios;producers;winner
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Producer { get; set; }
        public bool Winner { get; set; }
    }
}
