using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPSNEAKERS.Models;

namespace TPSNEAKERS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult CheckUsuario(Usuario U)
    {
        if (BD.UsuarioDadoNombre(U.Nombre) == null)
        {
            return RedirectToAction("GuardarUsuario", new { u = U });
        }
        else
        {
            U = BD.UsuarioDadoNombre(U.Nombre);
            return RedirectToAction("Marcas", new { usua = U }); //no se si esto va a funcionar
        }
    }
    public IActionResult Marcas(Usuario usua) //Deberiamos ver si hay una forma de pasar el usuario sin hacerle universe hopping por todos los parametros de las funbciones
    {
        ViewBag.ListaM = BD.ListarMarcas();
        ViewBag.Usuario = usua;
        return View();
    }
    [HttpPost]
    public IActionResult GuardarUsuario(Usuario u)
    {
        BD.AgregarUsuario(u);
        u = BD.UsuarioDadoNombre(u.Nombre);
        return RedirectToAction("Marcas", new { U = u });  //no se is esto va a funcionar
    }

    public IActionResult VerDetalleMarca(int ID_MARCA)
    {
        ViewBag.Marca = BD.VerInfoMarca(ID_MARCA);
        ViewBag.ListaP = BD.ListarProductos(ID_MARCA);
        return View();
    }

    public IActionResult VerDetalleProducto(int ID_Producto)
    {
        ViewBag.Producto = BD.VerInfoProducto(ID_Producto);
        return View();
    }
    public IActionResult AgregarProducto(int FK_marca)
    {
        ViewBag.FK_marca = FK_marca;
        return View();
    }
    [HttpPost]
    public IActionResult GuardarProducto(Productos p)
    {
        BD.AgregarProducto(p);
        return RedirectToAction("VerDetalleMarca", new { ID_MARCA = p.FK_marca });
    }
    public IActionResult AgregarMarca()
    {
        return View();
    }
    [HttpPost]
    public IActionResult GuardarMarca(Marca m)
    {
        Console.WriteLine(m.FechaFundacion);
        BD.AgregarMarca(m);
        return RedirectToAction("Marcas");

    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}