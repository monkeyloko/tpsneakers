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
        ViewBag.ListaM = BD.ListarMarcas()
        return View();
    }

    public IActionResult VerDetalleMarca(int ID_MARCA){

        ViewBag.Marca = BD.VerInfoMarca(int ID_MARCA);
        return View();
        
    }

    public IActionResult VerDetalleProducto(int ID_Producto){
        ViewBag.Producto = BD.VerInfoProducto(ID_Producto);
        return View();
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
