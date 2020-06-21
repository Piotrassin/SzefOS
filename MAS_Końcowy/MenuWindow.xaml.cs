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
        public Menu menu; 
        public MenuWindow()
        {
            menu = MenuService.GetMenu(1);
            InitializeComponent();
            TextBlockMarginProfit.Content = menu.ProfitMargin.ToString();
            DataGridDishes.ItemsSource = MenuService.GetDishes(1);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window dish = new NewDishWindow();
            dish.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Window edit = new MenuEditWindow(menu);
            edit.ShowDialog();
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
    }
}
