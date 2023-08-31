using MovieStoreAppWithLists.Model;

namespace MovieStoreAppWithLists
{
    internal
class Program
    {
        static void Main(string[] args)
        {
            MovieController controller = new MovieController();
            controller.Start();
        }
    }

}