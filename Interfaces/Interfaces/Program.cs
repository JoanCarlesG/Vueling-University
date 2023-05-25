using System;
using System.Xml.Linq;

namespace MyFirstProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Interfaz = Define un "contrato" que todas las clases que la heredan deben cumplir.

            //             La interfaz declara "lo que debe tener una clase"
            //             La clase que la hereda declara "cómo lo hace"

            Rabbit rabbit = new Rabbit();
            //Rabbit rabbit = new();
            Hawk hawk = new Hawk();
            Fish fish = new Fish();

            rabbit.Name = "Bugs Bunny";
            rabbit.Flee();
            hawk.Hunt();
            fish.Flee();
            fish.Hunt();

            Console.ReadKey();
        }
        




        //Interfaces
        // Palabra clave "interface" seguida del nombre, empezando con "I" por convención
        interface IPrey
        {
            //Se declaran los métodos pero sin cuerpo.
            void Flee();

            //Se declaran las propiedades.
            string Name
            {
                get;
                set;
            }
        }
        interface IPredator
        {
            void Hunt();
        }





        //Classes
        //La herencia se declara con ":" y el nombre de la interfaz
        class Rabbit : IPrey
        {
            //Se declaran los métodos indicando qué hacen exactamente.
            public void Flee()
            {
                Console.WriteLine("{0} runs away!",this.Name);
            }

            private string _name; //atributo
            public string Name  //propiedad modificable
            {
                get => _name;
                set => _name = value;
            }
        }
        class Hawk : IPredator
        {
            public void Hunt()
            {
                Console.WriteLine("The hawk is searching for food!");
            }
        }

        // Herencia múltiple de clases no permitida, de interfaces sí
        class Fish : IPrey, IPredator
        {
            public void Flee()
            {
                Console.WriteLine("The fish swims away!");
            }

            private string _name;
            public string Name
            {
                get => _name;
                set => _name = value;
            }
            public void Hunt()
            {
                Console.WriteLine("The fish is searching for smaller fish!");
            }
        }
    }
}
