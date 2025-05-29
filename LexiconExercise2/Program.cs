namespace LexiconExercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputOutputManager io = new InputOutputManager();
            Logic logic = new Logic(io);
            logic.Run();
        }
    }
}
