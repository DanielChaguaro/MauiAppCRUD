using MauiAppCRUD.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCRUD.Services
{
    public class ApiService
    {
        private static string _baseUrl = "http://10.0.2.2:5038/";
        public ApiService()
        { 

        }
        public async Task<string> DeleteProducto(int IdProducto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.DeleteAsync($"api/Producto/{IdProducto}");

            if (response.IsSuccessStatusCode)
            {
                return "Producto eliminado correctamente";
            }
            else
            {
                // Manejar el error aquí si es necesario
                throw new HttpRequestException($"Error al eliminar el producto. Código de estado: {response.StatusCode}");
            }
        }

        public Task<Producto> GetProducto(int IdProducto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetProductos()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var response = await httpClient.GetAsync("api/Producto/");
            var json_response = await response.Content.ReadAsStringAsync();
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
            return productos;

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("api/Producto", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Producto createdProducto = JsonConvert.DeserializeObject<Producto>(jsonResponse);
                return createdProducto;
            }
            else
            {
                // Manejar el error aquí si es necesario
                throw new HttpRequestException($"Error al crear el producto. Código de estado: {response.StatusCode}");
            }
        }

        public async Task<Producto> PutProducto(int IdProducto, Producto producto)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"api/Producto/{IdProducto}", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Producto updatedProducto = JsonConvert.DeserializeObject<Producto>(jsonResponse);
                return updatedProducto;
            }
            else
            {
                // Manejar el error aquí si es necesario
                throw new HttpRequestException($"Error al actualizar el producto. Código de estado: {response.StatusCode}");
            }
        }
    }
}
