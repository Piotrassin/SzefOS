using MAS_Końcowy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace MAS_Końcowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Składniki_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Window menuList = new MenuList();
            menuList.ShowDialog();
        }

        private void Pracownicy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dostawy_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
