using LexiconExercise2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
    internal static class MainMenu
    {
        public static void Print(IInputOutputManager io)
        {
            io.Clear();
            io.WriteLine("**Welcome to the main menu**");
            io.WriteLine("1. Movies, calculate price (Single).");
            io.WriteLine("2. Movies, calculate price (Group).");
            io.WriteLine("3. Repeat 10 times.");
            io.WriteLine("4. String splitter.");
            io.WriteLine("0. Exit this program.");
        }
    }
}
