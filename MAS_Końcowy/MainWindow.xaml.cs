using MAS_Końcowy.Model;
using MAS_Końcowy.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAS_Końcowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Dish> dishesList = new ObservableCollection<Dish>();
        public MainWindow()
        {
            InitializeComponent();

            //dishesList.Add(new Dish("pizza", 30.00m, DishType.Główne, DegreeOfAnimalOrigin.Wegetariańskie, false));
            DataGridDishes.ItemsSource = dishesList;
        }

    }
}
