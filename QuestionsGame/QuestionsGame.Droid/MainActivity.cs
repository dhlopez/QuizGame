using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace QuestionsGame.Droid
{
    [Activity(Label = "World Quiz", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {

        MediaPlayer _player;
        //public void PlayMusic()
        //{

        //    _player = MediaPlayer.Create(this, Resource.Raw.test);

        //    var playButton = FindViewById<Button>(Resource.Id.play_pause);

        //    playButton.Click += delegate {
        //        _player.Start();
        //    };
        //    _player.Start();
        //}
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            //_player = MediaPlayer.Create(this, Resource.Raw.test);
            //_player.Start();
        }
        public override void OnBackPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            if (true) return;
            
            //base.OnBackPressed();
        }
    }
    //public class AndroidUserPreferences : IMediaPlayer
    //{
    //    MediaPlayer _player;
    //    public void PlayMusic()
    //    {
            
    //        _player = MediaPlayer.Create(this, Resource.Raw.test);
    //        //_player.Start();
    //    }
    //}

}

