using QuestionsGame.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class lvl2 : ContentPage
    {
        string correctAns;
        Questions ques;
        User user;
        //MediaPlayer _player;
        public lvl2()
        {
            getNewQuestion();
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }
        async void MenuClicked(object sender, EventArgs args)
        {
            //DependencyService.Get<IAudio>().PlayMp3File("test.mp3");
            await Navigation.PushAsync(new Menu());
        }
        async void StatsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Stats());
        }
        public void AClicked(object sender, EventArgs args)
        {
            Button events = (Button)sender;
            var ansSelected = events.Text;
            checkAnswer(ansSelected);
        }
        async void BClicked(object sender, EventArgs args)
        {
            Button events = (Button)sender;
            var ansSelected = events.Text;
            checkAnswer(ansSelected);
            //await Navigation.PushAsync(new Stats());
        }
        async void CClicked(object sender, EventArgs args)
        {
            Button events = (Button)sender;
            var ansSelected = events.Text;
            checkAnswer(ansSelected);
            //await Navigation.PushAsync(new Stats());

        }
        async void checkAnswer(string answer)
        {
            if (answer == correctAns)
            {
                DependencyService.Get<IAudio>().PlayCorrect();
                //means it is the first attempt
                if (ques.status == "not answered")
                {
                    user.points = user.points + 3;
                }
                else
                {
                    user.points = user.points + 1;
                }
                ques.status = "right";
                App.database.UpdateStatus(ques);
                App.database.UpdateUser(user);
                //await Navigation.PushAsync(new result());
                var ans = await DisplayAlert("Correct!!!", "Good job, keep going, points: " + user.points,  "Go to Next", "Menu");
                Debug.WriteLine("Answer: " + answer);
                GameContinue(ans);
            }
            else
            {
                DependencyService.Get<IAudio>().PlayWrong();
                ques.status = "wrong";
                App.database.UpdateStatus(ques);
                //await Navigation.PushAsync(new resultwrong());
                var ans = await DisplayAlert("Incorrect", "Keep trying", "Go to Next", "Menu");
                Debug.WriteLine("Answer: " + answer);
                GameContinue(ans);
            }
        }
        async void GameContinue(bool continues)
        {
            if (continues)
            {
                getNewQuestion();
            }
            else
            {
                await Navigation.PushAsync(new Menu());
            }
        }
        async void getNewQuestion()
        {
            //Get question from db and set the binding context
            ques = App.Database.GetQuest();
            if (ques == null)
            {
                DependencyService.Get<IAudio>().PlayEnd();
                await DisplayAlert("End", "Thanks for playing! Please keep an eye on updates and new games!", "Go to Menu");
                GameContinue(false);
                //Navigation.PushAsync(new result());
            }
            else
            {
                user = App.database.GetUser();
                //points = user.points;
                BindingContext = ques;
                correctAns = ques.correctAns;
                //this.Title.Text = Points.ToString();
            }
        }
    }

    
}
