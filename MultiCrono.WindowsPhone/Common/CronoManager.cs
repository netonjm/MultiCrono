using System;
using Windows.Extensions.Handlers;
using Windows.System.Threading;
using Windows.UI.Core;

namespace MultiCrono.Common
{
    public class CronoManager
    {
        #region Delegates

        public delegate void NotificationHandler();

        public delegate void PlaySoundHandler();

        public delegate void RunAsyncHandler(TimerHandler.Priority priority, DispatchedHandler agileCallback);

        public delegate void SetCronoTextHandler(string text);

        public delegate void StartHandler();

        public delegate void StopHandler();

        public event NotificationHandler notification;
        public event PlaySoundHandler playSound;
        public event RunAsyncHandler runAsync;
        public event SetCronoTextHandler cronoText;
        public event StartHandler start;
        public event StopHandler stop;

        #endregion

        #region Properties

        public enum TimeType
        {
            Hours = 1,
            Minutes = 2,
            Seconds = 3
        }

        private readonly TimeSpan _period = TimeSpan.FromSeconds(1);

        public DateTime EndTime;
        public bool IsStarted = false;

        public int MaxHours = 0;
        public int MaxMinutes = 0;
        public int MaxSeconds = 0;
        private TimerHandler _periodicTimer;

        #endregion

        #region Main Process

        public void StartStop()
        {
            if (!IsStarted)
                Start();
            else
            {
                IsStarted = false;
                _periodicTimer.Cancel();
            }
                
        }

        private void Start()
        {
            //Form elements
            if (start != null)
                start();

            SetCronoText();
            IsStarted = true;

            //Task.Run(() => StartThread());
            EndTime = GetEndDateTime();

            _periodicTimer = new TimerHandler(TimerThread,
                                              _period,
                                              (source) =>
                                                  {
                                                      if (IsStarted)
                                                      {
                                                          //HA FINALIZADO CORRECTAMENTE
                                                          if (playSound != null)
                                                              playSound();

                                                          if (notification != null)
                                                              notification();
                                                      }

                                                      Stop();
                                                  });
        }

        public void TimerThread(ThreadPoolTimer source)
        {
            TimeSpan tick = EndTime.Subtract(DateTime.Now);
            if (tick.TotalSeconds > 0 && IsStarted)
            {
                tick = EndTime.Subtract(DateTime.Now);
                try
                {
                    runAsync(TimerHandler.Priority.Normal,
                             () => SetCronoText(tick));
                }
                catch (Exception)
                {
                }
            }
            else
            {
                runAsync(TimerHandler.Priority.Normal,
                         source.Cancel);
            }
        }

        private void Stop()
        {
            IsStarted = false;
            SetCronoText();

            if (stop != null)
                stop();
        }

        #endregion

        public void ResetCount()
        {
            MaxHours = MaxMinutes = MaxSeconds = 0;
            SetCronoText();
        }

        public void AddTime(TimeType tipo, bool isAdding)
        {
            switch (tipo)
            {
                case TimeType.Hours:
                    MaxHours = GetNextValue(MaxHours, isAdding);
                    break;
                case TimeType.Minutes:
                    MaxMinutes = GetNextValue(MaxMinutes, isAdding);
                    break;
                case TimeType.Seconds:
                    MaxSeconds = GetNextValue(MaxSeconds, isAdding);
                    break;
            }

            SetCronoText();
        }

        public void SetCronoText()
        {
            SetCronoText(MaxHours, MaxMinutes, MaxSeconds);
        }

        public void SetCronoText(int hours, int minutes, int seconds)
        {
            if (cronoText != null)
                cronoText(String.Format("{0}:{1}:{2}", hours.ToString("00"), minutes.ToString("00"),
                                        seconds.ToString("00")));
        }

        public void SetCronoText(TimeSpan time)
        {
            SetCronoText(time.Hours, time.Minutes, time.Seconds);
        }

        private DateTime GetEndDateTime()
        {
            return DateTime.Now.AddHours(MaxHours).AddMinutes(MaxMinutes).AddSeconds(MaxSeconds + 1);
        }

        private static int GetNextValue(int actualValue, bool isAdding)
        {
            if (isAdding)
            {
                if (actualValue >= 59)
                    return 0;
                return actualValue + 1;
            }

            if (actualValue <= 0)
                return 59;
            return actualValue - 1;
        }
    }
}