using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class TimeManager : IDateTime
    {
        private DateTime CurrentTime;
        

        public TimeManager()
        {

        }

        public bool CurrentTimerStatus { get; set; }
        public Action<bool> OnCompletion { get; set; }

        public void Stop()
        {

                _timer.Stop();
                running = false;
                MsgText.Text = "";
                ListBox.Items.Add(new ListBoxItem
                {
                    Content = now - begin
                    //Content = (ListBox.Items.Count)
                });

            // raise event due to time entry completed
            // the events args should contain the time entry that was completed
            // the WPF app should watch this event, when it is raised shoud add
            // the time entry to the ListBox

        }

        public void Start()
        {
                _timer.Start();
                TimeText.Text = begin.ToString();
                running = true;
                MsgText.Text = "running...";
                begin = DateTime.Now;
                TimeText.Text = begin.ToString();
        }

        public DateTime SystemTime(DateTime? now = null)
        {
            return now.GetValueOrDefault(System.DateTime.Now);
        }
    }
}
