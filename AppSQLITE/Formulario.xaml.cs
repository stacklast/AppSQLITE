using System;
using AppSQLITE.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void btncrear_Clicked(object sender, EventArgs e)
        {
            mensaje.Text = string.Empty;
            UserRepository.Instance.AddUser(
                txtusername.Text,
                txtemail.Text,
                txtpassword.Text);
            mensaje.Text = UserRepository.Instance.estadoMensaje;
        }

        private void btnlistar_Clicked(object sender, EventArgs e)
        {
            lblTitulo.IsVisible = true;
            frDatos.IsVisible = true;

            var allUsers = UserRepository.Instance.getUsers();

            userlist.ItemsSource = allUsers;

            mensaje.Text = UserRepository.Instance.estadoMensaje;
        }
    }
}