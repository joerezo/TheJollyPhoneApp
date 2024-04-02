namespace LearnTutorial
{
    public partial class App : Application
    {
        public static ObservationRepository ObservationRepo { get; private set; }
        public App(ObservationRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            ObservationRepo = repo;//The dependency injection process automatically populates the repo parameter to the constructor.
        }                           //Look inside the App() which usually starts off empty
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
        }
        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}
