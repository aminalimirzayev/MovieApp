using Consoletasks3.Models;
using Consoletasks3.Services;
using System;

namespace Consoletasks3
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieManager manager = new MovieManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Movie Collection ===");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Show All Movies");
                Console.WriteLine("3. Watched");
                Console.WriteLine("4. Didn't Watch");
                Console.WriteLine("5. Play Movie");
                Console.WriteLine("6. Stop Movie");
                Console.WriteLine("0. Exit");
                Console.Write("Make Your Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Film name: ");
                        string title = Console.ReadLine();

                        Console.Write("Year: ");
                        int year = int.Parse(Console.ReadLine());

                        Console.WriteLine("Choose Genre (Action, Comedy, Drama, Horror, ScienceFiction, Romance, Documentary): ");
                        string genreStr = Console.ReadLine();
                        GenreType genre = Enum.Parse<GenreType>(genreStr);

                        Movie newMovie = new Movie
                        {
                            Title = title,
                            Year = year,
                            Genre = genre,
                            Watched = false
                        };

                        manager.Add(newMovie);
                        break;

                    case "2":
                        manager.Show();
                        break;

                    case "3":
                        Console.Write("Mark As Watched: ");
                        string watchedTitle = Console.ReadLine();
                        var movies1 = manager.LoadMovies(); 
                        var movie1 = movies1.Find(m => m.Title.Equals(watchedTitle, StringComparison.OrdinalIgnoreCase));
                        if (movie1 != null)
                        {
                            movie1.MarkAsWatched();
                            manager.SaveMovies(movies1); 
                        }
                        else
                        {
                            Console.WriteLine("Couldn't find the film");
                        }
                        break;

                    case "4":
                        Console.Write("Mark As Unwatched ");
                        string unwatchedTitle = Console.ReadLine();
                        var movies2 = manager.LoadMovies();
                        var movie2 = movies2.Find(m => m.Title.Equals(unwatchedTitle, StringComparison.OrdinalIgnoreCase));
                        if (movie2 != null)
                        {
                            movie2.MarkAsUnwatched();
                            manager.SaveMovies(movies2); 
                        }
                        else
                        {
                            Console.WriteLine("Couldn't find the film");
                        }
                        break;

                    case "5":
                        Console.Write("Play Moive: ");
                        string playTitle = Console.ReadLine();
                        var movies3 = manager.LoadMovies();
                        var movie3 = movies3.Find(m => m.Title.Equals(playTitle, StringComparison.OrdinalIgnoreCase));
                        movie3?.Play();
                        break;

                    case "6":
                        Console.Write("Stop Movie ");
                        string stopTitle = Console.ReadLine();
                        var movies4 = manager.LoadMovies();
                        var movie4 = movies4.Find(m => m.Title.Equals(stopTitle, StringComparison.OrdinalIgnoreCase));
                        movie4?.Stop();
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong");
                        break;
                }
            }
        }
    }
}
