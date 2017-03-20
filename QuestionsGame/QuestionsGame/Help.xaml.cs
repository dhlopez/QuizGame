using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class Help : ContentPage
    {
        public Help()
        {
            InitializeComponent();
        }
        async void MenuClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Menu());
        }
        //async void HelpClicked(object sender, EventArgs args)
        //{
        //    await Navigation.PushAsync(new Help());
        //}
    }

    
}
