using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync.Base
{
    /// <summary>
    /// 数据同步接口
    /// </summary>
    public interface ISync
    {
        /// <summary>
        /// 检查同步队列
        /// </summary>
        void CheckQueue();
        /// <summary>
        /// 检查同步队列
        /// </summary>
        /// <param name="time">时间</param>
        void CheckQueue(DateTime time);
        /// <summary>
        /// 检查同步队列
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        void CheckQueue(DateTime startTime, DateTime endTime);
        /// <summary>
        /// 同步
        /// </summary>
        void Sync();
        /// <summary>
        /// 回补
        /// </summary>
        void Cover();
        void Remove();
        void Remove(DateTime time);
        void Remove(DateTime startTime, DateTime endTime);
    }
}
