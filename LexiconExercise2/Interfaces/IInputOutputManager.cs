namespace LexiconExercise2.Interfaces
{
    internal interface IInputOutputManager
    {
        void Clear();
        int ReadInt(string errorText, int min, int max);
        string? ReadLine();
        void Write(string text);
        void WriteLine(string text);
    }
}