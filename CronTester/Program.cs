using System;
using NCrontab;

namespace CronTester
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Pass cron expression on command line");
                return;
            }

            try
            {
                var schedule = CrontabSchedule.Parse(args[0], new CrontabSchedule.ParseOptions { IncludingSeconds = true });

                int count = 0;
                foreach (var occurence in schedule.GetNextOccurrences(DateTime.Now, DateTime.Now.AddYears(1)))
                {
                    Console.WriteLine(occurence);

                    count++;
                    if (count == 10) break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}