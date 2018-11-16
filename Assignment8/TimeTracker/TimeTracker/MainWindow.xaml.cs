using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private DateTime _lastTickTime;
        TimeManager tm;
        TimeSpan interval;
        DateTime begin;
        DateTime now;
        Boolean running;

        public MainWindow()
        {
            InitializeComponent();

            running = false;
            tm = new TimeManager();
            DateTime start = DateTime.Now;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += TimerOnTick;
            _lastTickTime = DateTime.Now;
            
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            now = DateTime.Now;
            interval = now - begin;
            double elapsed = interval.Seconds;
            MsgText.Text = elapsed.ToString();
            TimeText.Text = now.ToString();
            _lastTickTime = now;

        }

        private void ClickMeStartButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (!running)
            {
                tm.Start();
            }
            
        }

        private void ClickMeFinishButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (running)
            {
                tm.Stop();
            }
            
        }

        private void ClickMeDeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            ListBox.Items.Remove(ListBox.SelectedItem);
        }
    }
}
