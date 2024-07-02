using acabreraS5.Models;

namespace acabreraS5.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.addNewPerson(txtNombre.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";

        List<Persona> person = App.personRepo.GetAllPerson();
        listarPersona.ItemsSource = person;
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void ListarPersonas()
    {
        List<Persona> personas = App.personRepo.GetAllPerson();
        listarPersona.ItemsSource = personas;
        statusMessage.Text = App.personRepo.StatusMessage;
    }
    private void OnDeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button?.BindingContext as Persona;
        if (person != null)
        {
            App.personRepo.DeletePerson(person.Id);
            statusMessage.Text = App.personRepo.StatusMessage;
            ListarPersonas();
        }
    }

    private async void OnEditClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button?.BindingContext as Persona;
        if (person != null)
        {
            string newName = await DisplayPromptAsync("Editar Persona", "Ingrese el nuevo nombre", initialValue: person.Name);
            if (!string.IsNullOrEmpty(newName))
            {
                person.Name = newName;
                App.personRepo.UpdatePerson(person);
                statusMessage.Text = App.personRepo.StatusMessage;
                ListarPersonas();
            }
        }
    }
}