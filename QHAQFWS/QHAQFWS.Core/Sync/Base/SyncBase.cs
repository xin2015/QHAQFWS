using Common.Logging;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync.Base
{
    public abstract class SyncBase<TEntity> : ISync where TEntity : class
    {
        protected QHAQFWSModel Model { get; set; }
        protected string ModelName { get; set; }
        protected ILog Logger { get; set; }
        protected string NullValueString { get; set; }

        public SyncBase(QHAQFWSModel model)
        {
            Model = model;
            ModelName = typeof(TEntity).Name;
            Logger = LogManager.GetLogger(ModelName);
            NullValueString = "—";
        }

        public virtual void CheckQueue()
        {
            DateTime time = GetTime();
            CheckQueue(time);
        }

        /// <summary>
        /// 获取时间
        /// </summary>
        /// <returns></returns>
        protected virtual DateTime GetTime()
        {
            return DateTime.Today.AddDays(-1);
        }

        public virtual void CheckQueue(DateTime time)
        {
            try
            {
                SyncDataQueue queue = Model.SyncDataQueue.FirstOrDefault(o => o.ModelName == ModelName && o.Time == time);
                if (queue == null)
                {
                    queue = new SyncDataQueue()
                    {
                        ModelName = ModelName,
                        Time = time,
                        StartTime = GetStartTime(time),
                        EndTime = GetEndTime(time),
                        LastTime = DateTime.Now
                    };
                    Model.SyncDataQueue.Add(queue);
                }
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0} CheckQueue", e, ModelName);
            }
        }

        protected virtual DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(1);
        }

        protected virtual DateTime GetEndTime(DateTime time)
        {
            return time.AddDays(6);
        }

        public virtual void CheckQueue(DateTime startTime, DateTime endTime)
        {
            for (DateTime time = startTime; time <= endTime; time = GetNextTime(time))
            {
                CheckQueue(time);
            }
        }

        protected virtual DateTime GetNextTime(DateTime time)
        {
            return time.AddDays(1);
        }

        public virtual void Sync()
        {
            try
            {
                DateTime minSyncTime = GetMinSyncTime();
                DateTime now = DateTime.Now;
                List<SyncDataQueue> queues = Model.SyncDataQueue.Where(o => o.ModelName == ModelName && o.Time >= minSyncTime && !o.Status && o.StartTime <= now && o.EndTime >= now).ToList();
                Sync(queues);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0} Sync", e, ModelName);
            }
        }

        protected virtual DateTime GetMinSyncTime()
        {
            return DateTime.Today.AddDays(-7);
        }

        protected virtual void Sync(List<SyncDataQueue> queues)
        {
            foreach (SyncDataQueue queue in queues)
            {
                try
                {
                    SyncData(queue);
                    if (IsSynchronized(queue.Time))
                    {
                        queue.Status = true;
                    }
                    queue.LastTime = DateTime.Now;
                    Model.SaveChanges();
                }
                catch (Exception e)
                {
                    Logger.DebugFormat("{0} Sync：{1}", e, ModelName, queue.Time.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
        }

        protected virtual void SyncData(SyncDataQueue queue)
        {
            try
            {
                List<TEntity> list = GetSyncData(queue);
                if (list.Any())
                {
                    Model.Set<TEntity>().AddRange(list);
                    Model.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.DebugFormat("{0} SyncData：{1}", e, ModelName, queue.Time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        protected abstract List<TEntity> GetSyncData(SyncDataQueue queue);

        protected abstract bool IsSynchronized(DateTime time);

        public virtual void Cover()
        {
            try
            {
                DateTime minSyncTime = GetMinSyncTime();
                DateTime now = DateTime.Now;
                List<SyncDataQueue> queues = Model.SyncDataQueue.Where(o => o.ModelName == ModelName && o.Time < minSyncTime && !o.Status && o.StartTime <= now && o.EndTime >= now).ToList();
                Sync(queues);
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0} Cover", e, ModelName);
            }
        }

        protected virtual string Format(string value, int multiplier)
        {
            string result;
            if (value.StartsWith("-"))
            {
                result = NullValueString;
            }
            else
            {
                decimal temp;
                if (decimal.TryParse(value, out temp))
                {
                    result = Math.Round(temp * multiplier).ToString();
                }
                else
                {
                    result = NullValueString;
                }
            }
            return result;
        }

        protected virtual string Format(string value)
        {
            return value.StartsWith("-") ? NullValueString : value;
        }
    }
}
