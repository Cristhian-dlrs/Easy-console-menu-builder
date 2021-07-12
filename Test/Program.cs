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
            var myMenu = new MenuBuilder()
                .NEW_MENU.HEADER("menu principal", "menu")
                    .SetOption("realizar alguna accion", testAction, "demo")
                    .SetOption("realizar alguna accion", testAction, "demo")
                    .SetOption("realizar alguna accion", testAction, "demo")
                    .ADD_SUBMENU.HEADER("primer submenu", "menu")
                        .SetOption("realizar alguna accion", testAction)
                        .ADD_SUBMENU.HEADER("summenu interno", "menu")
                            .SetOption("realizar alguna accion", testAction)
                            .SetOption("realizar alguna accion", testAction)
                            .SetOption("realizar alguna accion", testAction)
                        .END_SUBMENU
                        .SetOption("realizar alguna accion", testAction)
                    .END_SUBMENU
                    .SetOption("realizar alguna accion", testAction)
                    .SetOption("realizar alguna accion", testAction)
                .END_MENU;





            //var element = myMenu.GetElementByID("demo");
            //element.Styles.Color = ConsoleColor.Blue;

            var bacOptions = myMenu.GetAllElementsByID("demo");
            foreach (var item in bacOptions) item.Styles.Hidden = true;

            //var targetOptions = myMenu.GetAllElementsByID("m1");
            //foreach (var item in targetOptions) item.Styles.Color = ConsoleColor.Green;

            //var targetOptions = myMenu.GetAllElementsByID("m1");
            //foreach (var item in targetOptions) item.Styles.Color = ConsoleColor.Green;

            var menuManager = new MenuManager(myMenu);
            menuManager.Execute();
        }
    }
}
