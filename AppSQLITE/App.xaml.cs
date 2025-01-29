using AppSQLITE.Model;
using System;
using Xamarin.Forms;

namespace AppSQLITE
{
    public partial class App : Application
    {
        public App(String filename)
        {
            InitializeComponent();

            UserRepository.Inicializador(filename);

            MainPage = new Formulario();
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
