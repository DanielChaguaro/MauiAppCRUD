
using CommunityToolkit.Maui.Core;
using MauiAppCRUD.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiAppCRUD;

public partial class NuevoProductoPage : ContentPage
{
	public NuevoProductoPage()
	{
		InitializeComponent();
		
	}
    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        int id = Utils.Utils.ListaProductos.Count + 1;
        Utils.Utils.ListaProductos.Add(new Producto
        {
            IdProducto = id,
            Nombre = Nombre.Text,
            Descripcion = Descripcion.Text,
            cantidad = Int32.Parse(Cantidad.Text),
        }
        );
        //await Navigation.PushAsync(new NuevoProductoPage());
        await Navigation.PopAsync();
    }
}