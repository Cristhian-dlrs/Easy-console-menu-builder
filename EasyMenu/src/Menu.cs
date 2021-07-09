using System;
using System.Collections.Generic;

namespace EasyMenu.src
{
    public class Menu 
    {
        public string Title { get; set; }     
        public string Id { get; set; }
        public Action Action { get; set; } = () => { };
        public int Index { private get; set; }
        public ConsoleColor ColorStyle { private get; set; } = ConsoleColor.White;   
        private readonly List<Menu> _childs = new List<Menu>();

        public Menu() { }

        public Menu(string title)
        {
            Title = title;
        }

        public Menu(string title, string id, Action action)
        {
            Title = title;
            Id = id;
            Action = action;
        }

        public void AppendChild(Menu element)
        {
            element.Index = _childs.Count + 1;
            _childs.Add(element);
        }

        public void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ColorStyle;
            Console.WriteLine($"//***********    {Title.ToUpper()}    ***********\\\r\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var element in _childs) element.Print();           
        }

        public void Print()
        {
            Console.ForegroundColor = ColorStyle;
            Console.WriteLine($"[{Index}]-{Title}\r\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Select(int index)
        {
            var option = _childs[--index];
            option.Display();
            option.Action();
            //this.Display();
        }

        public Menu GetElementByID(string id)
        {
            if (Id == id)
                return this;
            else 
                foreach (var child in _childs)
                {
                    var result = child.GetElementByID(id);
                    if (result != null)
                        return result;
                }       
            return null;
        }
    }
}
