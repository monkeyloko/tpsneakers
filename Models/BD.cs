namespace TPSNEAKERS.Models;

using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
public class BD
{

    private static string _connectionString = @"Server=DESKTOP-O63256U\SQLEXPRESS;DataBase=Qatar2022;Trusted_Connection=True";

    public static List<Marca> ListarMarcas()
    {
        List<Marca> lista = new List<Marca>();
        string sql = "SELECT * FROM Marca";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            lista = db.Query<Marca>(sql).ToList();
        }
        return lista;
    }

    public static void EliminarMarca(int ID_MARCA)
    {
        string sql = "DELETE FROM Marca WHERE ID_MARCA = @pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pId = ID_MARCA });
        }
    }

    public static void AgregarMarca(Marca J)
    {
        string sql = "INSERT INTO Marca VALUES (@pNombre, @pFechaFundacion, @pFoto, @pFundadores)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new {pNombre = J.Nombre, pFechaFundacion = J.FechaFundacion, pFoto = J.Foto, pFundadores = J.Fundadores});
        }
    }
    public static void AgregarProducto(Productos E)
    {
        string sql = "INSERT INTO Productos VALUES (@pNombre, @pFoto, @pFK_marca)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = E.Nombre, pFoto = E.Foto, pFK_marca = E.FK_marca});
        }
    }
   
    public static List<Productos> ListarProductos(int FK_marca)
    {
        List<Productos> lista = new List<Productos>();
        string sql = "SELECT * FROM Productos WHERE Productos.FK_marca = @pFK_marca";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            lista = db.Query<Productos>(sql, new { pFK_marca = FK_marca }).ToList();
        }
        return lista;
    }

    public static Jugador VerInfoProducto(int ID_Producto)
    {
        Jugador P = null;
        string sql = "SELECT * FROM Productos WHERE Producto.ID_Producto = @pID_Producto";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            P = db.QueryFirstOrDefault<Producto>(sql, new { pID_Producto = ID_Producto});
        }
        return P;
    }

    public static Equipo VerInfoMarca(int ID_MARCA)
    {
        Equipo M = null;
        string sql = "SELECT * FROM Marca WHERE Marca.ID_MARCA = @pID_MARCA";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            M = db.QueryFirstOrDefault<Marca>(sql, new { pID_MARCA = ID_MARCA});
        }
        return M;
    }


}
