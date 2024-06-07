using System;
using Xamarin.Forms;
using Tarea03.Model;
using Tarea03.ViewModel;
using System.Threading.Tasks;

namespace Tarea03
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await LoadPersons();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                Person person = new Person()
                {
                    Nombre = txtName.Text,
                    Apellido = txtName.Text,
                };

                // Add New Person
                await App.SQLiteDb.SaveItemAsync(person);
                txtName.Text = string.Empty;
                await DisplayAlert("Success", "Person added Successfully", "OK");
                // Get All Persons
                await LoadPersons();
            }
            else
            {
                await DisplayAlert("Required", "Please Enter name!", "OK");
            }
        }

        private async void BtnRead_Clicked(object sender, EventArgs e)
        {
            await LoadPersons();
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una persona en la lista
            if (lstPersons.SelectedItem != null)
            {
                // Obtiene la persona seleccionada
                var selectedPerson = lstPersons.SelectedItem as Person;

                // Actualiza el nombre de la persona
                selectedPerson.Nombre = txtName.Text;

                // Actualiza la persona en la base de datos
                await App.SQLiteDb.SaveItemAsync(selectedPerson);

                // Actualiza la lista de personas en la vista
                await LoadPersons();

                // Muestra un mensaje de éxito
                await DisplayAlert("Success", "Person Updated Successfully", "OK");

                // Limpia los campos de entrada
                txtPersonId.Text = string.Empty;
                txtName.Text = string.Empty;
            }
            else
            {
                // Si no se seleccionó ninguna persona, muestra un mensaje de error
                await DisplayAlert("Error", "Please select a person to update", "OK");
            }
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            // Verifica si se ha seleccionado una persona en la lista
            if (lstPersons.SelectedItem != null)
            {
                // Pregunta al usuario si está seguro de eliminar la persona
                bool answer = await DisplayAlert("Confirmation", "Are you sure you want to delete this person?", "Yes", "No");

                // Si el usuario confirma la eliminación
                if (answer)
                {
                    // Obtiene la persona seleccionada
                    var selectedPerson = lstPersons.SelectedItem as Person;

                    // Elimina la persona de la base de datos
                    await App.SQLiteDb.DeleteItemAsync(selectedPerson);

                    // Actualiza la lista de personas en la vista
                    await LoadPersons();

                    // Muestra un mensaje de éxito
                    await DisplayAlert("Success", "Person Deleted Successfully", "OK");
                }
            }
            else
            {
                // Si no se seleccionó ninguna persona, muestra un mensaje de error
                await DisplayAlert("Error", "Please select a person to delete", "OK");
            }
        }

        private async Task LoadPersons()
        {
            var personList = await App.SQLiteDb.GetItemsAsync();
            if (personList != null)
            {
                lstPersons.ItemsSource = personList;
            }
        }
    }
}
