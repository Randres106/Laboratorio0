using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laboratorio0.Helpers;



namespace Laboratorio0.Models
{
    public class Customers
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Description { get; set; }



        public static int CompareByName(Customers Cliente1, Customers Cliente2)
        {
            return String.Compare(Cliente1.Name, Cliente2.Name);
        }

        public static int CompareBySurname(Customers Cliente1, Customers Cliente2)
        {
            return String.Compare(Cliente1.Surname, Cliente2.Surname);
        }

        public static void SortCliente(List<Customers> ListClient, Delegate Condicion) 
        {
            for (int i = 0; i < ListClient.Count; i++)
            {
                for (int j = 0; j < ListClient.Count - 1; j++)
                {
                    if (Convert.ToInt32(Condicion.DynamicInvoke(ListClient[j],ListClient[j+1])) > 0)
                    {
                        Customers Nuevo = ListClient[j];
                        ListClient[j] = ListClient[j + 1];
                        ListClient[j + 1] = Nuevo;
                    }
                }
            }
            Singleton.Instance.ClientList = ListClient;
        }
    }
}
