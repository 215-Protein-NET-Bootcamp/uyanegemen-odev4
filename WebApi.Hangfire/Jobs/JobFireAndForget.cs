namespace WebApi.Hangfire.Jobs
{
    public static class JobFireAndForget
    {
        public static string Run()
        {
            Console.WriteLine("FireAndForget");
            return "FireAndForget";
        }
    }
}
