using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Threading;
using CommunityToolkit.Maui.Core;

namespace MauiAppCRUD;

public partial class ProductoPage : ContentPage
{
	public ProductoPage()
	{
		InitializeComponent();
    }

    private async void OnClickedNuevoProducto(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click Nuevo Producto", ToastDuration.Short, 14);

        await toast.Show();
    }

    
}