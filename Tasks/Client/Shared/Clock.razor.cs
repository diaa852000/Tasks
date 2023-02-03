namespace Tasks.Client.Shared
{
    public partial class Clock
    {
        private double _hour, _min, _sec;
        private Timer _timer;



        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            _timer = new Timer(callback: ClockTime, state: new AutoResetEvent(false), dueTime: 0, period: 10);

        }

        private void ClockTime(object state)
        {
            var time = DateTime.Now;

            _hour = 360.0 * time.Hour / 12 + 30.0 * time.Minute / 60;
            _min = 360.0 * time.Minute / 60 + 6.0 * time.Second / 60;
            _sec = 360.0 * time.Second / 60 + 6.0 * time.Millisecond / 1000;

            StateHasChanged();
        }


        /*
    
         using timer for executing a func periodically by sec or min..etc

         autoReset => fasle
         The state argument of the CheckStatus method is an AutoResetEvent object that is used to synchronize the application thread and 
         the thread pool thread that executes the callback delegate.

         Represents a thread synchronization event that, when signaled, resets automatically
         after releasing a single waiting thread

         delay befeor invoking the callback func(clockTime) => 0
         time interval => 10 ms



         */


    }
}
