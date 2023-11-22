using MauiAppCRUD.Models;

namespace MauiAppCRUD;

public partial class DetailsPage : ContentPage
{
    public Producto _producto;
	public DetailsPage()
	{
		InitializeComponent();
        
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto=BindingContext as Producto;
        Nombre.Text = _producto.Nombre;
        Cantidad.Text = _producto.cantidad.ToString();
        Descripcion.Text = _producto.Descripcion;
    }

    private async void OnClickRegresarProducto(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    private async void ClickEliminarProducto(object sender, EventArgs e)
    {
        Utils.Utils.ListaProductos.Remove(_producto);
        await Navigation.PopAsync();
    }
    private async void ClickEditarProducto(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevoProductoPage()
        {
            BindingContext = _producto,
        });
    }
}