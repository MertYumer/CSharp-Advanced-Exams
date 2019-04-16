namespace P04_MovieTime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MovieTime
    {
        public static void Main()
        {
            var movies = new List<Movie>();
            var totalDuration = new TimeSpan();
            string favoriteGenre = Console.ReadLine();
            string movieDuration = Console.ReadLine();

            while (true)
            {
                var input = Console.ReadLine().Split('|');

                if (input[0] == "POPCORN!")
                {
                    break;
                }

                string name = input[0];
                string genre = input[1];
                var splittedDuration = input[2].Split(':').Select(int.Parse).ToArray();
                int hours = splittedDuration[0];
                int minutes = splittedDuration[1];
                int seconds = splittedDuration[2];
                var duration = new TimeSpan(hours, minutes, seconds);
                totalDuration += duration;

                var movie = new Movie(name, genre, duration);
                movies.Add(movie);
            }

            if (movieDuration == "Short")
            {
                movies = movies
                    .Where(m => m.Genre == favoriteGenre)
                    .OrderBy(m => m.Duration).ToList();
            }

            else if (movieDuration == "Long")
            {
                movies = movies
                    .Where(m => m.Genre == favoriteGenre)
                    .OrderByDescending(m => m.Duration).ToList();
            }

            foreach (var movie in movies)
            {
                Console.WriteLine(movie.Name);

                string wifeAnswer = Console.ReadLine();

                if (wifeAnswer == "Yes")
                {
                    Console.WriteLine($"We're watching {movie.Name} - {movie.Duration}");
                    Console.WriteLine($"Total Playlist Duration: {totalDuration}");
                    return;
                }
            }
        }
    }

    public class Movie
    {
        public Movie(string name, string genre, TimeSpan duration)
        {
            this.Name = name;
            this.Genre = genre;
            this.Duration = duration;
        }

        public string Name { get; set; }

        public string Genre { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
