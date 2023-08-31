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

        public void Start()
        {
            while (true)
            {
                DisplayMenu();
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.DisplayAllMovies();
                        break;
                    case 2:
                        Movie newMovie = SetMovieDetails();
                        manager.AddMovie(newMovie);
                        break;
                    case 3:
                        Console.Write("Enter the year to find movies: ");
                        int searchYear = int.Parse(Console.ReadLine());
                        manager.FindMovieByYear(searchYear);
                        break;
                    case 4:
                        Console.Write("Enter the name of the movie to remove: ");
                        string movieName = Console.ReadLine();
                        manager.RemoveMovieByName(movieName);
                        break;
                    case 5:
                        manager.ClearList();
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
