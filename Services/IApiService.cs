using MauiAppCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppCRUD.Services
{
    internal interface IApiService
    {
        Task<List<Producto>> GetProductos();
        Task<Producto> GetProducto(int IdProducto);
        Task<Producto> PostProducto(Producto producto);

        Task<Producto> PutProducto(int IdProducto, Producto producto);
        Task<string> DeleteProducto(int IdProdcuto);
    }
}
