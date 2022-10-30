﻿using System.Diagnostics;
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
        ViewBag.ListaM = BD.ListarMarcas();
        return View();
    }
    public IActionResult CheckUsuario(Usuario U){
        U = BD.UsuarioDadoNombre(U.Nombre);
        if(U == null){
            return RedirectToAction("GuardarUsuario", new { u = U }); //no se is esto va a funcionar
        }
        else{
            return RedirectToAction("Marcas", new { usua = U }); //no se is esto va a funcionar
        }
    }
    public IActionResult Marcas(Usuario usua) //DEberiamos ver si hay una forma de pasar el usuario sin hacerle universe hopping por todos los parametros de las funbciones
    {
        ViewBag.ListaM = BD.ListarMarcas();
        ViewBag.Usuario = usua;
        return View();
    }
    public IActionResult GuardarUsuario(Usuario u)
    {
        BD.AgregarUsuario(u);
        return RedirectToAction("CheckUsuario", new { U = u });  //no se is esto va a funcionar
        //Lo mando a checkusuario porque no se si mandalo directamente a marca el usuario va a tener el id
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