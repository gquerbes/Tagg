using System;
using System.Collections.Generic;
using System.Text;

namespace Tagg.Models
{
    public enum MenuItemType
    {
        Home,
        Map
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
