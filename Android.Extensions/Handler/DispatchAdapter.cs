using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Windows.Extensions.Handlers;

namespace Android.Extensions.Handler
{
    public interface IDispatchOnUIThread
    {
        void Invoke(Action action);
    }

    public class DispatchAdapter : IDispatchOnUIThread
    {
        public readonly Activity owner;
        public DispatchAdapter(Activity owner)
        {
            this.owner = owner;
        }
        public void Invoke(Action action)
        {
            owner.RunOnUiThread(action);
        }
    }
}