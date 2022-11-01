namespace TPSNEAKERS.Models;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
public class BD
{

    private static string _connectionString = @"Server=DESKTOP-O63256U\SQLEXPRESS;DataBase=SNEAKERS;Trusted_Connection=True";

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
    public static Usuario UsuarioDadoNombre(string Nombre)
    {
        /*int res;
        string sql = "SELECT Count(*) FROM Usuario WHERE Usuario.Nombre = @pname";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            res = db.QueryFirstOrDefault<int>(sql, new { pname = Nombre });
        }
        return res;
        */
        Usuario us = null;
        string sql = "SELECT * FROM Usuario WHERE Usuario.Nombre = @pname";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            us = db.QueryFirstOrDefault<Usuario>(sql, new { pname = Nombre });
        }
        return us;
    }

    public static void EliminarMarca(int ID_MARCA)
    {
        string sql = "DELETE FROM Marca WHERE ID_MARCA = @pId";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pId = ID_MARCA });
        }
    }
    public static void EliminarUsuarioxProducto(int ID_PRODUCTO, int ID_USUARIO)
    {
        string sql = "DELETE FROM UsuarioxProducto WHERE ID_PRODUCTO = @pIdP AND ID_USUARIO = @pIdU";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdP = ID_PRODUCTO, pIdU = ID_USUARIO });
        }
    }

    public static void AgregarMarca(Marca J)
    {
        string sql = "INSERT INTO Marca VALUES (@pNombre, @pFoto,  @pFundadores, @pFechaFundacion )";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = J.Nombre, pFechaFundacion = J.FechaFundacion, pFoto = J.Foto, pFundadores = J.Fundadores });
        }
    }
    public static void AgregarProducto(Productos E)
    {
        string sql = "INSERT INTO Productos VALUES (@pNombre, @pFoto, @pFK_marca)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = E.Nombre, pFoto = E.Foto, pFK_marca = E.FK_marca });
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
    public static void AgregarUsuarioxProducto(int ID_USUARIO, int ID_Producto)
    {
        string sql = "INSERT INTO UsuarioxProducto VALUES (@pID_USUARIO, @pID_PRODUCTO)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pID_USUARIO = ID_USUARIO, pID_PRODUCTO = ID_Producto });
        }
    }
    public static List<Productos> ListarProductosDeCarrito(int ID_USUARIO)
    {
        List<Productos> lista = new List<Productos>();
        string sql = "SELECT Productos.ID_Producto, Productos.Nombre, Productos.Foto, Productos.FK_marca, Productos.Precio FROM Usuario INNER JOIN UsuarioxProducto on Usuario.ID_USUARIO = UsuarioxProducto.ID_USUARIO INNER JOIN Productos ON UsuarioxProducto.ID_PRODUCTO = Productos.ID_PRODUCTO WHERE Usuario.ID_USUARIO = @pID_U";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            lista = db.Query<Productos>(sql, new { pID_U = ID_USUARIO }).ToList();
        }
        return lista;
    }

    public static Productos VerInfoProducto(int ID_Producto)
    {
        Productos P = null;
        string sql = "SELECT * FROM Productos WHERE Productos.ID_Producto = @pID_Producto";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            P = db.QueryFirstOrDefault<Productos>(sql, new { pID_Producto = ID_Producto });
        }
        return P;
    }

    public static Marca VerInfoMarca(int ID_MARCA)
    {
        Marca M = null;
        string sql = "SELECT * FROM Marca WHERE Marca.ID_MARCA = @pID_MARCA";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            M = db.QueryFirstOrDefault<Marca>(sql, new { pID_MARCA = ID_MARCA });
        }
        return M;
    }
    public static void AgregarUsuario(Usuario u)
    {
        string sql = "INSERT INTO Usuario VALUES (@pNombre)";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pNombre = u.Nombre });
        }
    }
}