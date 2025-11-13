using Consoletasks3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Consoletasks3.Services
{
    public class MovieManager
    {
        private const string FilePath = "Data/movie.json";

        public List<Movie> LoadMovies()
        {
            if (!File.Exists(FilePath))
                return new List<Movie>();

            string json = File.ReadAllText(FilePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Movie>();

            return JsonSerializer.Deserialize<List<Movie>>(json) ?? new List<Movie>();
        }

        public void SaveMovies(List<Movie> movies)
        {
            string directory = Path.GetDirectoryName(FilePath);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(movies, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }


        public void Add(Movie movie)
        {
            var movies = LoadMovies();
            movies.Add(movie);
            SaveMovies(movies);
            Console.WriteLine($"{movie.Title} Added Succesfully");
        }

        public void Show()
        {
            var movies = LoadMovies();

            if (movies.Count == 0)
            {
                Console.WriteLine("Couldn't Find The Film");
                return;
            }

            foreach (var movie in movies)
            {
                movie.DisplayInfo();
            }
        }

    }
}
