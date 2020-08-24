using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_wpf.Commands;
using Zadatak_wpf.Model;
using Zadatak_wpf.View;

namespace Zadatak_wpf.ViewModel
{
    class ChooseIngredientsViewModel : ViewModelBase
    {
        ChooseIngredients ingredientsView;


        public ChooseIngredientsViewModel(ChooseIngredients ingredientsViewOpen)
        {
            ingredientsView = ingredientsViewOpen;
            IngredientList = Ingredients.ingredientList;
        }


        #region Properties
        private ObservableCollection<string> ingredientList;
        public ObservableCollection<string> IngredientList
        {
            get
            {
                return ingredientList;
            }
            set
            {
                ingredientList = value;
                OnPropertyChanged("IngredientList");
            }
        }

        private bool salami;
        public bool Salami
        {
            get 
            { 
                return salami; 
            }
            set
            {
                salami = value;
                OnPropertyChanged("Salami");
            }
        }

        private bool ham;
        public bool Ham
        {
            get
            {
                return ham;
            }
            set
            {
                ham = value;
                OnPropertyChanged("Ham");
            }
        }

        private bool kulen;
        public bool Kulen
        {
            get 
            { 
                return kulen; 
            }
            set
            {
                kulen = value;
                OnPropertyChanged("Kulen");
            }
        }

        private bool ketchup;
        public bool Ketchup
        {
            get
            {
                return ketchup;
            }
            set
            {
                ketchup = value;
                OnPropertyChanged("Ketchup");
            }
        }

        private bool mayo;
        public bool Mayo
        {
            get 
            { 
                return mayo; 
            }
            set
            {
                mayo = value;
                OnPropertyChanged("Mayo");
            }
        }

        private bool olives;
        public bool Olives
        {
            get 
            { 
                return olives; 
            }
            set
            {
                olives = value;
                OnPropertyChanged("Olives");
            }
        }

        private bool oregano;
        public bool Oregano
        {
            get 
            { 
                return oregano; 
            }
            set
            {
                oregano = value;
                OnPropertyChanged("Oregano");
            }
        }

        private bool sesame;
        public bool Sesame
        {
            get 
            { 
                return sesame; 
            }
            set
            {
                sesame = value;
                OnPropertyChanged("Sesame");
            }
        }

        private bool hotPepper;
        public bool HotPepper
        {
            get 
            {
                return hotPepper;
            }
            set
            {
                hotPepper = value;
                OnPropertyChanged("HotPepper");
            }
        }

        private bool cheese;
        public bool Cheese
        {
            get
            {
                return cheese;
            }
            set
            {
                cheese = value;
                OnPropertyChanged("Cheese");
            }
        }
        #endregion

        #region Commands
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }
        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }
        #endregion

        #region Functions

        private void SaveExecute()
        {
            try
            {
                ObservableCollection<string> allIngredients = new ObservableCollection<string>();
                if (Salami == true)
                {
                    allIngredients.Add("Salami");
                }
                if (Ham == true)
                {
                    allIngredients.Add("Ham");
                }
                if (Mayo == true)
                {
                    allIngredients.Add("Mayo");
                }
                if (Ketchup == true)
                {
                    allIngredients.Add("Ketchup");
                }
                if (Kulen == true)
                {
                    allIngredients.Add("Kulen");
                }
                if (Olives == true)
                {
                    allIngredients.Add("Olives");
                }
                if (Oregano == true)
                {
                    allIngredients.Add("Oregano");
                }
                if (Sesame == true)
                {
                    allIngredients.Add("Sesame");
                }
                if (HotPepper == true)
                {
                    allIngredients.Add("HotPepper");
                }
                if (Cheese == true)
                {
                    allIngredients.Add("Cheese");
                }
                Ingredients.ingredientList = allIngredients;

                MessageBox.Show("Intgredients Choosed Successfully! ");
                CreatePizzaView createPizzaView = new CreatePizzaView();
                ingredientsView.Close();
                createPizzaView.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        private void CloseExecute()
        {
            ingredientsView.Close();
        }

        private bool CanCloseExecute()
        {
            return true;
        }

        #endregion
    }
}
