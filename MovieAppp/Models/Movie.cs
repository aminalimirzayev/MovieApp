using Consoletasks3.Interfaces;
using System;
using System.IO;
using System.Text.Json;

namespace Consoletasks3.Models
{
    public class Movie : Media, IPlayable
    {
        public GenreType Genre { get; set; }
        public bool Watched { get; set; }

        public void Play()
        {
            Console.WriteLine($"Playing {Title}...");
        }

        public void Stop()
        {
            Console.WriteLine($"{Title} stopped.");
        }

        public void MarkAsWatched()
        {
            Watched = true;
            Console.WriteLine($"{Title} mark as watched");
        }

        public void MarkAsUnwatched()
        {
            Watched = false;
            Console.WriteLine($"{Title} mark as unwatched");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Title: {Title}, Year: {Year}, Genre: {Genre}, Watched: {Watched}");
        }
    }
}
