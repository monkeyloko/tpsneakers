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
   static Usuario Usuari = new Usuario();
   // 
   
   
    [HttpPost]
    public IActionResult CheckUsuario(Usuario U)
    {
        Usuari = U;
        Usuari = BD.UsuarioDadoNombre(U.Nombre);
        if (Usuari == null)
        {
            return RedirectToAction("GuardarUsuario", new { str = U.Nombre });
        }
        else
        {
            return RedirectToAction("Marcas"); 
        }
    }
    public IActionResult Marcas() 
    {
        ViewBag.ListaM = BD.ListarMarcas();
        ViewBag.Usuario = Usuari;
        return View();
    }

    public IActionResult GuardarUsuario(string str)
    {
        Usuario us = new Usuario(str);
        BD.AgregarUsuario(us);
        Usuari = BD.UsuarioDadoNombre(us.Nombre);
        return RedirectToAction("Marcas");  
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
    public IActionResult EliminarUsuarioxProducto(int IDPRODUCTO)
    {
        BD.EliminarUsuarioxProducto(IDPRODUCTO, Usuari.ID_USUARIO);
        return RedirectToAction("Carrito");
    }
    
    public IActionResult Carrito(){
        ViewBag.Carrito = BD.ListarProductosDeCarrito(Usuari.ID_USUARIO);
        ViewBag.Usuario = Usuari;
        return View();
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