using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Model
{
     class MovieManager
    {
        private List<Movie> movies;

        public MovieManager()
        {
            movies = new List<Movie>();
        }

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
            Console.WriteLine("Movie added successfully!");
        }

        public void DisplayAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies in the store.");
                return;
            }

            Console.WriteLine("List of all movies:");
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie.ToString());
            }
        }

        public void FindMovieByYear(int year)
        {
            List<Movie> foundMovies = movies.FindAll(movie => movie.Year == year);
            if (foundMovies.Count == 0)
            {
                Console.WriteLine($"No movies found for the year {year}.");
                return;
            }

            Console.WriteLine($"Movies from the year {year}:");
            foreach (Movie movie in foundMovies)
            {
                Console.WriteLine(movie.ToString());
            }
        }

        public void RemoveMovieByName(string name)
        {
            Movie movieToRemove = movies.Find(movie => movie.MovieName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
                Console.WriteLine($"Movie '{name}' removed successfully!");
            }
            else
            {
                Console.WriteLine($"Movie '{name}' not found.");
            }
        }

        public void ClearList()
        {
            movies.Clear();
            Console.WriteLine("All movies removed from the store.");
        }
    }
}
