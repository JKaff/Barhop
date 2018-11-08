using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Vidly.ScheduledTasks.ScheduledTasks
{
    public class YelpDatabaseRefresher
    {
        public static void Main()
        {
            // trigger async evaluation
            RunProgram().GetAwaiter().GetResult();
        }
        public static async Task RunProgram()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<UpdateDatabaseToMatchYelp>().Build();


                ITrigger trigger = TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule
                    (s =>
                        s.WithIntervalInHours(24)
                            .OnEveryDay()
                            .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(19, 30))
                    )
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }

        }
    }
}