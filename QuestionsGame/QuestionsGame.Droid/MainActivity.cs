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
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            _player = MediaPlayer.Create(this, Resource.Raw.test);
            _player.Start();
        }
        public override void OnBackPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            if (true) return;
            
            //base.OnBackPressed();
        }
    }
}

