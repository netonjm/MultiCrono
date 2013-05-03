using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using Microsoft.Phone.Controls;
using MultiCrono.Common;
using MultiCrono.ViewModels;
using Windows.Extensions.Handlers;
using Windows.Extensions.Helpers;

namespace MultiCrono.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {

        public MainViewModel ViewModel {
            get { return App.ViewModel; }
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            ViewModel.PlayRequested += ActualContext_PlayRequested;

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }


        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        void ActualContext_PlayRequested(object sender, EventArgs e)
        {
            CommonDispatcher.BeginInvoke(() => SoundHelper.PlaySound1(MediaControl));
        }

        #region Buttons

        private void btnStart_Click(object sender, System.EventArgs e)
        {
            // TODO: Add event handler implementation here.
            ViewModel.CronoManager.StartStop();
        }

        private void BtnReset_OnClick(object sender, EventArgs e)
        {
            ViewModel.CronoManager.ResetCount();
        }


        #endregion


       
    }
}