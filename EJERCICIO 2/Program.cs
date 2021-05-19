using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T10_EJERCICIO2
{
    class Program
    {

        class Persona
        {
            private string _nombre;
            private int _edad;
            private string _DNI;
            private char _sexo;
            private int _peso;
            private double _altura;

            public string Nombre { get => _nombre; set => _nombre = value; }
            public int Edad { get => _edad; set => _edad = value; }
            public string DNI { get => _DNI; set => _DNI = value; }
            public char Sexo { get => _sexo; set => _sexo = value; }
            public int Peso { get => _peso; set => _peso = value; }
            public double Altura { get => _altura; set => _altura = value; }



            //Constructor por defecto
            public Persona()
            {                
                Nombre = "";
                Edad = 0;
                DNI = GeneraDNI();
                Sexo = 'H';
                Peso = 0;
                Altura = 0;
            }

            //Construtor con nombre, edad y sexo
            public Persona(string nombre, int edad, char sexo)
            {
                Nombre = nombre;
                Edad = edad;
                DNI = GeneraDNI();
                Sexo = ComprobarSexo(sexo);
                Peso = 0;
                Altura = 0;
            }


            //Constructor por todos los parametros
            public Persona(string nombre, int edad, char sexo, int peso, double altura)
            {
                Nombre = nombre;
                Edad = edad;
                DNI = GeneraDNI();
                Sexo = ComprobarSexo(sexo);
                Peso = peso;
                Altura = altura;
            }

            // Obtiene la letra correspondiente al numero de DNI
            private char LetraControl(string dni)
            {
                char letra = ' ';
                int valor = ( Convert.ToInt32(dni) % 23);

                char[] Equivalencia = new char[23];
                
                Equivalencia[0] = 'T';
                Equivalencia[1] = 'R';
                Equivalencia[2] = 'W';
                Equivalencia[3] = 'A';
                Equivalencia[4] = 'G';
                Equivalencia[5] = 'M';
                Equivalencia[6] = 'Y';
                Equivalencia[7] = 'F';
                Equivalencia[8] = 'P';
                Equivalencia[9] = 'D';
                Equivalencia[10] = 'X';
                Equivalencia[11] = 'B';
                Equivalencia[12] = 'N';
                Equivalencia[13] = 'J';
                Equivalencia[14] = 'Z';
                Equivalencia[15] = 'S';
                Equivalencia[16] = 'Q';
                Equivalencia[17] = 'V';
                Equivalencia[18] = 'H';
                Equivalencia[19] = 'L';
                Equivalencia[20] = 'C';
                Equivalencia[21] = 'K';
                Equivalencia[22] = 'E';

                letra = Equivalencia[valor];

                return letra;
            }

            private char ComprobarSexo(char sexo)
            {
                string compara;
                compara = Convert.ToString(sexo).ToUpper();                
                if (compara == "H" || compara == "M")
                {
                    sexo = Convert.ToChar(compara);
                }else
                {
                    sexo = 'H';
                }

                return sexo;
            }

            private string GeneraDNI()
            {

                string _dni;
                char letra;                                         

                //Genero un numero aleatorio de 8 digitos

                Random r = new Random();
                string inicial = "0";
                string final = "9";

                for (int i = 0; i < 7; i++)
                {
                    inicial = inicial + "0";
                    final = final + "9";
                }

                _dni = Convert.ToString(r.Next(Convert.ToInt32(inicial), Convert.ToInt32(final)));

                letra = LetraControl(_dni);
                _dni = _dni + Convert.ToString(letra);
                return _dni;
            }


            public int CalcularIMC()
            {
                double imc;

                if (this.Peso > 0 )
                {
                    imc = this.Peso / (Math.Pow(Altura, 2));
                }
                else
                {
                    Console.WriteLine("No se puede calcular IMC porque el peso y la altura es 0");
                    imc = 0;
                    return -1;
                }

                if (imc < 20)
                {
                    Console.WriteLine("Esta por debajo de su peso ideal con IMC: "  + imc);
                    return -1;
                }
                else
                {
                    if ((imc >= 20 && imc <= 25))
                    {
                        Console.WriteLine("Esta en su peso ideal con IMC: " + imc);
                        return 0;
                    }
                    else
                    {
                        Console.WriteLine("Esta con sobrepeso con IMC: " + imc);
                        return 1;
                    }
                }

            } // de Calcular IMC

            public bool EsMayorDeEdad()
            {
                if (this.Edad >= 18)
                {
                    Console.WriteLine("Es mayor de edad");
                    return true;
                }
                else
                {
                    Console.WriteLine("Es menor de edad");
                    return false;
                }
            }// de EsMayorDeEdad

            public void MostrarDatos()
            {
                Console.WriteLine("DNI: " + DNI);
                Console.WriteLine("Nombre: " + Nombre);
                Console.WriteLine("Edad: " + Edad);
                Console.WriteLine("Sexo: " + Sexo);
                Console.WriteLine("Peso: " + Peso);
                Console.WriteLine("Altura: " + Altura);                
            }



        }// de clase Persona

        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Ejercicio No. 2\n");
            Console.WriteLine("\nPERSONA 1");
            Console.WriteLine("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Edad: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Sexo (H = Hombre, M = Mujer): ");
            char sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Ingrese Peso ( Kilogramos ): ");
            int peso = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese altura ( metros ): ");
            double altura;
            bool convierte = double.TryParse(Console.ReadLine(), out altura);            
            Persona p = new Persona(nombre, edad, sexo, peso, altura);
            Console.WriteLine("\n-----------------");
            p.MostrarDatos();
            int imc = p.CalcularIMC();
            p.EsMayorDeEdad();

            Console.WriteLine("\nPERSONA 2");
            Console.WriteLine("Ingrese nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Edad: ");
            edad = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese Sexo (H = Hombre, M = Mujer): ");
            sexo = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("Ingrese Peso ( Kilogramos ): ");
            peso = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese altura ( metros ): ");
            convierte = double.TryParse(Console.ReadLine(), out altura);
            Persona p2 = new Persona(nombre, edad, sexo);
            Console.WriteLine("\n-----------------");
            p2.MostrarDatos();
            imc = p2.CalcularIMC();
            p2.EsMayorDeEdad();

            Console.WriteLine("\nPERSONA 3");
            Persona p3 = new Persona();
            p3.Nombre = "Nombre desde SET";
            p3.Edad = 35;
            p3.Sexo = 'M';
            p3.Peso = 65;
            p3.Altura = 1.65;
            Console.WriteLine("\n-----------------");
            p3.MostrarDatos();
            imc = p3.CalcularIMC();
            p3.EsMayorDeEdad();

            Console.WriteLine("\nIngrese cualquier tecla para continuar");
            Console.ReadLine();
            

        }
    }
}
