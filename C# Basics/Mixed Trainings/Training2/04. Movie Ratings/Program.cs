using System;

namespace _04._Movie_Ratings
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfMovies = int.Parse(Console.ReadLine());
            string movieTitle = Console.ReadLine();
            double minRating = double.MaxValue;
            double maxRating = double.MinValue;
            string maxRatedMovie = "";
            string minRatedMovie = "";
            double totalRating = 0;
            for (int i = 0; i < numOfMovies; i++)
            {
                double rating = double.Parse(Console.ReadLine());
                totalRating += rating;
                if (maxRating < rating)
                {
                    maxRating = rating;
                    maxRatedMovie = movieTitle;
                }
                if (minRating > rating)
                {
                    minRating = rating;
                    minRatedMovie = movieTitle;
                }
                movieTitle = Console.ReadLine();
            }
            double averageRating = totalRating / numOfMovies;
            Console.WriteLine($"{maxRatedMovie} is with highest rating: {maxRating:f1}");
            Console.WriteLine($"{minRatedMovie} is with lowest rating: {minRating:f1}");
            Console.WriteLine($"Average rating: {averageRating:f1}");
        }
    }
}
