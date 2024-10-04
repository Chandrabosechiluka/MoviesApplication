using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApplication
{
    [Serializable]
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"ID: {MovieId}, Name: {Name}, Genre: {Genre}, Year: {Year}");
        }
    }
}
