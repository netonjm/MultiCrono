using System;
using System.Windows;
using Android.App;
using Windows.UI.Core;

namespace Windows.Extensions.Handlers
{
    public static class CommonDispatcher
    {
       

        public static DispatcherOperation BeginInvoke(Activity page, DispatchedHandler dispatchedHandler)
        {
            return page.Dispatcher.BeginInvoke(() => dispatchedHandler());
        }

        //return App.dispatcher;
        // await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(new CoreDispatcherPriority(), action);
        // Window.Current.Dispatcher.RunAsync(priority, action)

        public static DispatcherOperation BeginInvoke(DispatchedHandler dispatchedHandler)
        {
            return Deployment.Current.Dispatcher.BeginInvoke(() => dispatchedHandler());
        }

        // Deployment.Current.Dispatcher
    }
}