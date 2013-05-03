using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Phone.Controls;

namespace Windows.UI.Core
{
      public enum AsyncStatus
  {
    Started,
    Completed,
    Canceled,
    Error,
  }

    public enum CoreDispatcherPriority
  {
    Low = -1,
    Normal = 0,
    High = 1,
  }

     public delegate void AsyncActionCompletedHandler(IAsyncAction asyncInfo, AsyncStatus asyncStatus);
     public interface IAsyncAction
  {
    /// <summary>
    /// Returns the results of the action.
    /// </summary>
    void GetResults();
    /// <summary>
    /// Gets or sets the method that handles the action completed event.
    /// </summary>
    /// 
    /// <returns>
    /// The method that handles the event.
    /// </returns>
    AsyncActionCompletedHandler Completed { get; set; }
  }

    public class CoreDispatcher
    {

        public Page page { get; set; }
        
        public IAsyncAction RunAsync(CoreDispatcherPriority priority, DispatchedHandler agileCallback)
        {
            if (page!=null) 
            page.Dispatcher.BeginInvoke(() => agileCallback());
            return null;
        }
    }
}
