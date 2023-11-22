using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Collections.ObjectModel;
using MauiAppCRUD.Models;
using MauiAppCRUD.Utils;
using MauiAppCRUD.Services;

namespace MauiAppCRUD;

public partial class ProductoPage : ContentPage
{
    ObservableCollection<Producto> products;
    ApiService _ApiService;
    public ProductoPage()
    {
        InitializeComponent();
       
        products = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
        listaProductos.ItemsSource = products;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        var productos = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
        listaProductos.ItemsSource = productos;
    }
    private async void OnClickNuevoProducto(object sender, EventArgs e)
    {

        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
        await Navigation.PushAsync(new NuevoProductoPage());
    }

    private async void OnClickShowDetail(object sender, SelectedItemChangedEventArgs e)
    {
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetailsPage()
        {
            BindingContext= producto,
        });
    }
}