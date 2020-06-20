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
        private ObservableCollection<Dish> dishesList = new ObservableCollection<Dish>();
        public MainWindow()
        {
            InitializeComponent();

            //abc();
            //dishesList.Add(new Dish("pizza", 30.00m, DishType.Główne, DegreeOfAnimalOrigin.Wegetariańskie, false));
            Tests.ItemsSource = def();
            DataGridDishes.ItemsSource = dishesList;

            
        }

        public void abc()
        {
            using (var context = new MASContext())
            {
                context.People.Add(
                    new Cook("Jan", "Kowalski", "+48555123456",  new Address("Aleje Jerozolimskie", "123", "12", "01-123", "Warszawa"), 
                    new DateTime(1990, 10, 10), "90101012345", 1500.0m, new DateTime(2021, 3, 12)));
                context.SaveChanges();
            }
        }

        public IEnumerable<Person> def()
        {
            using (var context = new MASContext())
            {
                return context.People.Include(a => a.Address).Where(a => a.Id >= 0).ToList();
            }
        }
    }
}
