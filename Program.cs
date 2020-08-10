using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ConsoleApp1
{

    //Delegado booleano para la comparacion TRUE/FALSE
    public delegate bool Comparacion(int elemento);

    class Program
    {
        public class Estudiante
        {
            public String Nombre { get; set; }
            public int Nota { get; set; }
        }

        public class Curso
        {
            private Estudiante[] vec = new Estudiante[5];

            public void Cargar(int pos, Estudiante est)
            {
                vec[pos] = est;
            }

            public void ImprimirTodo()
            {
                foreach (var elemento in vec)
                    Console.WriteLine("Nombre: {0} Nota: {1}", elemento.Nombre, elemento.Nota);
            }

            public void ImprimirSi(Comparacion compara)
            {
                foreach (var elemento in vec)
                    if (compara(elemento.Nota))
                        Console.WriteLine("Nombre: {0} Nota: {1}", elemento.Nombre, elemento.Nota);
            }
            //----------------------------------------------------------

            public double promedio()
            {
                var v= vec.Average(x=> x.Nota);
                
                return v;
                
            }

            public void convert()
            {
                var alterno = vec.OrderByDescending(x => x.Nota);
                foreach (var num in alterno)
                    Console.WriteLine(num.Nota);
            }
        }

        static void Main(string [] args)
        {
            

            Curso obj = new Curso();

            obj.Cargar(0, new Estudiante {Nombre="Gabriel", Nota=8 });
            obj.Cargar(1, new Estudiante { Nombre = "Esthefania", Nota = 5 });
            obj.Cargar(2, new Estudiante { Nombre = "Cristina", Nota = 10 });
            obj.Cargar(3, new Estudiante { Nombre = "Sebas", Nota = 7 });
            obj.Cargar(4, new Estudiante { Nombre = "Chuck", Nota = 6 });


            //----------------------------------------------------------------------


            Console.WriteLine("LISTADOS!! <3");
            // ¿Cómo imprimir a los estudiantes cuya nota es superior al promedio ?
            // Double promedio = 
            Double aux = obj.promedio();
            Console.WriteLine("  ");
            Console.WriteLine("Las notas superior a {0} son:", aux);
            obj.ImprimirSi(nota=> nota>aux);
            Console.WriteLine("  ");
            //j.ImprimirSi(nota=> );

            //¿Cómo imprimir a los estudiantes cuya nota esta entre 7 y 10?
            Console.WriteLine("  ");
            Console.WriteLine("Nota entre 7 y 10");
            obj.ImprimirSi(nota => nota >= 7 && nota <= 10);
            Console.WriteLine("  ");
            //¿Cómo imprimir a los estudiantes cuya nota es menor a 7 ?
            Console.WriteLine("  ");
            Console.WriteLine("Notas menor a 7");
            obj.ImprimirSi(nota => (nota < 7));
            Console.WriteLine("  ");
            //¿Cómo imprimir a los estudiantes ordenados descendentemente por sus calificaciones? 
            // (Para esta respuesta no use la función ImprimirSi).
            Console.WriteLine("  ");
            Console.WriteLine("Notas descentemente segun calficacion>: ");
            obj.convert();
            Console.WriteLine("  ");


            //Plantee dos preguntas adicionales y agregue la respuesta a través del uso del delegado.
            //notas perfectas es decir que sean igual a 10
            Console.WriteLine("  ");
            Console.WriteLine("Notas perfectas: ");
            obj.ImprimirSi(nota => (nota == 10));
            Console.WriteLine("  ");
            //todas las notas
            Console.WriteLine("  ");
            Console.WriteLine("Todas las notas");
            obj.ImprimirSi(nota => true);
            Console.WriteLine("  ");
            Console.ReadLine();
        }
    }
}
