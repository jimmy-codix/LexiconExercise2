using LexiconExercise2.Enums;
using LexiconExercise2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Tasks
{
    internal class TaskMovies : ITask
    {
        IInputOutputManager io;
        const int MOVIE_YOUTH_PRICE = 80;
        const int MOVIE_SENIOR_PRICE = 90;
        const int MOVIE_STANDARD_PRICE = 120;
        const int MOVIE_FREE_PRICE = 0;

        const int MIN_AGE = 0;
        const int MAX_AGE = 125;

        const string ERROR_AGE = "Incorrect age. Please try again:";

        MovieRoute route;

        public TaskMovies(MovieRoute route)
        {
            this.route = route;
        }

        public void Work(IInputOutputManager io)
        {
            io.Clear();
            this.io = io;
            if (route == MovieRoute.Single)
                MoviesSingle();
            else
                MoviesGroup();
        }

        private int CalculateMoviePrice(int age)
        {
            if (age < 20)
            {
                if (age < 5)
                    return MOVIE_FREE_PRICE;
                else
                    return MOVIE_YOUTH_PRICE;
            }
            else if (age > 64)
            {
                if (age > 100)
                    return MOVIE_FREE_PRICE;
                else
                    return MOVIE_SENIOR_PRICE;
            }
            else
            {
                return MOVIE_STANDARD_PRICE;
            }
        }

        private void MoviesSingle()
        {
            io.WriteLine("***Movies, calculate price for one person***");
            io.WriteLine("Enter your age:");
            int age = io.ReadInt(ERROR_AGE, MIN_AGE, MAX_AGE);
            int price = CalculateMoviePrice(age);
            io.WriteLine($"Your price: {GetPriceString(price)}");
        }

        private string GetPriceString(int price)
        {
            switch (price)
            {
                case MOVIE_FREE_PRICE: return $"{MOVIE_FREE_PRICE} (Free)"; break;
                case MOVIE_YOUTH_PRICE: return $"{MOVIE_YOUTH_PRICE} (Youth)"; break;
                case MOVIE_SENIOR_PRICE: return $"{MOVIE_SENIOR_PRICE} (Senior)"; break;
                default: return $"{MOVIE_STANDARD_PRICE} (Standard)"; break;
            }
        }

        private void MoviesGroup()
        {
            int total = 0;
            int age = 0;
            io.WriteLine("***Movies, calculate price for a group***");
            io.WriteLine("How many people are their in your group:");
            int group = io.ReadInt(ERROR_AGE, MIN_AGE, MAX_AGE);
            for (int i = 0; i < group; i++)
            {
                io.WriteLine($"Enter age of person {i + 1}:");
                age = io.ReadInt(ERROR_AGE, MIN_AGE, MAX_AGE);
                total += CalculateMoviePrice(age);
            }

            io.WriteLine($"There are {group} people in your group. And total price will be: {total}");
        }
    }
}
