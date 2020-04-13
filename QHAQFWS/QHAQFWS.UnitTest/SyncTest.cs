using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QHAQFWS.Core.Sync;
using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;

namespace QHAQFWS.UnitTest
{
    [TestClass]
    public class SyncTest
    {
        #region Sync
        [TestMethod]
        public void CommonSyncTest()
        {
            using (QHAQFWSModel model = new QHAQFWSModel())
            {
                Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                types = types.Where(o => o.Name.EndsWith("Sync") && o.GetInterfaces().Contains(typeof(ISync))).ToArray();
                foreach (Type type in types)
                {
                    ISync sync = (ISync)Activator.CreateInstance(type, model);
                    sync.CheckQueue();
                    model.SaveChanges();
                    sync.Sync();
                }
            }
        }

        [TestMethod]
        public void CityAirQualityDailyForecastSourceDataSyncTest()
        {
            using (QHAQFWSModel model = new QHAQFWSModel())
            {
                CityAirQualityDailyForecastSourceDataSync sync = new CityAirQualityDailyForecastSourceDataSync(model);
                sync.CheckQueue(new DateTime(2020, 4, 10), new DateTime(2020, 4, 12));
                model.SaveChanges();
                sync.Sync();
            }
        }
        #endregion

        #region Cover
        [TestMethod]
        public void CommonDailyCoverTest()
        {
            using (QHAQFWSModel model = new QHAQFWSModel())
            {
                Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                types = types.Where(o => o.Name.EndsWith("Sync") && o.Name.Contains("Daily") && o.GetInterfaces().Contains(typeof(ISync))).ToArray();
                foreach (Type type in types)
                {
                    ISync sync = (ISync)Activator.CreateInstance(type, model);
                    DateTime startTime = DateTime.Today.AddDays(-7);
                    DateTime endTime = DateTime.Today.AddDays(-1);
                    sync.CheckQueue(startTime, endTime);
                    model.SaveChanges();
                    sync.Sync();
                }
            }
        }

        [TestMethod]
        public void CommonHourlyCoverTest()
        {
            using (QHAQFWSModel model = new QHAQFWSModel())
            {
                Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                types = types.Where(o => o.Name.EndsWith("Sync") && o.Name.Contains("Hourly") && o.GetInterfaces().Contains(typeof(ISync))).ToArray();
                foreach (Type type in types)
                {
                    ISync sync = (ISync)Activator.CreateInstance(type, model);
                    DateTime startTime = DateTime.Today.AddDays(-7);
                    DateTime endTime = DateTime.Today.AddDays(-6);
                    sync.CheckQueue(startTime, endTime);
                    model.SaveChanges();
                    sync.Sync();
                }
            }
        }
        #endregion
    }
}
