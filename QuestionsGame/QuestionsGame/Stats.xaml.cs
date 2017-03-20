using QuestionsGame.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace QuestionsGame
{
    public partial class Stats : ContentPage
    {
        public Stats()
        {
            BindingContext = new TodoItem();
            InitializeComponent();
            var nameEntry = new Entry();
            nameEntry.SetBinding(Entry.TextProperty, "Name");
        }
        async void MenuClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Menu());
        }
        async void HelpClicked(object sender, EventArgs args)
        {
            var todoItem = (TodoItem)BindingContext;
            //todoItem.Name = "Test";
            //await App.Database.GetItemsAsync();
            await App.Database.SaveItemAsync(todoItem);
            //await App.Database.DeleteItemAsync(todoItem);
            //await Navigation.PushAsync(new Help());
        }
    }
    
}
