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
            //TODO: fix
            while(true)
            {
                var current = _contexts.Peek();
                if (_contexts.Count == 1 || current.ChildsCount > 0)
                    current.Display();      
                var option = int.Parse(Console.ReadLine());
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
                //else
                //{
                //    current.Select(option);
                //}
            }
        }
    }
}
