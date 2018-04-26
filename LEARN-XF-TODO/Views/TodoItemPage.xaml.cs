using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LEARNXFTODO.Views
{
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, System.EventArgs e)
        {
            var todoItem = (Model.TodoItem)BindingContext;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();

        }
        async void OnDeleteClicked(object sender, System.EventArgs e)
        {
            // throw new NotImplementedException();
            var todoItem = (Model.TodoItem)BindingContext;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked(object sender, System.EventArgs e)
        {
            // throw new NotImplementedException();
            await Navigation.PopAsync();
        }
        void OnSpeakClicked(object sender, System.EventArgs e)
        {
            // throw new NotImplementedException();
            var todoItem = (Model.TodoItem)BindingContext;
            DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);

        }
    }
}
