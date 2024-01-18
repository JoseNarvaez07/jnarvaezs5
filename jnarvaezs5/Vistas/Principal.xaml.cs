using jnarvaezs5.Models;

namespace jnarvaezs5.Vistas;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnMostrar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersona.ItemsSource = people;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";   
        if (ListaPersona.SelectedItem is Persona selectedPerson)
        {

            string updatedName = txtUpdatedName.Text;

            if (!string.IsNullOrEmpty(updatedName))
            {
                Persona updatedPerson = new Persona
                {
                    Id = selectedPerson.Id, 
                    Name = updatedName
                };

                App.personRepo.UpdatePerson(updatedPerson);
                RefreshCollectionView();
            }
            else
            {
                statusMessage.Text = "Ingrese un nuevo nombre antes de actualizar.";
            }
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para actualizar.";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (ListaPersona.SelectedItem is Persona selectedPerson)
        {
            App.personRepo.DeletePerson(selectedPerson.Id);
            RefreshCollectionView();
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para eliminar.";
        }
    }

    private void RefreshCollectionView()
    {
        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersona.ItemsSource = people;
    }

}