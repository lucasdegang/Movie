using System.Collections.Generic;

namespace Consumer.MovieList.Api.Domain
{
    public class MovieOutput
    {
        public List<MovieOutputDetail> Min { get; set; }
        public List<MovieOutputDetail> Max { get; set; }
    }
}
