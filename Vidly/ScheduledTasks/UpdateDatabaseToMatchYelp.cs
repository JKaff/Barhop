using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Quartz;

namespace Vidly.ScheduledTasks.ScheduledTasks
{
    public class UpdateDatabaseToMatchYelp : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Debug.WriteLine("Just Updated DB");

            return null;
        }
    }
}