
using CommunityToolkit.Maui.Core;
using MauiAppCRUD.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiAppCRUD;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
	public NuevoProductoPage()
	{
		InitializeComponent();
		
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if(_producto != null )
        {
            Nombre.Text = _producto.Nombre;
            Cantidad.Text = _producto.cantidad.ToString();
            Descripcion.Text = _producto.Descripcion;
        }
    }
    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        if( _producto != null )
        {
            _producto.Nombre=Nombre.Text;
            _producto.Descripcion=Descripcion.Text;
            _producto.cantidad=Int32.Parse(Cantidad.Text);
        }
        else
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
            
        }
        await Navigation.PopAsync();

    }
}