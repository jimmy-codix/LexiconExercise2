using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
    internal class Logic
    {
        const int MENU_EXIT = 0;
        const int MENU_MOVIES_SINGLE = 1;
        const int MENU_MOVIES_GROUP = 2;
        const int MENU_REPEAT = 3;
        const int MENU_SPLIT = 4;

        const int MOVIE_YOUTH_PRICE = 80;
        const int MOVIE_SENIOR_PRICE = 90;
        const int MOVIE_STANDARD_PRICE = 120;
        const int MOVIE_FREE_PRICE = 0;

        InputOutputManager io;

        public Logic()
        {
            io = new InputOutputManager();
        }

        public void Run()
        {
            io.Clear();
            MainMenu.Print(io);
            io.WriteLine("Please enter your selection:");
            int menuChoice = io.ReadInt("Wrong input. Please Try Again:", 0,4);

            switch (menuChoice)
            {
                case MENU_MOVIES_SINGLE: TaskMoviesSingle(); break;
                case MENU_MOVIES_GROUP: TaskMoviesGroup(); break;
                case MENU_REPEAT: TaskRepeat(); break;
                case MENU_SPLIT: TaskSplit(); break;
                case MENU_EXIT: TaskExit(); break;
            }
        }

        private void TaskExit()
        {
            io.WriteLine("You selected exit");
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

        private void TaskMoviesSingle()
        {
            do
            {
                io.WriteLine("***Movies, calculate price for one person***");
                io.WriteLine("Enter your age:");
                int age = io.ReadInt("Wrong age. Please try again: ", 0, 125);
                switch (age)
                {
                    case MOVIE_FREE_PRICE: io.WriteLine($"Your price: {MOVIE_FREE_PRICE} (Free)"); break;
                    case MOVIE_YOUTH_PRICE: io.WriteLine($"Your price: {MOVIE_YOUTH_PRICE} (Youth)"); break;
                    case MOVIE_SENIOR_PRICE: io.WriteLine($"Your price: {MOVIE_SENIOR_PRICE} (Senior)"); break; ;
                    default: io.WriteLine($"Your price: {MOVIE_STANDARD_PRICE} (Standard)"); break;
                }
            } while (ReturnOrRepeat());

            Run();
        }

        private void TaskMoviesGroup()
        {
            do
            {
                int total = 0;
                int age = 0;
                io.WriteLine("***Movies, calculate price for a group***");
                io.WriteLine("How many people are their in your group:");
                int group = io.ReadInt("Incorrect input. Please try again:", 1, 100);
                for (int i = 0; i < group; i++)
                {
                    io.WriteLine($"Enter age of person {i + 1}:");
                    age = io.ReadInt("Incorect input. Please try again.", 0, 125);
                    total += CalculateMoviePrice(age);
                }

                io.WriteLine($"There are {group} people in your group. And total price will be: {total}");
            } while (ReturnOrRepeat());

            Run();

        }

        private void TaskRepeat()
        {
            do
            {
                io.Clear();
                io.WriteLine("**Repeat 10 times**");
                io.WriteLine("(Enter 0 to go back to main menu)");
                io.WriteLine("Please enter anything. I will the repeat this 10 times:");
                string text = io.ReadLine();
                for (int i = 0; i < 10; i++)
                {
                    io.Write($"{text} ");
                }
            } while (ReturnOrRepeat());

            Run();
        }

        private void TaskSplit()
        {
            do
            {
                io.Clear();
                io.WriteLine("Write a sentence with at least 3 words. I will then display the 3rd word:");
                string test = io.ReadLine();
                var result = test.Split(" ");
                List<string> strings = new List<string>();
                strings = result.ToList();
                strings.RemoveAll(x => string.IsNullOrWhiteSpace(x));
                if (strings.Count < 3)
                    io.WriteLine("There not 3 words in your sentence.");
                else
                    io.WriteLine($"Your third word was: {strings[2]}");
            } while (ReturnOrRepeat());

            Run();
        }

        private bool ReturnOrRepeat()
        {
            io.WriteLine("Do you want to try again? Type 1 for Main Menu or 2 to do this again.");
            int val = io.ReadInt("Incorrect input. Please try again.",1,2);
            if (val == 1) return false;
            return true;
        }

    }
}
