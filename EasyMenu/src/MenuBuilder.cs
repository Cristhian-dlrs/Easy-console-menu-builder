using System;
namespace EasyMenu.src
{
    public class MenuBuilder
    {
        public Menu Root { get; }

        private readonly MenuBuilder _parent;

        public MenuBuilder() => Root = new Menu();

        private MenuBuilder(MenuBuilder parent)
            : this ()
        {
            _parent = parent;
        }

        public MenuBuilder NEW_MENU => this;

        public MenuBuilder ADD_SUBMENU => new MenuBuilder(this);

        public MenuBuilder END_SUBMENU
        {
            get
            {
                SetOption("Atrás", () => { }, "atras");
                _parent.Root.AppendChild(this.Root);
                return _parent;
            }
        }

        public Menu END_MENU
        {
            get
            {
                SetOption("Salir", () => { }, "salir");
                return Root;
            }
        }

        public MenuBuilder HEADER(string title)
        {
            Root.Title = title;
            return this;
        }

        public MenuBuilder HEADER(string title, string id)
        {
            Root.Title = title;
            Root.Id = id;
            return this;
        }

        public MenuBuilder SetOption(string title, Action action, string id)
        {
            var option = new Menu(title, action, id);
            Root.AppendChild(option);
            return this;
        }

        public MenuBuilder SetOption(string title, Action action)
        {
            var option = new Menu(title, action);
            Root.AppendChild(option);
            return this;
        }

        public static implicit operator Menu(MenuBuilder builder)
        {
            return builder.Root;
        }     
    }
}
