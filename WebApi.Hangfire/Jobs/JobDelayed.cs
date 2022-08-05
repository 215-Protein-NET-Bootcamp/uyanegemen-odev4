namespace WebApi.Hangfire.Jobs
{
    public static class JobDelayed
    {
        public static string Run()
        {
            Console.WriteLine("JobDelayed");
            return "JobDelayed";
        }
    }
}
