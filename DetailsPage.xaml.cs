using MauiAppCRUD.Models;

namespace MauiAppCRUD;

public partial class DetailsPage : ContentPage
{
    
	public DetailsPage(Producto producto)
	{
		InitializeComponent();
        Nombre.Text = producto.Nombre;
        Cantidad.Text = producto.cantidad.ToString();
        Descripcion.Text = producto.Descripcion;
    }
    private async void OnClickRegresarProducto(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}