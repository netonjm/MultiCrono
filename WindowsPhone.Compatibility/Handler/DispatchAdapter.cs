using System;
using System.Windows;

namespace Android.Extensions.Handler
{
    public interface IDispatchOnUIThread
    {
        void Invoke(Action action);
    }

    public class DispatchAdapter : IDispatchOnUIThread
    {
        public void Invoke(Action action)
        {
            Deployment.Current.Dispatcher.BeginInvoke(action);
        }
    }
}