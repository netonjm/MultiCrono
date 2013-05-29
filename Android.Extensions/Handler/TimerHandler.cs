using System;
using Java.Util;

namespace Windows.Extensions.Handlers
{


    public class TimerHandler
    {

        private readonly Timer _periodicTimer;

        public enum Priority
        {
            Low = -1,
            Normal = 0,
            High = 1,
        }

        public delegate void TimerDispatchedHandler();

        public TimerHandler(TimerElapsedHandler handler, TimeSpan period, TimerDestroyedHandler destroyed)
        {
            _periodicTimer = ThreadPoolTimer.CreatePeriodicTimer(handler, period, destroyed);
        }


        public void Cancel()
        {
            _periodicTimer.Cancel();
        }



    }
}
