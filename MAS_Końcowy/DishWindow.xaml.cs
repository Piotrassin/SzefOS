using MAS_Końcowy.Model;
using MAS_Końcowy.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MAS_Końcowy
{
    /// <summary>
    /// Logika interakcji dla klasy DishWindow.xaml
    /// </summary>
    public partial class DishWindow : Window
    {
        private List<DishContent> contents;
        public DishWindow(Dish dish)
        {
            contents = DishService.GetContents(dish.Id);
            InitializeComponent();
            DataGridDishes.ItemsSource = contents;
        }

        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
