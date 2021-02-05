using Laboratorio0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio0.Helpers;
 

namespace Laboratorio0.Controllers
{
    public class HomeController : Controller
    {

        delegate int CompareCustomers(Customers Cliente1, Customers Cliente2);
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                var nuevoCliente = new Models.Customers
                {
                    Name=collection["Name"],
                    Surname=collection["Surname"],
                    Phone=Convert.ToInt32(collection["Phone"]),
                    Description=collection["Description"]
                };

                Singleton.Instance.ClientList.Add(nuevoCliente);
                return RedirectToAction(nameof(Index));

            }
            catch 
            {
                return View();
             }
        }

        public ActionResult Privacy()
        {
            return View(Singleton.Instance.ClientList);

        }

        public ActionResult ListName()
        {

            CompareCustomers DelegateOrder = new CompareCustomers(Customers.CompareByName);
            Customers.SortCliente(Singleton.Instance.ClientList,DelegateOrder);
            
            return RedirectToAction(nameof(Privacy));

        }

        public ActionResult SurnameList()
        {
            CompareCustomers DelegateOrder = new CompareCustomers(Customers.CompareBySurname);
            Customers.SortCliente(Singleton.Instance.ClientList, DelegateOrder);

            return RedirectToAction(nameof(Privacy));
        }
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
