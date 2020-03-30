using Common.Logging;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Service.Jobs
{
    public class SyncJobBase<TSync> : IJob where TSync : ISync
    {
        ILog logger;

        public SyncJobBase()
        {
            logger = LogManager.GetLogger<SyncJobBase<TSync>>();
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
                    ISync sync = (ISync)Activator.CreateInstance(typeof(TSync), model);
                    sync.CheckQueue();
                    model.SaveChanges();
                    sync.Sync();
                }
                sw.Stop();
                logger.InfoFormat("{0} Sync {1}.", typeof(TSync).Name, sw.Elapsed);
            }
            catch (Exception e)
            {
                logger.Error("Execute failed.", e);
            }
            context.Scheduler.ResumeJob(context.JobDetail.Key);
        }
    }
}
