using Common.Logging;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Service.Jobs
{
    public class CommonSyncCheckJob : IJob
    {
        ILog logger;

        public CommonSyncCheckJob()
        {
            logger = LogManager.GetLogger<CommonSyncCheckJob>();
        }

        public void Execute(IJobExecutionContext context)
        {
            context.Scheduler.PauseJob(context.JobDetail.Key);
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                    types = types.Where(o => o.Name.EndsWith("Sync") && o.GetInterfaces().Contains(typeof(ISync))).ToArray();
                    DateTime startTime = DateTime.Today.AddDays(-3);
                    DateTime endTime = DateTime.Today;
                    foreach (Type type in types)
                    {
                        ISync sync = (ISync)Activator.CreateInstance(type, model);
                        sync.CheckQueue(startTime, endTime);
                        model.SaveChanges();
                    }
                }
                sw.Stop();
                logger.InfoFormat("CommonSyncCheck {0}.", sw.Elapsed);
            }
            catch (Exception e)
            {
                logger.Error("Execute failed.", e);
            }
            context.Scheduler.ResumeJob(context.JobDetail.Key);
        }
    }
}
