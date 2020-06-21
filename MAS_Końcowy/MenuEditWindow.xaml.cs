using MAS_Końcowy.Model;
using MAS_Końcowy.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MAS_Końcowy
{
    /// <summary>
    /// Logika interakcji dla klasy MenuEditWindow.xaml
    /// </summary>
    public partial class MenuEditWindow : Window
    {
        private Menu _menu;
        public MenuEditWindow(Menu menu)
        {
            _menu = menu;
            InitializeComponent();
            TextBoxProfitMargin.Text = _menu.ProfitMargin.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var dishesInMenu = MenuService.GetDishes(_menu.Id);

        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
