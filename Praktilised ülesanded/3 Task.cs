/* using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieCollection
{
    class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Year}) - {Genre}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "Interstellar", Year = 2014, Genre = "Sci-Fi" },
                new Movie { Title = "Inception", Year = 2010, Genre = "Sci-Fi" },
                new Movie { Title = "Gladiator", Year = 2000, Genre = "Action" },
                new Movie { Title = "The Godfather", Year = 1972, Genre = "Crime" },
                new Movie { Title = "Whiplash", Year = 2014, Genre = "Drama" }
            };

            Console.Write("������� ���� ��� ������: ");
            string inputGenre = Console.ReadLine();
            var byGenre = FindMoviesByGenre(movies, inputGenre);

            Console.WriteLine($"\n������ ����� {inputGenre}:");
            foreach (var m in byGenre)
            {
                Console.WriteLine(m);
            }

            var latest = FindLatestMovie(movies);
            Console.WriteLine($"\n����� ����� �����: {latest}");

            var grouped = GroupMoviesByGenre(movies);
            Console.WriteLine("\n����������� �� ������:");
            foreach (var genreGroup in grouped)
            {
                Console.WriteLine($"\n����: {genreGroup.Key}");
                foreach (var m in genreGroup.Value)
                {
                    Console.WriteLine($" - {m.Title} ({m.Year})");
                }
            }
        }

        static List<Movie> FindMoviesByGenre(List<Movie> movies, string genre)
        {
            return movies.Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        static Movie FindLatestMovie(List<Movie> movies)
        {
            return movies.OrderByDescending(m => m.Year).First();
        }

        static Dictionary<string, List<Movie>> GroupMoviesByGenre(List<Movie> movies)
        {
            return movies.GroupBy(m => m.Genre)
                         .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}
