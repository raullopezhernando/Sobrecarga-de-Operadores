using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sobrecarga_de_Operadores
{
    class Program
    {
        static void Main(string[] args)
        {

            Circulo circulo = new Circulo();

            Rectangulo rectangulo = new Rectangulo();

            rectangulo = circulo;

            // Ejemplos de resultados con sobrecargas definidas anteriormente

            // Sobrecarga de Operador1

            var resultado = circulo + rectangulo;

            //Sobrecarga de Operdor2
            var resultado2 = circulo + 20;

            // Sobrecarga de Operador3
            var resultado3 = 20 + circulo;

            // Sobrecarga de Operador 4
            circulo += circulo;

            //circulo ++;

            //Conversion explicita e implicita

            // Cuando se debe escoger entre una y otra ? Muy sencillo cuando la conversion no conlleva perdida de informacion
            // la conversion sera implicita mientras. Cuando la conversion lleve una perdida de informacion la conversion sera 
            // explicita

            HacerAlgo((int)3.5);


            Console.WriteLine(rectangulo.Area);

            rectangulo = circulo;

            Console.WriteLine(rectangulo.Area);

            Console.ReadLine();


        }


        //static void HacerAlgo(double valor) 
        //{
        
        
        //}

        static void HacerAlgo(int valor)
        {


        }

    }


    // Todas las clases que herede de figura. Inmediatamanet cuando son construidas se inicie su metodo CalcularArea
    // Cada Figura por lo tanto implementara una forma diferente de calcular su Area
    public abstract class Figura
    {
        public double Area { get; set; }

        public abstract void CalcularArea();


        public Figura()
        {
            CalcularArea();
        }

        // Con la sobrecarga del operador mas cogeriamos dos figuras y sumariamos sus Areas

        // lhs = left hand side

        // rhs = right hand side



        // SOBRECARGANDO EL OPERADOR +

        public static double operator +(Figura lhs, Figura rhs) => lhs.Area + rhs.Area;

        public static double operator +(Figura lhs, int rhs) => lhs.Area + rhs;

        public static double operator +(int lhs, Figura rhs) => lhs + rhs.Area;


        //public static Circulo operator ++(Circulo circulo) 
        //{
        //    circulo.Area++;
        //    return circulo;
        //}





    }
    public class Circulo : Figura
    {
        public override void CalcularArea()
        {
            Area = 50;
        }

        // Aqui podemos ver como en este modificador de operador se procede a coger el valor del area de circulo sumandose
        // para crear un Circulo con una Area que sea la suma de los dos circulos anteriores
        public static Circulo operator +(Circulo lhs, Circulo rhs) => new Circulo { Area = lhs.Area + rhs.Area };

        public static implicit operator Rectangulo (Circulo circulo) => new Rectangulo { Area = circulo.Area};
    }

    public class Rectangulo : Figura
    {
        public override void CalcularArea()
        {
            Area = 100;
        }
    }


}
