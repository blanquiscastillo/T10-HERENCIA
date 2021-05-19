using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10_HERENCIA
{
    
    class Program
    {
        class Cuenta
        {
            private string titular;
            private double cantidad;
           
            public string Titular
            {
                get { return titular; } 
                set { titular = value; }
            }

            public double Cantidad
            {
                get { return cantidad; }
                set { cantidad = value; }
            }


            public Cuenta(string titular, double cantidad = 0)
            {
                Titular = titular;
                Cantidad = cantidad;
            }

            public void ingresar(double cantidad)
            {
                if (cantidad >= 0)
                {
                    Cantidad = Cantidad + cantidad;
                }                
            }

            public void retirar(double cantidad)
            {                
                Cantidad = Cantidad - cantidad;
                if (Cantidad < 0)
                {
                    Cantidad = 0;
                }                
            }
        }// de clase cuenta


        

        static void Main(string[] args)
        {
            
            Console.WriteLine("Ejercicio No. 1\n");
            Cuenta c = new Cuenta("Juan");
            c.ingresar(10);
            Console.WriteLine("Se ingresaron {0} La cantidad es: {1}",10,c.Cantidad);
            c.ingresar(-15);
            Console.WriteLine("Se ingresaron {0} La cantidad es: {1}", -15, c.Cantidad);
            c.retirar(5.5);
            Console.WriteLine("Se retiraron {0} La cantidad es: {1}", 5.5, c.Cantidad);
            c.retirar(10);
            Console.WriteLine("Se retiraron {0} La cantidad es: {1}", 10, c.Cantidad);
            Console.WriteLine("\nPresione cualquier tecla para salir");
            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}
