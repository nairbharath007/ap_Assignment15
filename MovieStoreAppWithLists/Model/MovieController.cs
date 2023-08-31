using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Model
{
     class MovieController
    {
        private MovieManager manager;

        public MovieController()
        {
            manager = new MovieManager();
        }

        public Movie SetMovieDetails()
        {
            if (manager.GetAllMovies().Count >= 5)
            {
                Console.WriteLine("The movie list is full (maximum 5 movies).");
                return null;
            }
            try
            {
                Console.Write("Enter Movie ID: ");
                int movieId = int.Parse(Console.ReadLine());

                Console.Write("Enter Movie Name: ");
                string movieName = Console.ReadLine();

                Console.Write("Enter Year: ");
                int year = int.Parse(Console.ReadLine());

                Console.Write("Enter Director: ");
                string director = Console.ReadLine();

                return new Movie(movieId, movieName, year, director);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return null;
            }
        }

        public void Start()
        {
            while (true)
            {
                DisplayMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayAllMovies();
                        break;
                    case 2:
                        Movie newMovie = SetMovieDetails();
                        if (newMovie != null)
                        {
                            bool addedSuccessfully = manager.AddMovie(newMovie);
                            if (addedSuccessfully)
                            {
                                Console.WriteLine("Movie added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("The movie list is full (maximum 5 movies).");
                            }
                        }
                        break;
                    case 3:
                        Console.Write("Enter the year to find movies: ");
                        int searchYear;

                        try
                        {
                            searchYear = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            continue;
                        }

                        List<Movie> foundMovies = manager.FindMoviesByYear(searchYear);
                        DisplayMovies(foundMovies);
                        break;
                    case 4:
                        Console.Write("Enter the name of the movie to remove: ");
                        string movieName = Console.ReadLine();
                        manager.RemoveMovieByName(movieName);
                        Console.WriteLine($"Movie '{movieName}' removed successfully!");
                        break;
                    case 5:
                        manager.ClearList();
                        Console.WriteLine("All movies removed from the store.");
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void DisplayAllMovies()
        {
            List<Movie> allMovies = manager.GetAllMovies();
            DisplayMovies(allMovies);
        }

        public void DisplayMovies(List<Movie> moviesToDisplay)
        {
            if (moviesToDisplay.Count == 0)
            {
                Console.WriteLine("No movies found.");
                return;
            }

            Console.WriteLine("List of movies:");
            foreach (Movie movie in moviesToDisplay)
            {
                Console.WriteLine(movie.ToString());
            }
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nMovie Store Menu");
            Console.WriteLine("1. Display all movies");
            Console.WriteLine("2. Add a movie");
            Console.WriteLine("3. Find a movie by year");
            Console.WriteLine("4. Remove a movie by name");
            Console.WriteLine("5. Clear the list");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
        }

    }
}
