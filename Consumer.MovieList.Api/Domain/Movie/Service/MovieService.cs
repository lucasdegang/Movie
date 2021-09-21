using Consumer.MovieList.Api.Domain.Movie.Interface;
using Consumer.MovieList.Api.Domain.Movie.Model;
using Consumer.MovieList.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Consumer.MovieList.Api.Domain.Movie.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public int Delete(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null) throw new Exception($"Movie id {id} does not exists");

            _movieRepository.Delete(id);

            return movie.Id;
        }

        public IList<MovieModel> GetAll()
        {
            var movie = _movieRepository.GetAll();

            return movie.Select(s => new MovieModel
            {
                Id = s.Id,
                Year = s.Year,
                Title = s.Title,
                Studio = s.Studio,
                Producer = s.Producer,
                Winner = s.Winner
            }).ToList();
        }

        public MovieModel GetById(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null) throw new Exception($"Movie id {id} not found");

            return movie;
        }

        public MovieModel Save(MovieDto input)
        {
            MovieModel movie = new MovieModel 
            {
                Year = input.Year,
                Title = input.Title,
                Studio = input.Studio,
                Producer = input.Producer,
                Winner = input.Winner
            };
            
            _movieRepository.Save(movie);

            return movie;
        }

        public MovieModel Update(int id, MovieDto input)
        {
            bool flagControl = false;

            MovieModel model = _movieRepository.GetById(id);

            if (model == null)
            {
                flagControl = true;
                model = new MovieModel();
            }

            model.Year = input.Year;
            model.Title = input.Title;
            model.Studio = input.Studio;
            model.Producer = input.Producer;
            model.Winner = input.Winner;
            
            if (flagControl)
            {
                _movieRepository.Save(model);
            }
            else
            {
                _movieRepository.Update(model);
            }

            return model;
        }

        public MovieModel PatchUpdate(int id, MovieDto update)
        {
            MovieModel model = _movieRepository.GetById(id);

            if (model == null)
                throw new Exception($"Movie id=[{model.Id}] does not exist. Failed complete [PATCH] Request.");

            if (model.Year != update.Year)
                model.Year = update.Year;

            if (model.Title != update.Title)
                model.Title = update.Title;

            if (model.Studio != update.Studio)
                model.Studio = update.Studio;

            if (model.Producer != update.Producer)
                model.Producer = update.Producer;

            if (model.Winner != update.Winner)
                model.Winner = update.Winner;

            _movieRepository.Update(model);

            return model;
        }

        public MovieOutput GetAwards()
        {
            var movieOutput = new MovieOutput();
            List<MovieOutputDetail> detailMin = new List<MovieOutputDetail>();
            List<MovieOutputDetail> detailMax = new List<MovieOutputDetail>();

            var currentWinner = _movieRepository.GetAllWinners().OrderBy(x => x.Producer).ThenBy(x => x.Year);
            var countProducer = _movieRepository.GetAllWinners().Count();

            int count = 0;

            string previousProducer = "";
            int previousFirstWin = 0;
            int previousWin = 0;
            int currentYear = 0;

            int countYearDiff = 0;

            var smallerInterval = int.MaxValue;
            var biggestInterval = 0;

            int smallerYearTemp = 0;
            int biggestYearTemp = 0;

            bool flagsmallerInterval = false;
            bool flagBiggestInterval = false;

            foreach (var cw in currentWinner)
            {
                count++;
                if (previousProducer == "")
                {
                    previousProducer = cw.Producer;
                    previousFirstWin = cw.Year;
                    previousWin = cw.Year;
                }

                if (previousProducer == cw.Producer)
                {
                    if (previousWin != cw.Year)
                    {
                        countYearDiff = cw.Year - previousWin;
                        // min
                        if (smallerInterval > countYearDiff)
                        {
                            smallerInterval = countYearDiff;
                            smallerYearTemp = previousWin;
                            currentYear = cw.Year;
                            flagsmallerInterval = true;
                        }

                        countYearDiff = cw.Year - previousFirstWin;
                        // max
                        if (biggestInterval < countYearDiff)
                        {
                            if (countYearDiff != smallerInterval)
                            {
                                biggestInterval = countYearDiff;
                                biggestYearTemp = cw.Year;
                                flagBiggestInterval = true;
                            }
                        }
                    }

                    // Saving update data from foreach for the same Producer
                    previousWin = cw.Year;
                }
                else
                {
                    // Smaller interval 
                    if (flagsmallerInterval)
                    {
                        detailMin.Add(new MovieOutputDetail() { Producer = previousProducer, FollowingWin = currentYear, Interval = smallerInterval, PreviousWin = smallerYearTemp });
                        movieOutput.Min = detailMin;
                        flagsmallerInterval = false;
                    }

                    // Biggest interval
                    if (flagBiggestInterval)
                    {
                        detailMax.Add(new MovieOutputDetail() { Producer = previousProducer, FollowingWin = biggestYearTemp, Interval = biggestInterval, PreviousWin = (biggestYearTemp - biggestInterval) });
                        movieOutput.Max = detailMax;
                        flagBiggestInterval = false;
                    }

                    // init
                    countYearDiff = 0;

                    smallerInterval = int.MaxValue;
                    biggestInterval = 0;

                    smallerYearTemp = 0;
                    biggestYearTemp = 0;

                    // new Producer
                    previousProducer = cw.Producer;
                    previousFirstWin = cw.Year;
                    previousWin = cw.Year;
                }

                // Assurance the last data will be send
                if (count == countProducer)
                {
                    // Smaller interval 
                    if (flagsmallerInterval)
                    {
                        detailMin.Add(new MovieOutputDetail() { Producer = previousProducer, FollowingWin = currentYear, Interval = smallerInterval, PreviousWin = smallerYearTemp });
                        movieOutput.Min = detailMin;
                        flagsmallerInterval = false;
                    }

                    // Biggest interval
                    if (flagBiggestInterval)
                    {
                        detailMax.Add(new MovieOutputDetail() { Producer = previousProducer, FollowingWin = biggestYearTemp, Interval = biggestInterval, PreviousWin = (biggestYearTemp - biggestInterval) });
                        movieOutput.Max = detailMax;
                        flagBiggestInterval = false;
                    }
                }
            }

            return movieOutput;
        }
    }
}
