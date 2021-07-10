using System;
using System.Collections.Generic;

namespace EasyMenu.src
{
    public class MenuManager
    {
        private Stack<Menu> _contexts = new Stack<Menu>();

        public MenuManager(Menu menu)
        {
            _contexts.Push(menu);
        }

        public void Execute()
        {
            //TODO: Improve
            while (true)
            {
                var current = _contexts.Peek();
                if (_contexts.Count == 1 || current.ChildsCount > 0)
                    current.Display();
                var valid = int.TryParse(Console.ReadLine(), out int option);

                if (option <= current.ChildsCount && valid)
                {
                    if (option == current.ChildsCount && _contexts.Count == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Ha salido de la aplicacion...");
                        break;
                    }
                    else if (option == current.ChildsCount)
                    {
                        _contexts.Pop();
                    }
                    else if (current.Select(option).ChildsCount > 0)
                    {
                        _contexts.Push(current.Select(option));
                    }
                }
            }
        }
    }
}
