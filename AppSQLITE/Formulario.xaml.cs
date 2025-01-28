using AppSQLITE.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        private int selectedUserId;  // Variable para almacenar el Id del usuario seleccionado
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

            var allUsers = UserRepository.Instance.GetUsers();

            userlist.ItemsSource = allUsers;

            mensaje.Text = UserRepository.Instance.estadoMensaje;
        }

        private void userlist_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                // Show the modal overlay
                modalOverlay.IsVisible = true;

                // Populate the fields with the selected item details if needed
                var selectedItem = e.SelectedItem as User;
                selectedUserId = selectedItem.Id;
                editUserName.Text = selectedItem.UserName;
                editEmail.Text = selectedItem.Email;
                editPassword.Text = selectedItem.Password;

                // Deselect the item
                userlist.SelectedItem = null;
            }
        }

        private void btnmodificar_Clicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Id = selectedUserId,  // Asume que guardas el Id del usuario seleccionado en una variable
                UserName = editUserName.Text,
                Email = editEmail.Text,
                Password = editPassword.Text
            };

            var result = UserRepository.Instance.UpdateUser(user);

            mensaje.Text = UserRepository.Instance.estadoMensaje;

            modalOverlay.IsVisible = false;
            btnlistar_Clicked(null, null);
        }

        private void btneliminar_Clicked(object sender, EventArgs e)
        {
            var result = UserRepository.Instance.DeleteUser(selectedUserId); // Asume que guardas el Id del usuario seleccionado en una variable

            mensaje.Text = UserRepository.Instance.estadoMensaje;

            modalOverlay.IsVisible = false;
            btnlistar_Clicked(null, null);
        }
    }
}
