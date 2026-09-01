using SQLite;

namespace ProductosApp_Q32026.Models;

public class Producto {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull]
    public string Codigo { get; set; }

    public string Descripcion { get; set;}

    public double Precio { get; set; }
}