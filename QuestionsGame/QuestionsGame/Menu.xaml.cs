using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }
        async void GameClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new lvl1());
        }
        async void StatsClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Stats());
        }
        async void HelpClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Help());
        }
    }
}
