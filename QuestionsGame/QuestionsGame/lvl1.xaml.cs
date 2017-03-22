﻿using System;
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
        public lvl1()
        {
            Questions ques = App.Database.GetQuest();
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
                await Navigation.PushAsync(new result());
            }
            else
            {
                await Navigation.PushAsync(new resultwrong());
            }
        }
    }

    
}
