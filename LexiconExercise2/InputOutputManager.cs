using LexiconExercise2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconExercise2
{
    internal class InputOutputManager : IInputOutputManager
    {

        public void Clear()
        {
            Console.Clear();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public int ReadInt(string errorText, int min, int max)
        {
            do
            {
                int value;
                string raw = ReadLine();
                if (int.TryParse(raw, out value))
                {
                    if (value >= min && value <= max)
                        return value;
                    else
                        WriteLine(errorText);
                }
                else
                {
                    WriteLine(errorText);
                }
            } while (true);

        }
    }
}
