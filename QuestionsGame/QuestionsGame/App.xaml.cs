using QuestionsGame.database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QuestionsGame
{
    //public interface IMediaPlayer
    //{
    //    void PlayMusic();
    //}
    public partial class App : Application
    {
        public static string whereType ="r1";
        //public static int pointsTotal = 0;
        public App()
        {
            InitializeComponent();
            try
            {
                if (App.Database.CheckDBExists() <1)
                {
                    App.Database.FillDatabase();
                }
                /*openConnection = DependencyService.Get<ISQLite>().GetConnection();
                database.FillDatabase(openConnection);*/
            }
            catch (Exception e)
            {

            }
            /*int check = FirstTimeDB();
            if (check < 1)
            {
                
            }*/
            // The root page of your application
            var nav= new NavigationPage(new Menu());
            //var nav = new NavigationPage(new lvl2());
            MainPage = nav;
        }

        public static TodoItemDatabase database;

        public static TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("QGame.db3"));
                }
                return database;
            }
        }
        //public int FirstTimeDB()
        //{
        //    try
        //    {
        //        //SQLiteConnection database = DependencyService.Get<ISQLite>().GetConnection();
        //        List<Questions> question = new List<Questions>();
        //        //question = (from i in databaseConn.Table<Questions>() select i).ToList();
        //        return question.Count;
        //    }
        //    catch (Exception e)
        //    {
        //        var exception = e;
        //        return 0;
        //    }
        //}


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        //public static IMediaPlayer MediaPlayer { get; private set; }

        //public static void Init(IMediaPlayer mediaPlayer)
        //{
        //    App.MediaPlayer = mediaPlayer;
        //}
    }
}
