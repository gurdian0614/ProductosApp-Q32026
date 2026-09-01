using ProductosApp_Q32026.Models;
using SQLite;

namespace ProductosApp_Q32026.Services;

public class ProductoService
{
    private SQLiteAsyncConnection _db;

    private async Task Init()
    {
        if (_db is not null) return;
        // Creamos ruta para el archivo db3
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "productos.db3");
        // Creamos una nueva conexion
        _db = new SQLiteAsyncConnection(dbPath);
        // Creamos la tabla
        await _db.CreateTableAsync<Producto>();
    }

    public async Task<List<Producto>> GetProductosAsync()
    {
        await Init();
        return await _db.Table<Producto>().ToListAsync();
    }

    public async Task<int> GuardarProductosAsync(Producto Producto)
    {
        await Init();

        if (Producto.Id != 0)
        {
            return await _db.UpdateAsync(Producto);
        }

        return await _db.InsertAsync(Producto);
    }

    public async Task<int> EliminarProductoAsync(Producto Producto)
    {
        await Init();
        return await _db.DeleteAsync(Producto);
    }
}