using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_wpf.Model
{
    class Ingredients
    {
        public string Salami { get; set; }
        public string Ham { get; set; }
        public string Kulen { get; set; }
        public string Ketchup { get; set; }
        public string Mayo { get; set; }
        public string Olives { get; set; }
        public string Oregano { get; set; }
        public string Sesame { get; set; }
        public string Cheese { get; set; }
        public string HotPepper { get; set; }

        public static ObservableCollection<string> ingredientList = new ObservableCollection<string>();
    }
}
