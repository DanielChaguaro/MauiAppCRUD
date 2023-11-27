using MauiAppCRUD.Services;

namespace MauiAppCRUD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ApiService apiService=new ApiService();
            MainPage = new NavigationPage(new ProductoPage(apiService));
        }
    }
}