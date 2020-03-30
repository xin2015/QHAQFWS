using Common.Logging;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Service.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace QHAQFWS.Service
{
    class QHAQFWSService : ServiceControl
    {
        private ILog logger;
        private IScheduler scheduler;

        public QHAQFWSService()
        {
            logger = LogManager.GetLogger<QHAQFWSService>();
            Initialize();
        }

        public virtual void Initialize()
        {
            try
            {
                logger.Info("-------- Initialization Start --------");
                scheduler = StdSchedulerFactory.GetDefaultScheduler();
                logger.Info("-------- Scheduling Jobs --------");
                Action<string, Type, string> scheduleJobAction = (jobName, jobType, jobCronExpression) =>
                {
                    IJobDetail job = JobBuilder.Create(jobType)
                        .WithIdentity(jobName)
                        .Build();
                    ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
                        .WithIdentity(string.Format("Trigger{0}", jobName))
                        .WithCronSchedule(jobCronExpression)
                        .Build();
                    scheduler.ScheduleJob(job, trigger);
                };
                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
                IEnumerable<Type> jobTypes = types.Where(o => o.Name.EndsWith("Job") && o.GetInterfaces().Contains(typeof(IJob)));
                foreach (Type type in jobTypes)
                {
                    string jobCronExpression = ConfigurationManager.AppSettings[string.Format("{0}CronExpression", type.Name)];
                    if (!string.IsNullOrEmpty(jobCronExpression))
                    {
                        scheduleJobAction(type.Name, type, jobCronExpression);
                    }
                }
                Type syncJobBaseType = typeof(SyncJobBase<>);
                types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                jobTypes = types.Where(o => o.Name.EndsWith("Sync") && o.GetInterfaces().Contains(typeof(ISync)));
                foreach (Type type in jobTypes)
                {
                    string jobCronExpression = ConfigurationManager.AppSettings[string.Format("{0}CronExpression", type.Name)];
                    if (!string.IsNullOrEmpty(jobCronExpression))
                    {
                        scheduleJobAction(type.Name, syncJobBaseType.MakeGenericType(type), jobCronExpression);
                    }
                }
                logger.Info("-------- Initialization Complete --------");
            }
            catch (Exception e)
            {
                logger.Fatal("Server initialization failed.", e);
            }
        }

        public virtual void Start()
        {
            try
            {
                scheduler.Start();
            }
            catch (Exception ex)
            {
                logger.Fatal("Scheduler start failed.", ex);
            }
        }

        public virtual void Stop()
        {
            try
            {
                scheduler.Shutdown(true);
            }
            catch (Exception ex)
            {
                logger.Error("Scheduler stop failed.", ex);
            }
        }

        public bool Start(HostControl hostControl)
        {
            Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Stop();
            return true;
        }
    }
}
