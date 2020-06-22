using MAS_Końcowy.Model;
using MAS_Końcowy.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Menu = MAS_Końcowy.Model.Menu;

namespace MAS_Końcowy
{
    /// <summary>
    /// Logika interakcji dla klasy Menu.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private Menu CurrentMenu; 
        public MenuWindow(Menu menu)
        {
            CurrentMenu = MenuService.GetMenu(menu.Id);
            InitializeComponent();
            TextBlockMarginProfit.Content = CurrentMenu.ProfitMargin.ToString();
            DataGridDishes.ItemsSource = MenuService.GetDishes(menu.Id);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window dish = new NewDishWindow();
            dish.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MenuEditWindow edit = new MenuEditWindow(CurrentMenu);
            edit.ShowDialog();

            if (edit.IsEdited)
            {
                MenuService.ChangePrices(edit.Menu, edit.NewMargin);
                UpdateData();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShoWDishButton_Click(object sender, RoutedEventArgs e)
        {
            var dish = (Dish) DataGridDishes.SelectedItem;
            if(dish != null)
            {
                Window dishWindow = new DishWindow(dish);
                dishWindow.ShowDialog();
            }
        }

        private void UpdateData()
        {
            CurrentMenu = MenuService.GetMenu(CurrentMenu.Id);
            TextBlockMarginProfit.Content = CurrentMenu.ProfitMargin.ToString();
            DataGridDishes.ItemsSource = MenuService.GetDishes(1);
        }
    }
}
