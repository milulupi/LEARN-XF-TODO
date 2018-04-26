using Xamarin.Forms;

namespace LEARNXFTODO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new LEARN_XF_TODOPage();

            Resources = new ResourceDictionary();
            Resources.Add("primaryGreen", Color.FromHex("91CA47"));
            Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

            var NavPage = new NavigationPage(new Views.TodoListPage());
            NavPage.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            NavPage.BarTextColor = Color.White;

            MainPage = NavPage;
        }

        static Data.TodoItemDatabase database;
        public static Data.TodoItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new Data.TodoItemDatabase(
                        DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3")
                    );
                }
                return database;
            }

        }

        public int ResumeAtTodoId
        {
            get;
            set;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
