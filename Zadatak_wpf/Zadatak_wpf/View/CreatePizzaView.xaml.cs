using System.Windows;
using Zadatak_wpf.ViewModel;

namespace Zadatak_wpf.View
{
    /// <summary>
    /// Interaction logic for CreatePizzaView.xaml
    /// </summary>
    public partial class CreatePizzaView : Window
    {
        public CreatePizzaView()
        {
            InitializeComponent();
            this.DataContext = new CreatePizzaViewModel(this);
        }
    }
}
