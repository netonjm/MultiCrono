using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Windows.UI.Core;

namespace Windows.Extensions.Handlers
{
    public static class CommonDispatcher
    {
        public static DispatcherOperation BeginInvoke(Page page, DispatchedHandler dispatchedHandler)
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