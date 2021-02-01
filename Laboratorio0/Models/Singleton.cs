using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio0.Models
{
    public class Singleton
    {
        private static Singleton instance = null;
        protected Singleton () {}
        public static Singleton Instance 
        {
            get {
                if (instance==null)  
                instance = new Singleton();
                return instance;
            }
            
        }
    }
}
