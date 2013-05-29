using System;
using System.Threading.Tasks;
using MultiCrono.Common;
using MultiCrono.ViewModels;
using Windows.Data.Xml.Dom;
using Windows.Extensions.Handlers;
using Windows.Extensions.Helpers;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MultiCrono.WindowsStore
{

    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainViewModel ViewModel
        {
            get { return App.ViewModel; }
        }


        public MainPage()
        {
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            
            ViewModel.PlayRequested += ActualContext_PlayRequested;

            this.Loaded += MainPage_Loaded;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        /// <summary>
        ///     Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">
        ///     Event data that describes how this page was reached.  The Parameter
        ///     property is typically used to configure the page.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }

        void ActualContext_PlayRequested(object sender, EventArgs e)
        {
            CommonDispatcher.BeginInvoke(() => SoundHelper.PlaySound1(MediaControl));
        }

       
    }
}