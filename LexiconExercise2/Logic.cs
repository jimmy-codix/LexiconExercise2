using LexiconExercise2.Enums;
using LexiconExercise2.Interfaces;
using LexiconExercise2.Tasks;
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

        const int MENU_MAX_INT = 4;
        const int MENU_MIN_INT = 0;

        IInputOutputManager io;

        public Logic(IInputOutputManager io)
        {
            this.io = io;
        }

        public void Run()
        {
            ITask task = null;
            io.Clear();
            MainMenu.Print(io);
            io.WriteLine("Please enter your selection:");
            int menuChoice = io.ReadInt("Wrong input. Please Try Again:", MENU_MIN_INT, MENU_MAX_INT);

            switch (menuChoice)
            {
                case MENU_MOVIES_SINGLE: task = new TaskMovies(MovieRoute.Single); break;
                case MENU_MOVIES_GROUP: task = new TaskMovies(MovieRoute.Group); break;
                case MENU_REPEAT: task = new TaskRepeat(); break;
                case MENU_SPLIT: task = new TaskSplit(); break;
                case MENU_EXIT: TaskExit(); break;
            }

            do 
            { task.Work(io); } while (ReturnOrRepeat()); 

            Run();
        }

        private void TaskExit()
        {
            Environment.Exit(0);
        }

        private bool ReturnOrRepeat()
        {
            io.WriteLine("Do you want to try again? Type 0 for Main Menu or 1 to do this again.");
            int val = io.ReadInt("Wrong input. Please Try Again:", 0, 1);
            if (val == 0)
                return false;
            return true;
        }
    }
}
