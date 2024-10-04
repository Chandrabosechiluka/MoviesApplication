using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace MoviesApplication
{
    public class Program
    {
        
        static List<Movie> movies;
        static string filePath;

        static void Main(string[] args)
        {
            filePath = ConfigurationManager.AppSettings["AccountFilePath"];

            
            if (File.Exists(filePath))
            {
                movies = MovieSerialization.DeserializeMovies(filePath);
            }
            else
            {
                movies = new List<Movie>(); 
                MovieSerialization.SerializeMovies(movies, filePath); 
            }

            
            while (true)
            {
                Console.WriteLine("\nSimple Movies App");
                Console.WriteLine("1. Display Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Clear All Movies");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayMovies();
                        break;
                    case "2":
                        AddMovie();
                        break;
                    case "3":
                        ClearMovies();
                        break;
                    case "4":
                        ExitApp();
                        return;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        
        static void DisplayMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies available.");
                return;
            }
            Console.WriteLine("\nList of Movies:");
            foreach (var movie in movies)
            {
                movie.DisplayDetails();
            }
        }

        
        static void AddMovie()
        {
            if (movies.Count >= 5)
            {
                Console.WriteLine("Cannot add more movies. Maximum limit reached.");
                return;
            }

            var movie = new Movie();

            Console.Write("Enter Movie ID: ");
            movie.MovieId = int.Parse(Console.ReadLine());

            Console.Write("Enter Movie Name: ");
            movie.Name = Console.ReadLine();

            Console.Write("Enter Genre: ");
            movie.Genre = Console.ReadLine();

            Console.Write("Enter Year: ");
            movie.Year = int.Parse(Console.ReadLine());

            movies.Add(movie);
            MovieSerialization.SerializeMovies(movies, filePath); 
            Console.WriteLine("Movie added successfully!");
        }


        static void ClearMovies()
        {
            movies.Clear();
            MovieSerialization.SerializeMovies(movies, filePath); 
            Console.WriteLine("All movies cleared.");
        }

        
        static void ExitApp()
        {
            MovieSerialization.SerializeMovies(movies, filePath); 
            Console.WriteLine("Exiting the application...");
        }
    }
}

