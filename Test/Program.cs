using System;
using System.Threading;
using EasyMenu.src;

namespace Test
{
    class Program
    {
        static void testAction()
        {
            Console.Write("Cual es tu nombre: ");
            var nombre = Console.ReadLine();
            Console.WriteLine($"klk {nombre}");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {
            var Mymenu = new MenuBuilder()
                .TITLE("Demo").SET_ID("Main")
                .SetOption("Opcion", "first", testAction)
                .SetOption("Opcion", "t3", testAction)
                .ADD_SUBMENU
                    .TITLE("Submenu 1").SET_ID("s1")
                    .SetOption("Opcion", "first-layer", testAction)
                    .SetOption("Opcion", "first-layer", testAction)
                    .SetOption("Opcion", "first-layer", testAction)
                    .SetOption("Opcion", "first-layer", testAction)
                    .SetOption("Opcion", "t4", testAction)
                    .SetOption("Opcion", "first-layer", testAction)
                    .SetOption("Opcion", "first-layer", testAction)
                .END_SUBMENU
                .SetOption("Opcion", "first-layer", testAction)
                .SetOption("Opcion", "first-layer", testAction)
                .SetOption("Opcion", "first-layer", testAction)
                .SetOption("Opcion", "target", testAction)
                .END_MENU;

            var element1 = Mymenu.GetElementByID("t3");
            element1.ColorStyle = ConsoleColor.Green;

            var element2 = Mymenu.GetElementByID("t4");
            element2.ColorStyle = ConsoleColor.Yellow;

            var element3 = Mymenu.GetElementByID("target");
            element3.ColorStyle = ConsoleColor.Red;


            Mymenu.Display();
            Thread.Sleep(4000);
            Mymenu.Select(3);
            Console.ReadKey();
        }
    }
}
