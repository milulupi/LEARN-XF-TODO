using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LEARNXFTODO.Views
{
    public partial class TodoListPage : ContentPage
    {
       // ListView listView;

        async void OnListItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            //throw new NotImplementedException();
            await Navigation.PushAsync(new Views.TodoItemPage
            {
                BindingContext = (Model.TodoItem)e.SelectedItem
            });
        }

        async void OnItemAdded(object sender, System.EventArgs e)
        {
            //throw new NotImplementedException();
            await Navigation.PushAsync(new Views.TodoItemPage
                {
                    BindingContext = new Model.TodoItem()
                }
            );
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            ((App)App.Current).ResumeAtTodoId = -1;
            listView.ItemsSource = await App.Database.GetItemsAsync();
        }
        public TodoListPage()
        {

            InitializeComponent();
        }
    }
}
