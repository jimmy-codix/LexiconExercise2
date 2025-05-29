using LexiconExercise2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2.Tasks
{
    internal class TaskRepeat : ITask
    {

        public void Work(IInputOutputManager io)
        {
            io.Clear();
            string str = String.Empty;
            io.WriteLine("**Repeat 10 times**");
            io.WriteLine("Please enter anything. I will the repeat this 10 times:");
            string text = io.ReadLine();
            for (int i = 0; i < 10; i++)
            {
                str += $"{text},";
            }
            io.WriteLine($"Result: {str.TrimEnd(',')}");
        }
    }
}
