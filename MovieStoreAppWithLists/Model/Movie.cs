using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreAppWithLists.Model
{
    internal class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }

        public Movie(int movieId, string movieName, int year, string director)
        {
            MovieId = movieId;
            MovieName = movieName;
            Year = year;
            Director = director;
        }

        public override string ToString()
        {
            return $"ID: {MovieId}, Name: {MovieName}, Year: {Year}, Director: {Director}";
        }
    }
}
