using Laboratorio0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
 

namespace Laboratorio0.Controllers
{
    public class HomeController : Controller
    {
  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                var nuevoCliente = new Models.Cliente
                {
                    Nombre=collection["Name"],
                    Apellido=collection["Apelli"],
                    Telefono=Convert.ToInt32(collection["Tel"]),
                    Descripcion=collection["Desc"]
                };
                return View();

            }
            catch 
            {
                return View();
             }
        }

        public ActionResult Privacy()
        {
            return View();
        }
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
