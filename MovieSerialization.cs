using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MoviesApplication
{
    public static class MovieSerialization
    {
        public static void SerializeMovies(List<Movie> movies, string filePath)
        {
            var jsonString = JsonSerializer.Serialize(movies);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<Movie> DeserializeMovies(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Movie>>(jsonString);
            }
            return new List<Movie>();
        }
    }
}
