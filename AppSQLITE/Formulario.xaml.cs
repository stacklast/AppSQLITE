using AppSQLITE.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        private User UserSelected { get; set; }
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

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedUser = e.Item as User;
            if (selectedUser != null)
            {
                UserSelected = selectedUser;
                txtUpdateUsername.Text = selectedUser.UserName;
                txtUpdateEmail.Text = selectedUser.Email;
                txtUpdatePassword.Text = selectedUser.Password;
                updateForm.IsVisible = true;
            }
        }

        private async void btnupdate_Clicked(object sender, EventArgs e)
        {
            if (UserSelected != null)
            {
                UserSelected.UserName = txtUpdateUsername.Text;
                UserSelected.Email = txtUpdateEmail.Text;
                UserSelected.Password = txtUpdatePassword.Text;

                var result = UserRepository.Instance.UpdateUser(UserSelected);
                if (result > 0)
                {
                    updateForm.IsVisible = false;
                    mensaje.Text = UserRepository.Instance.estadoMensaje;
                }
                else
                {
                    mensaje.Text = UserRepository.Instance.estadoMensaje;
                }
            }
        }

        private async void btndelete_Clicked(object sender, EventArgs e)
        {
            if (UserSelected != null)
            {
                // Delete user from the database
                var result = UserRepository.Instance.DeleteUser(UserSelected.Id); // Ensure you have the Id property in User class
                if (result > 0)
                {
                    updateForm.IsVisible = false;
                    mensaje.Text = UserRepository.Instance.estadoMensaje;
                }
                else
                {
                    mensaje.Text = UserRepository.Instance.estadoMensaje;
                }
            }
        }
    }
}