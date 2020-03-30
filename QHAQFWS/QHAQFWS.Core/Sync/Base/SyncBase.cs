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

        public void Sync()
        {
            try
            {
                DateTime now = DateTime.Now;
                List<SyncDataQueue> queues = Model.SyncDataQueue.Where(o => o.ModelName == ModelName && !o.Status && o.StartTime <= now && o.EndTime >= now).ToList();
                foreach (SyncDataQueue queue in queues)
                {
                    try
                    {
                        Sync(queue);
                        queue.Status = true;
                    }
                    catch (Exception e)
                    {
                        Logger.DebugFormat("{0}：{1}", e, ModelName, queue.Time.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    queue.LastTime = DateTime.Now;
                    Model.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0} Sync", e, ModelName);
            }
        }

        protected virtual void Sync(SyncDataQueue queue)
        {
            List<TEntity> list = GetSyncData(queue);
            if (list.Any())
            {
                Model.Set<TEntity>().AddRange(list);
            }
            else
            {
                throw new Exception("数据获取失败！");
            }
        }

        protected abstract List<TEntity> GetSyncData(SyncDataQueue queue);

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

        public void CheckQueue()
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

        protected virtual DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(1);
        }

        protected virtual DateTime GetEndTime(DateTime time)
        {
            return time.AddDays(6);
        }

        protected virtual DateTime GetNextTime(DateTime time)
        {
            return time.AddDays(1);
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

        public virtual void CheckQueue(DateTime startTime, DateTime endTime)
        {
            for (DateTime time = startTime; time <= endTime; time = GetNextTime(time))
            {
                CheckQueue(time);
            }
        }
    }
}
