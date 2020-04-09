using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QHAQFWS.Core.Sync.Base
{
    public interface ISync
    {
        void CheckQueue();
        void CheckQueue(DateTime time);
        void CheckQueue(DateTime startTime, DateTime endTime);
        void Sync();
        void Cover();
    }
}
