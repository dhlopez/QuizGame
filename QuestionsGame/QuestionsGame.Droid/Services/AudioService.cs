using System;
using Xamarin.Forms;
using QuestionsGame.Droid;
using Android.Media;
using QuestionsGame.Services;

[assembly: Dependency(typeof(AudioService))]

namespace QuestionsGame.Droid
{
    public class AudioService : IAudio
    {
        public AudioService() { }

        private MediaPlayer _mediaPlayer;

        public bool PlayMp3File(string fileName)
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.test);
            _mediaPlayer.Start();

            return true;
        }
        public bool PlayCorrect()
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.cheering);
            _mediaPlayer.Start();

            return true;
        }
        public bool PlayWrong()
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.train);
            _mediaPlayer.Start();

            return true;
        }
        public bool PlayEnd()
        {
            _mediaPlayer = MediaPlayer.Create(global::Android.App.Application.Context, Resource.Raw.tada);
            _mediaPlayer.Start();

            return true;
        }

    }
}