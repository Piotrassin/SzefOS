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
    /// Logika interakcji dla klasy MenuList.xaml
    /// </summary>
    public partial class MenuList : Window
    {
        private List<Menu> menus;
        public MenuList()
        {
            menus = MenuService.ToList();
            InitializeComponent();
            DataGridMenus.ItemsSource = MenuService.ToList();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            MenuService.New();
            updateData();
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            Menu item = (Menu)DataGridMenus.SelectedItem;
            if (item != null)
            {
                Window MenuWindow = new MenuWindow(item);
                MenuWindow.ShowDialog();
                updateData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Menu item = (Menu)DataGridMenus.SelectedItem;
            if (item != null)
            {
                MenuService.Delete(item);
                updateData();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void updateData()
        {
            menus = MenuService.ToList();
            DataGridMenus.ItemsSource = menus;
        }
    }
}
