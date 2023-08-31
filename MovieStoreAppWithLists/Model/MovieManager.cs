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

        public bool AddMovie(Movie movie)
        {
            if (movies.Count >= 5)
            {
                return false; 
            }

            movies.Add(movie);
            return true; 
        }

        public List<Movie> GetAllMovies()
        {
            return movies;
        }
        /*public void DisplayAllMovies()
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
        }*/

        public List<Movie> FindMoviesByYear(int year)
        {
            return movies.FindAll(movie => movie.Year == year);
        }

        public void RemoveMovieByName(string name)
        {
            Movie movieToRemove = movies.Find(movie => movie.MovieName.Equals(name));
            if (movieToRemove != null)
            {
                movies.Remove(movieToRemove);
            }
        }

        public void ClearList()
        {
            movies.Clear();
        }
    }
}
