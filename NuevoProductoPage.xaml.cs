
using CommunityToolkit.Maui.Core;
using MauiAppCRUD.Models;
using MauiAppCRUD.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiAppCRUD;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
    private readonly ApiService _Apiservice;
	public NuevoProductoPage(ApiService apiservice)
	{
		InitializeComponent();
        _Apiservice = apiservice;

		
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
            await _Apiservice.PutProducto(_producto.IdProducto,_producto);
        }
        else
        {
            Producto producto = new Producto
            {
                IdProducto = 0,
                Nombre = Nombre.Text,
                Descripcion = Descripcion.Text,
                cantidad = Int32.Parse(Cantidad.Text),
            };
            await _Apiservice.PostProducto(producto);
   
            //await Navigation.PushAsync(new NuevoProductoPage());
            
        }
        await Navigation.PopAsync();

    }
}