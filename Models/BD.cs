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
        string sql = "SELECT * FROM Productos WHERE Productos.FK_marca = @pIdE";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            lista = db.Query<Productos>(sql, new { pIdE = FK_marca }).ToList();
        }
        return lista;
    }

    public static Jugador VerInfoJugador(int IdJugador)
    {
        Jugador J = null;
        string sql = "SELECT * FROM Jugadores WHERE Jugadores.IdJugador = @pIdJJ";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            J = db.QueryFirstOrDefault<Jugador>(sql, new { pIdJJ = IdJugador });
        }
        return J;
    }

    public static Equipo VerInfoEquipo(int IdEquipo)
    {
        Equipo E = null;
        string sql = "SELECT * FROM Equipos WHERE Equipos.IdEquipo = @pIdEE";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            E = db.QueryFirstOrDefault<Equipo>(sql, new { pIdEE = IdEquipo });
        }
        return E;
    }


}
