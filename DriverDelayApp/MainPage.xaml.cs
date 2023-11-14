using Microsoft.Maui.Controls;

namespace YourAppName
{
    public partial class MainPage : ContentPage
    {
        private int totalDelayMinutes = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnAddStopClicked(object sender, EventArgs e)
        {
            // Calculate the delay for the current stop
            TimeSpan arrivedTime = arrivedTimePicker.Time;
            TimeSpan departedTime = departedTimePicker.Time;
            int paidMinutes = int.Parse(paidEntry.Text);

            int delayMinutes = (int)(departedTime - arrivedTime).TotalMinutes - paidMinutes;
            totalDelayMinutes += delayMinutes;

            // Update the total time delayed label
            totalTimeLabel.Text = totalDelayMinutes.ToString() + " minutes";
        }

        private void OnRemoveStopClicked(object sender, EventArgs e)
        {
            // Remove the delay for the last stop (if any)
            totalDelayMinutes = Math.Max(0, totalDelayMinutes);

            // Update the total time delayed label
            totalTimeLabel.Text = totalDelayMinutes.ToString() + " minutes";
        }
    }
}
