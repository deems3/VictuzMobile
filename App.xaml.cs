using VictuzMobile.Models;
using VictuzMobile.Views;

namespace VictuzMobile
{
    public partial class App : Application
    {
        private static DatabaseContext _databaseContext;

        public static DatabaseContext DatabaseContext =>
            _databaseContext ??= new DatabaseContext();

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainTabbedPage());
        }
    }
}