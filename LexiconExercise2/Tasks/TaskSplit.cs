using LexiconExercise2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Tasks
{
    internal class TaskSplit : ITask
    {
        
        public void Work(IInputOutputManager io)
        {
            io.Clear();
            io.WriteLine("**String splitter**");
            io.WriteLine("Write a sentence with at least 3 words. I will then display the 3rd word:");
            string test = io.ReadLine();
            var strings = test.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            if (strings.Length < 3)
                io.WriteLine("There are not 3 words in your sentence.");
            else
                io.WriteLine($"Your third word was: {strings[2]}");
        }
    }
}
