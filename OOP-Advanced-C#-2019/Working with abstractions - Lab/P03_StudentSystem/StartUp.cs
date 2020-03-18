namespace P03_StudentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            var studentSystem = new StudentSystem();
            studentSystem.ParseCommand();
        }
    }
}
