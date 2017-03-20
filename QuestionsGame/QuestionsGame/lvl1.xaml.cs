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
        public lvl1()
        {
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
        async void AClicked(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new Stats());
        }
        async void BClicked(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new Stats());
        }
        async void CClicked(object sender, EventArgs args)
        {
            //await Navigation.PushAsync(new Stats());
        }
    }

    
}
