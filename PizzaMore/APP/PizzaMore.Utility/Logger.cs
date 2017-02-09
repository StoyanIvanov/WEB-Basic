namespace PizzaMore.Utility
{
    using System.IO;

    public static class Logger
    {
        public static void Log(string message)
        {
            StreamWriter stringWriter=new StreamWriter(@"Logs\log.txt", true);

            using (stringWriter)
            {
                stringWriter.WriteLine(message);
            }
        }
    }
}
