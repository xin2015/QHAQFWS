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
        /// <summary>
        /// 数据库实体类
        /// </summary>
        protected QHAQFWSModel Model { get; set; }
        /// <summary>
        /// 数据名称
        /// </summary>
        protected string ModelName { get; set; }
        /// <summary>
        /// 日志记录器
        /// </summary>
        protected ILog Logger { get; set; }
        /// <summary>
        /// 空值字符串
        /// </summary>
        protected string NullValueString { get; set; }

        /// <summary>
        /// 同步基类构造函数
        /// </summary>
        /// <param name="model">数据库实体类</param>
        public SyncBase(QHAQFWSModel model)
        {
            Model = model;
            ModelName = typeof(TEntity).Name;
            Logger = LogManager.GetLogger(ModelName);
            NullValueString = "—";
        }

        /// <summary>
        /// 检查同步队列
        /// </summary>
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

        /// <summary>
        /// 检查同步队列
        /// </summary>
        /// <param name="time">时间</param>
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

        /// <summary>
        /// 获取同步开始时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        protected virtual DateTime GetStartTime(DateTime time)
        {
            return time.AddDays(1);
        }

        /// <summary>
        /// 获取同步结束时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        protected virtual DateTime GetEndTime(DateTime time)
        {
            return time.AddYears(10);
        }

        /// <summary>
        /// 检查同步队列
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public virtual void CheckQueue(DateTime startTime, DateTime endTime)
        {
            for (DateTime time = startTime; time <= endTime; time = GetNextTime(time))
            {
                CheckQueue(time);
            }
        }

        /// <summary>
        /// 获取下一次同步的时间
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        protected virtual DateTime GetNextTime(DateTime time)
        {
            return time.AddDays(1);
        }

        /// <summary>
        /// 同步
        /// </summary>
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

        /// <summary>
        /// 获取最小同步时间（小于该时间的队列将不会继续同步）
        /// </summary>
        /// <returns></returns>
        protected virtual DateTime GetMinSyncTime()
        {
            return DateTime.Today.AddDays(-7);
        }

        /// <summary>
        /// 同步
        /// </summary>
        /// <param name="queues">同步队列</param>
        protected virtual void Sync(List<SyncDataQueue> queues)
        {
            foreach (SyncDataQueue queue in queues)
            {
                try
                {
                    SyncData(queue.Time);
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

        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="queue">同步队列</param>
        protected virtual void SyncData(DateTime time)
        {
            try
            {
                List<TEntity> list = GetSyncData(time);
                if (list.Any())
                {
                    Model.Set<TEntity>().AddRange(list);
                    Model.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Logger.DebugFormat("{0} SyncData：{1}", e, ModelName, time.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }

        /// <summary>
        /// 获取同步数据
        /// </summary>
        /// <param name="queue">同步队列</param>
        /// <returns></returns>
        protected abstract List<TEntity> GetSyncData(DateTime time);

        /// <summary>
        /// 判断是否已完成同步
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns></returns>
        protected abstract bool IsSynchronized(DateTime time);

        /// <summary>
        /// 回补
        /// </summary>
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

        /// <summary>
        /// 删除
        /// </summary>
        public virtual void Remove()
        {
            DateTime time = GetTime();
            Remove(time);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="time">时间</param>
        public virtual void Remove(DateTime time)
        {
            try
            {
                SyncDataQueue queue = Model.SyncDataQueue.FirstOrDefault(o => o.ModelName == ModelName && o.Time == time);
                if (queue != null)
                {
                    Model.SyncDataQueue.Remove(queue);
                }
                RemoveData(time);
                Model.SaveChanges();
            }
            catch (Exception e)
            {
                Logger.ErrorFormat("{0} CheckQueue", e, ModelName);
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="time">时间</param>
        protected abstract void RemoveData(DateTime time);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        public virtual void Remove(DateTime startTime, DateTime endTime)
        {
            for (DateTime time = startTime; time <= endTime; time = GetNextTime(time))
            {
                Remove(time);
            }
        }

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="value">数值</param>
        /// <param name="multiplier">倍数</param>
        /// <returns></returns>
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

        /// <summary>
        /// 格式化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected virtual string Format(string value)
        {
            return value.StartsWith("-") ? NullValueString : value;
        }
    }
}
