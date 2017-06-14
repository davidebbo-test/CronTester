using System;
using NCrontab;

namespace CronTester
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Pass cron expression on command line, and optionally an iteration count");
                return;
            }

            int maxCount = args.Length == 1 ? 10 : Int32.Parse(args[1]);

            try
            {
                var schedule = CrontabSchedule.Parse(args[0], new CrontabSchedule.ParseOptions { IncludingSeconds = true });

                int count = 0;
                foreach (var occurence in schedule.GetNextOccurrences(DateTime.Now, DateTime.Now.AddYears(1)))
                {
                    Console.WriteLine(occurence);

                    count++;
                    if (count == maxCount) break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}