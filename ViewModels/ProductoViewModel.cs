
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProductosApp_Q32026.Models;
using ProductosApp_Q32026.Services;

namespace ProductosApp_Q32026.ViewModels;

public partial class ProductoViewModel : ObservableObject
{
    private readonly ProductoService _service;

    [ObservableProperty]
    public string codigo;

    [ObservableProperty]
    public string descripcion;

    [ObservableProperty]
    public double precio;

    [ObservableProperty]
    private Producto productoSeleccionado;

    public ObservableCollection<Producto> Productos { get; } = new();

    public ProductoViewModel(ProductoService Service) 
    {
        _service = Service;
    }

    [RelayCommand]
    private async Task CargarProductos()
    {
        List<Producto> lista = await _service.GetProductosAsync();
        Productos.Clear();

        foreach (Producto p in lista)
        {
            Productos.Add(p);
        }
    }

    [RelayCommand]
    private async Task Guardar()
    {
        if (string.IsNullOrWhiteSpace(Codigo)) return;

        Producto producto = ProductoSeleccionado ?? new Producto();
        producto.Codigo = Codigo;
        producto.Descripcion = Descripcion;
        producto.Precio = Precio;

        await _service.GuardarProductosAsync(producto);
        await CargarProductos();
    }

    [RelayCommand]
    private async Task Eliminar(Producto producto)
    {
        await _service.EliminarProductoAsync(producto);
        await CargarProductos();
    }
}