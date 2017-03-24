using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class lvl1 : ContentPage
    {
        string correctAns;
        Questions ques;
        User user;
        public lvl1()
        {
            ques = App.Database.GetQuest();
            user = App.database.GetUser();
            BindingContext = ques;
            correctAns = ques.correctAns;
            InitializeComponent();
        }
        async void MenuClicked(object sender, EventArgs args)
        {
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
                await Navigation.PushAsync(new result());
            }
            else
            {
                ques.status = "wrong";
                App.database.UpdateStatus(ques);
                await Navigation.PushAsync(new resultwrong());
            }
        }
    }

    
}
