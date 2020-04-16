using QHAQFWS.Core.Sync.Base;
using QHAQFWS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QHAQFWS.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime startTime;
        DateTime endTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetTime()
        {
            if (!DateTime.TryParse(StartTimeTextBox.Text, out startTime))
            {
                startTime = DateTime.Today;
            }
            if (!DateTime.TryParse(EndTimeTextBox.Text, out endTime))
            {
                endTime = startTime;
            }
        }

        private void Sync_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTime();
                string modelName = ModelNameComboBox.Text;
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                    Type syncType = types.FirstOrDefault(o => o.Name == modelName);
                    ISync sync = (ISync)Activator.CreateInstance(syncType, model);
                    sync.CheckQueue(startTime, endTime);
                    model.SaveChanges();
                    sync.Sync();
                }
                ResultTextBox.Text = string.Format("Sync succeed.{0}", DateTime.Now);
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = string.Format("Sync failed.{0} {1}", DateTime.Now, ex.Message);
            }
        }

        private void CheckQueue_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTime();
                string modelName = ModelNameComboBox.Text;
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                    Type syncType = types.FirstOrDefault(o => o.Name == modelName);
                    ISync sync = (ISync)Activator.CreateInstance(syncType, model);
                    sync.CheckQueue(startTime, endTime);
                    model.SaveChanges();
                }
                ResultTextBox.Text = string.Format("CheckQueue succeed.{0}", DateTime.Now);
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = string.Format("CheckQueue failed.{0} {1}", DateTime.Now, ex.Message);
            }
        }

        private void Cover_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTime();
                string modelName = ModelNameComboBox.Text;
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                    Type syncType = types.FirstOrDefault(o => o.Name == modelName);
                    ISync sync = (ISync)Activator.CreateInstance(syncType, model);
                    sync.CheckQueue(startTime, endTime);
                    model.SaveChanges();
                    sync.Cover();
                }
                ResultTextBox.Text = string.Format("Cover succeed.{0}", DateTime.Now);
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = string.Format("Cover failed.{0} {1}", DateTime.Now, ex.Message);
            }
        }

        private void Remove_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTime();
                string modelName = ModelNameComboBox.Text;
                using (QHAQFWSModel model = new QHAQFWSModel())
                {
                    Type[] types = Assembly.GetAssembly(typeof(ISync)).GetTypes();
                    Type syncType = types.FirstOrDefault(o => o.Name == modelName);
                    ISync sync = (ISync)Activator.CreateInstance(syncType, model);
                    sync.Remove(startTime, endTime);
                    model.SaveChanges();
                }
                ResultTextBox.Text = string.Format("Remove succeed.{0}", DateTime.Now);
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = string.Format("Remove failed.{0} {1}", DateTime.Now, ex.Message);
            }
        }
    }
}
