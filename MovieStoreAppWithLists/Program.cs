using MovieStoreAppWithLists.Model;

namespace MovieStoreAppWithLists
{
    internal class Program
    {
        static List<Movie> movieList = new List<Movie>();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Movie Store Menu:");
                Console.WriteLine("1. Display all movies");
                Console.WriteLine("2. Add a movie");
                Console.WriteLine("3. Find movie by year");
                Console.WriteLine("4. Remove movie by name");
                Console.WriteLine("5. Clear list");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1-6): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayAllMovies();
                            break;
                        case 2:
                            AddMovie();
                            break;
                        case 3:
                            FindMovieByYear();
                            break;
                        case 4:
                            RemoveMovieByName();
                            break;
                        case 5:
                            ClearList();
                            break;
                        case 6:
                            exit = true;
                            Console.WriteLine("Exiting the Movie Store. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine();
            }
        }

        static void DisplayAllMovies()
        {
            if (movieList.Count == 0)
            {
                Console.WriteLine("No movies in the store.");
            }
            else
            {
                Console.WriteLine("List of Movies:");
                foreach (var movie in movieList)
                {
                    Console.WriteLine($"ID: {movie.MovieId}, Name: {movie.MovieName}, Year: {movie.Year}, Director: {movie.Director}");
                }
            }
        }

        static void AddMovie()
        {
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

                Movie newMovie = new Movie(movieId, movieName, year, director);
                movieList.Add(newMovie);
                Console.WriteLine("Movie added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number for ID and Year.");
            }
        }

        static void FindMovieByYear()
        {
            try
            {
                Console.Write("Enter the year to search for: ");
                int year = int.Parse(Console.ReadLine());

                List<Movie> foundMovies = movieList.FindAll(movie => movie.Year == year);

                if (foundMovies.Count == 0)
                {
                    Console.WriteLine($"No movies found for the year {year}.");
                }
                else
                {
                    Console.WriteLine($"Movies released in {year}:");
                    foreach (var movie in foundMovies)
                    {
                        Console.WriteLine($"ID: {movie.MovieId}, Name: {movie.MovieName}, Year: {movie.Year}, Director: {movie.Director}");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }

        static void RemoveMovieByName()
        {
            Console.Write("Enter the name of the movie to remove: ");
            string movieName = Console.ReadLine();

            Movie movieToRemove = movieList.Find(movie => movie.MovieName.Equals(movieName));

            if (movieToRemove != null)
            {
                movieList.Remove(movieToRemove);
                Console.WriteLine($"Movie '{movieName}' removed successfully.");
            }
            else
            {
                Console.WriteLine($"Movie '{movieName}' not found in the store.");
            }
        }

        static void ClearList()
        {
            movieList.Clear();
            Console.WriteLine("All movies removed from the store.");
        }
    }
    
}