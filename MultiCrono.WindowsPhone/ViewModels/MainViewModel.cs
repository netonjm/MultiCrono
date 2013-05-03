using System;
using System.ComponentModel;
using MultiCrono.Common;
using Windows.Extensions.Handlers;
using MultiCrono.ViewModels;
using Windows.Extensions.Helpers;


namespace MultiCrono.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        public event EventHandler PlayRequested;

        #region Properties

        public CronoManager CronoManager { get; set; }

        public ButtonViewModel Btn1Up { get; set; }
        public ButtonViewModel Btn2Up { get; set; }
        public ButtonViewModel Btn3Up { get; set; }
        public ButtonViewModel Btn1Down { get; set; }
        public ButtonViewModel Btn2Down { get; set; }
        public ButtonViewModel Btn3Down { get; set; }

        public ButtonViewModel BtnReset { get; set; }
        public ButtonViewModel BtnStart { get; set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        private string _txtCrono;
        public string TxtCrono
        {
            get { return _txtCrono; }
            set
            {
                _txtCrono = value;
                NotifyPropertyChanged("TxtCrono");
            }
        }
        
        #endregion
      
        #region Init
        
        public MainViewModel()
        {
            InitializeButtons();
            InitializeCronografo();
        }

        public void InitializeButtons()
        {
            Btn1Up = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Hours, true));
            Btn2Up = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Minutes, true));
            Btn3Up = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Seconds, true));
            Btn1Down = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Hours, false));
            Btn2Down = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Minutes, false));
            Btn3Down = new ButtonViewModel(() => CronoManager.AddTime(CronoManager.TimeType.Seconds, false));

            BtnReset = new ButtonViewModel(() => CronoManager.ResetCount());
            BtnStart = new ButtonViewModel(() => CronoManager.StartStop());
        }

        public void InitializeCronografo()
        {
            CronoManager = new CronoManager();
            CronoManager.playSound += CronografoOnPlaySound;
            CronoManager.cronoText += (text) => { TxtCrono = text; };
            CronoManager.start += () => CronografoOnStart(true);
            CronoManager.stop += () => CronografoOnStart(false);
            CronoManager.runAsync += (priority, callback) => CommonDispatcher.BeginInvoke(callback);
            CronoManager.notification += cronografo_notification;
        }

        #endregion

        #region CronoManager Events

        private void CronografoOnStart(bool isStarted)
        {

            BtnStart.Description = (isStarted) ? "Stop" : "Start";
            BtnReset.IsEnabled =
            Btn1Down.IsEnabled =
            Btn1Up.IsEnabled =
            Btn2Down.IsEnabled =
            Btn2Up.IsEnabled =
            Btn3Down.IsEnabled =
            Btn3Up.IsEnabled = !isStarted;
        }

        private void CronografoOnPlaySound()
        {
            if (PlayRequested != null)
                CommonDispatcher.BeginInvoke(() => PlayRequested(null, null));
        }

        void cronografo_notification()
        {
            ToastHelper.SendToast("Ha finalizado el temporizador");
        }

    
   
        #endregion

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            BtnStart.Description = "Start";
            CronoManager.SetCronoText();
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


       
    }
}