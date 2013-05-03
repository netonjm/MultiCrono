using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.Management;

namespace Windows.Extensions.Handlers
{
    public static class CommonDispatcher
    {

        public static IAsyncAction BeginInvoke(DispatchedHandler dispatchedHandler)
        {
           return Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, dispatchedHandler);
            //return Dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);
        }

        public static IAsyncAction BeginInvoke(Page page, DispatchedHandler dispatchedHandler)
        {
            return page.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, dispatchedHandler);
        }
    }
}