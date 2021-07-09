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

        public MenuBuilder ADD_SUBMENU => new MenuBuilder(this);

        public MenuBuilder END_SUBMENU => ResolveSubMenu();

        private MenuBuilder ResolveSubMenu()
        {
            _parent.Root.AppendChild(this.Root);
            return _parent;
        }

        public Menu END_MENU => Root;

        public MenuBuilder TITLE(string title)
        {
            Root.Title = title;
            return this;
        }

        public MenuBuilder SET_ID(string id)
        {
            Root.Id = id;
            return this;
        }

        public MenuBuilder SetOption(string title, string id, Action action)
        {
            var option = new Menu(title, id, action);
            Root.AppendChild(option);
            return this;
        }

        public static implicit operator Menu(MenuBuilder builder)
        {
            return builder.Root;
        }     
    }
}
