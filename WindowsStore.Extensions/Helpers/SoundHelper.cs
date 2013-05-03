using System;
using Windows.UI.Xaml.Controls;

namespace Windows.Extensions.Helpers
{
    public class SoundHelper
    {

        #region Playing Sound

        //private async void PlaySoundFile()
        //{
        //    StorageFile element = await OpenFile();
        //    PlaySoundFile(element);
        //}

        //private async Task<StorageFile> OpenFile()
        //{
        //    var openPicker = new FileOpenPicker();

        //    openPicker.SuggestedStartLocation =
        //        PickerLocationId.MusicLibrary;

        //    openPicker.FileTypeFilter.Add(".mp3");
        //    openPicker.FileTypeFilter.Add(".wav");
        //    openPicker.FileTypeFilter.Add(".wma");

        //    return await openPicker.PickSingleFileAsync();
        //}

        public static string CastLocalResource(string uri)
        {
            return "ms-appx://" + uri;
        }

        public static Uri CastLocalResourceToUri(string uri)
        {
            return new Uri(CastLocalResource(uri));
        }

         public  static void PlayLocalSound(MediaElement mediaControl, string uri)
        {
            mediaControl.Source = CastLocalResourceToUri(uri);
            mediaControl.Play();
        }

        public  static void PlaySound1(MediaElement mediaControl)
        {
            PlayLocalSound(mediaControl, "/Assets/Sounds/Sound1.mp3");
        }

        //private async void PlaySoundFile(StorageFile file, MediaElement mediaControl)
        //{
        //    try
        //    {
        //        //var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
        //        //var file = await openPicker.PickSingleFileAsync();
        //        if (file != null)
        //        {
        //            mediaControl.Stop();
        //            IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.Read);
        //            // mediaControl is a MediaElement defined in XAML
        //            mediaControl.SetSource(stream, file.ContentType);

        //            mediaControl.Play();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}

        #endregion


    }
}
