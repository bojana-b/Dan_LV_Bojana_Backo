using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_wpf.Commands;
using Zadatak_wpf.Model;
using Zadatak_wpf.View;

namespace Zadatak_wpf.ViewModel
{
    class CreatePizzaViewModel : ViewModelBase
    {
        CreatePizzaView createPizzaView;
        Ingredients ingredients;

        public CreatePizzaViewModel(CreatePizzaView createPizzaViewOpen)
        {
            createPizzaView = createPizzaViewOpen;
            ingredients = new Ingredients();
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

        private string ingredient;
        public string Ingredient
        {
            get
            {
                return ingredient;
            }
            set
            {
                ingredient = value;
                OnPropertyChanged("Ingredient");
            }
        }
        private int currentPrice = 0;
        public int CurrentPrice
        {
            get
            {
                return currentPrice;
            }
            set
            {
                currentPrice = value;
                OnPropertyChanged("CurrentPrice");
            }
        }
        private string size = "";
        public string Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
                OnPropertyChanged("Size");
            }
        }
        private bool canClose = true;
        public bool CanClose
        {
            get
            {
                return canClose;
            }
            set
            {
                canClose = value;
                OnPropertyChanged("CanClose");
            }
        }
        #endregion
        #region Commands
        // AddIngredients Button
        private ICommand addIngredients;
        public ICommand AddIngredient
        {
            get
            {
                if (addIngredients == null)
                {
                    addIngredients = new RelayCommand(param => AddIngredientsExecute(), param => CanAddIngredientsExecute());
                }
                return addIngredients;
            }
        }
        private void AddIngredientsExecute()
        {
            try
            {
                ChooseIngredients chooseIngredients = new ChooseIngredients();
                chooseIngredients.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanAddIngredientsExecute()
        {
            return true;
        }

        // CalculateAmount Button
        private ICommand calculateAmount;
        public ICommand CalculateAmount
        {
            get
            {
                if (calculateAmount == null)
                {
                    calculateAmount = new RelayCommand(param => CalculateAmountExecute(), param => CanCalculateAmountExecute());
                }
                return calculateAmount;
            }
        }
        private void CalculateAmountExecute()
        {
            try
            {
                CanClose = false;
                foreach (var x in ingredientList)
                {
                    if (x.Contains("Ham"))
                    {
                        CurrentPrice += 30;
                    }
                    else if (x.Contains("Salami"))
                    {
                        CurrentPrice += 25;
                    }
                    else if (x.Contains("Kulen"))
                    {
                        CurrentPrice += 35;
                    }
                    else if (x.Contains("Ketchup"))
                    {
                        CurrentPrice += 15;
                    }
                    else if (x.Contains("Mayo"))
                    {
                        CurrentPrice += 13;
                    }
                    else if (x.Contains("Olives"))
                    {
                        CurrentPrice += 19;
                    }
                    else if (x.Contains("Oregano"))
                    {
                        CurrentPrice += 8;
                    }
                    else if (x.Contains("Sesame"))
                    {
                        CurrentPrice += 7;
                    }
                    else if (x.Contains("Cheese"))
                    {
                        CurrentPrice += 20;
                    }
                    else if (x.Contains("HotPepper"))
                    {
                        CurrentPrice += 18;
                    }
                }
                if (Size.Equals("Small"))
                {
                    CurrentPrice += 700;
                }
                else if (Size.Equals("Medium"))
                {
                    CurrentPrice += 800;
                }
                else
                {
                    CurrentPrice += 900;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCalculateAmountExecute()
        {
            return true;
        }

        // Confirm Button
        private ICommand confirm;
        public ICommand Confirm
        {
            get
            {
                if (confirm == null)
                {
                    confirm = new RelayCommand(param => ConfirmExecute(), param => CanConfirmExecute());
                }
                return confirm;
            }
        }
        private void ConfirmExecute()
        {
            try
            {
                IngredientList = Ingredients.ingredientList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanConfirmExecute()
        {
            return true;
        }

        //Close Button
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
        private void CloseExecute()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to close?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    createPizzaView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCloseExecute()
        {
            return true;
        }
        //NewOrder Button
        private ICommand newOrder;
        public ICommand NewOrder
        {
            get
            {
                if (newOrder == null)
                {
                    newOrder = new RelayCommand(param => NewOrderExecute(), param => CanNewOrderExecute());
                }
                return newOrder;
            }
        }
        private void NewOrderExecute()
        {
            try
            {
                IngredientList = new ObservableCollection<string>();
                Size = null;
                CanClose = true;
                CurrentPrice = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanNewOrderExecute()
        {
            return true;
        }
        #endregion
    }
}
