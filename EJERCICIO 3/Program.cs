using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10_EJERCICIO3
{
    class Program
    {
        class Password
        {
            private int _longitud;
            private string _contraseña;

            public int Longitud { get => _longitud; set => _longitud = value; }
            public string Contraseña { get => _contraseña; set => _contraseña = value; }

            //Constructor por defecto
            public Password()
            {
                this.Longitud = 8;
                this.Contraseña = "";
            }

            //Constructor con longitud
            public Password(int longitud)
            {

                //0 al 9 = 48-57
                //A a la Z = 65 al 90 
                //a a la Z = 97 al 122
                this.Longitud = longitud;

                var seed = Environment.TickCount;
                Random r = new Random(seed);

                int numero;
                string pass = "";

                for (int i = 0; i < longitud; i++)
                {
                    numero = r.Next(48, 122);
                    char c = (char)numero;
                    pass = pass + c;

                }
                this.Contraseña = pass;
                
            }

            public bool EsFuerte(string p)
            {
                bool fuerte = false;
                int minusculas = 0;
                int mayusculas = 0;
                int numeros = 0;

                
                System.Text.StringBuilder sb = new System.Text.StringBuilder(p);

                for (int j = 0; j < sb.Length; j++)
                {

                    Console.Write(sb[j]);
                    if (System.Char.IsLower(sb[j]) == true)
                    {
                        minusculas += 1;
                    }
                    else {
                        if (System.Char.IsUpper(sb[j]) == true)
                        {
                            mayusculas += 1;
                        }
                        else
                        {
                            int res;
                            int.TryParse(Convert.ToString(sb[j]), out res);
                            //validar que sea numero
                            if (res==0)
                            {
                                numeros += 1;
                            }
                                
                        }

                    }
                }
                //Para que sea furte
                //Verificamos que tenga mas de dos mayusculas, mas de 1 minuscula y mas de 5 numeros;
                if ((mayusculas > 2) && (minusculas > 1) && (numeros > 5))
                {
                    fuerte = true;
                }

                //Console.WriteLine("\nMayusculas " + mayusculas);
                //Console.WriteLine("Minusculas " + minusculas);
                //Console.WriteLine("Numeros " + numeros);

                
                //Recorremos un arreglo verificando cada posicion 
                return fuerte;
            }


            public void Mostrardatos()
            {
                Console.WriteLine("LONGITUD: " + Longitud);
                Console.WriteLine("CONTRASEÑA: " + Contraseña);

            }
        }//Password

        static void Main(string[] args)
        {
            Console.WriteLine("EJERCICIO NO. 3");

            Console.WriteLine("Ingrese la cantidad de numeros del arreglo:");
            int tamaño = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la longitud del password");
            int longitud = Convert.ToInt32(Console.ReadLine());




            //Password[] arreglo;
            Password[] arreglo = new Password[tamaño];
            bool[] booleanos = new bool[tamaño];

            
            for (int i = 0; i < tamaño; i++)
            {
                arreglo[i] = new Password(longitud);
                if (arreglo[i].EsFuerte(arreglo[i].Contraseña))
                {
                    booleanos[i] = true;
                }
                else
                {
                    booleanos[i] = false;
                }
                
                Console.Write(arreglo[i].Contraseña);
                Console.Write("  ");
                Console.Write(booleanos[i]);
                Console.Write("\n");

            }
            


            /*
            Password p = new Password(10);
            Console.WriteLine("Contraseña: " + p.Contraseña);
            if (p.EsFuerte(p.Contraseña)) {
                Console.WriteLine("Contraseña Fuerte");
            }else
            {
                Console.WriteLine("Contraseña No es Fuerte (Debe tener mas de dos mayusculas, mas de 1 minuscula y mas de 5 numeros)");
            }
            */

            Console.WriteLine("\nIngrese cualquier tecla para continuar");
            Console.ReadLine();
            


        }
    }
}
