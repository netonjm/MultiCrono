using System;
using System.Windows.Controls;

namespace Windows.Extensions.Helpers
{
    public class SoundHelper
    {

        #region Playing Sound

      
        public static void PlayLocalSound(MediaElement mediaControl, string uri)
        {
            mediaControl.Source = new Uri(uri, UriKind.Relative);
            mediaControl.Play();
        }

        public  static void PlaySound1(MediaElement mediaControl)
        {
            PlayLocalSound(mediaControl, @"/Assets/Sounds/Sound1.mp3");
        }

        #endregion


    }
}
