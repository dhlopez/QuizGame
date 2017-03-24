using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class resultwrong : ContentPage
    {
        public resultwrong()
        {
            InitializeComponent();
        }
        async void Back(object sender, EventArgs args)
        {
            lvl1 newLevel = new lvl1();
            await Navigation.PopAsync();
        }
    }

}
