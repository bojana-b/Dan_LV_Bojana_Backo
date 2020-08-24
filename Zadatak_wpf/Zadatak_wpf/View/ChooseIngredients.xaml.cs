using System.Windows;
using Zadatak_wpf.ViewModel;

namespace Zadatak_wpf.View
{
    /// <summary>
    /// Interaction logic for ChooseIngredients.xaml
    /// </summary>
    public partial class ChooseIngredients : Window
    {
        public ChooseIngredients()
        {
            InitializeComponent();
            this.DataContext = new ChooseIngredientsViewModel(this);
        }
    }
}
