using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppSQLITE.Model;

namespace AppSQLITE
{
    public partial class App : Application
    {
        public App(String filename)
        {
            InitializeComponent();

            UserRepository.Inicializador(filename);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
