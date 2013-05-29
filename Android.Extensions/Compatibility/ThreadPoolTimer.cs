using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;


namespace Windows.System.Threading
{

    public delegate void TimerElapsedHandler(ThreadPoolTimer timer);
    public delegate void TimerDestroyedHandler(ThreadPoolTimer timer);

    public class ThreadPoolTimer
    {

        private DispatcherTimer newTimer;

        private TimerElapsedHandler _handler;
        private TimerDestroyedHandler _destroyed;


        public ThreadPoolTimer(TimerElapsedHandler handler, TimeSpan period, TimerDestroyedHandler destroyed)
        {

            _handler = handler;
            _destroyed = destroyed;

            newTimer = new DispatcherTimer();

            // timer interval specified as 1 second
            newTimer.Interval = TimeSpan.FromSeconds(1);
            // Sub-routine OnTimerTick will be called at every 1 second
            newTimer.Tick += delegate(object sender, EventArgs args) { _handler(this); };
            // starting the timer
            newTimer.Start();
        }

        public  static ThreadPoolTimer CreatePeriodicTimer(TimerElapsedHandler handler, TimeSpan period, TimerDestroyedHandler destroyed)
        {
           return  new ThreadPoolTimer(handler,period,destroyed);
        }

        public void Cancel()
        {
            newTimer.Stop();
            if (_destroyed != null)
                _destroyed(this);
        }

    }
}
