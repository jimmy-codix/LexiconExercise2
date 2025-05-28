using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
    internal static class MainMenu
    {
        public static void Print(InputOutputManager io)
        {
            io.Clear();
            io.WriteLine("**Welcome to the main menu**");
            io.WriteLine("1. Movies, calculate price for one person.");
            io.WriteLine("2. Movies, calculate price for a group.");
            io.WriteLine("3. Repeat 10 times.");
            io.WriteLine("4. String splitter.");
            io.WriteLine("0. Exit this program.");
        }
    }
}
