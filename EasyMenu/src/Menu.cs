using System;
using System.Collections.Generic;

namespace EasyMenu.src
{
    public class Menu
    {
        //TODO: Refactor

        public string Title { get; set; }
        public string Id { get; set; }
        public Action Action { get; set; } = () => { };
        public int Index { private get; set; }
        public Styles Styles { get; set; } = new Styles();
        private readonly List<Menu> _childs = new List<Menu>();
        public int ChildsCount => _childs.Count;

        public Menu() { }

        public Menu(string title)
        {
            Title = title;
        }

        public Menu(string title, Action action, string id)
        {
            Title = title;
            Action = action;
            Id = id;
        }

        public Menu(string title, Action action)
        {
            Title = title;
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
            Console.ForegroundColor = Styles.ColorHeader;
            Console.WriteLine($"//***********    {Title.ToUpper()}    ***********\\\\\r\n\n");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var element in _childs) element.Print();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n>> ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Print()
        {
            Console.ForegroundColor = Styles.Color;
            Console.WriteLine($"[{ Index }]-{ CapitalizrFirst(Title) }\r\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private string CapitalizrFirst(string str)
        {
            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();
            else
                return char.ToUpper(str[0]) + str.Substring(1);
        }

        public Menu Select(int index)
        {
            var option = _childs[--index];
            option.Display();
            option.Action();
            return option;
        }

        public Menu GetElementByID(string id)
        {
            if (Id == id)
                return this;
            else 
                foreach (var child in _childs)
                {
                    var result = child.GetElementByID(id);
                    if (result != null) return result;
                }       
            return null;
        }

        public IEnumerable<Menu> GetAllElementsByID(string id)
        {
            var result = new List<Menu>();
            if (Id == id)
                result.Add(this);
            foreach (var child in _childs)
            {
                var elements = child.GetAllElementsByID(id);
                if (elements != null) result.AddRange(elements);
            }
            return result;
        }
    }
}
