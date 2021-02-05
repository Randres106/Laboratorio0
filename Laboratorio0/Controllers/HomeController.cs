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
  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            try
            {
                var newCustomer = new Models.Customers
                {
                    Name=collection["Name"],
                    Surname=collection["Surname"],
                    Phone=Convert.ToInt32(collection["Phone"]),
                    Description=collection["Description"]
                };

                Singleton.Instance.ClientList.Add(newCustomer);
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
            List<Customers> NameList = new List<Customers>();
            for (int i = 0; i < Singleton.Instance.ClientList.Count; i++)
            {
                for (int j = 0; j < Singleton.Instance.ClientList.Count-1; j++)
                {
                    if (Singleton.Instance.ClientList[j].Name.CompareTo(Singleton.Instance.ClientList[j + 1].Name) > 0)
                    {
                        NameList.Add(Singleton.Instance.ClientList[j]);
                        Singleton.Instance.ClientList[j] = Singleton.Instance.ClientList[j + 1];
                        Singleton.Instance.ClientList[j + 1] = NameList[0];
                    }
                    NameList.Clear();
                }
            }
            
            return RedirectToAction(nameof(Privacy));

        }

        public ActionResult SurnameList()
        {
            List<Customers> SurnameList = new List<Customers>();
            for (int i = 0; i < Singleton.Instance.ClientList.Count; i++)
            {
                for (int j = 0; j < Singleton.Instance.ClientList.Count - 1; j++)
                {
                    if (Singleton.Instance.ClientList[j].Surname.CompareTo(Singleton.Instance.ClientList[j + 1].Surname) > 0)
                    {
                        SurnameList.Add(Singleton.Instance.ClientList[j]);
                        Singleton.Instance.ClientList[j] = Singleton.Instance.ClientList[j + 1];
                        Singleton.Instance.ClientList[j + 1] = SurnameList[0];
                    }
                    SurnameList.Clear();
                }
            }
           
            return RedirectToAction(nameof(Privacy));
        }
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
