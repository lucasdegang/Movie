using Consumer.MovieList.Api.Domain.Movie.Model;
using Consumer.MovieList.Api.Infra;
using System;
using System.IO;

namespace Consumer.MovieList.Api.Consumer
{
    public static class MovieListConsumer
    {
        const string SOURCE_PATH = @"c:\temp\movielist.csv";
        const string TARGET_FILE_PATH = @"\movielist.csv";

        public static void ConsumeFile()
        {
            int count = 0;
            try
            {
                FileInfo fileInfo = new FileInfo(SOURCE_PATH);

                string[] lines = File.ReadAllLines(SOURCE_PATH);

                string sourceFolderPath = Path.GetDirectoryName(SOURCE_PATH);

                using (var context = new MovieDbContext())
                {
                    using (StreamWriter sw = File.AppendText(TARGET_FILE_PATH))
                    {
                        foreach (string line in lines)
                        {
                            if (count == 0)
                            {
                                count++;
                                continue;
                            }

                            string[] fields = line.Split(';');

                            MovieModel model = new MovieModel
                            {
                                Year = Int32.Parse(fields[0]),
                                Title = fields[1],
                                Studio = fields[2],
                                Producer = fields[3],
                                Winner = fields[4] == "yes" ? true : false
                            };

                            SaveFileCsv(context, model);

                            count++;
                        }
                    }
                }
            }
            catch (IOException e)
            {
                throw new Exception("Error ConsumeFile.cs: " + e.Message);
            }
        }

        private static void SaveFileCsv(MovieDbContext context, MovieModel model)
        {
            context.Movie.Add(model);
            context.SaveChanges();
        }
    }
}
