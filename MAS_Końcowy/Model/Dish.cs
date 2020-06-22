using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;

namespace MAS_Końcowy.Model
{
    public enum DishType {
        Przystawka,
        Główne,
        Deser };
    public enum DegreeOfAnimalOrigin { 
        Mięsne, 
        Wegetariańskie, 
        Wegańskie };

    public class Dish
    {
        public int Id { get; private set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public bool GlutenFree { get; set; }
        public DishType Type { get; set; }
        public DegreeOfAnimalOrigin AnimalOrigin { get; set; }

        private Menu _menu;
        public Menu Menu
        {
            get => _menu;
            set
            {
                _menu = value;
                if (_menu != value)
                {
                    if (_menu != null) { _menu.RemoveDish(this); }

                    _menu = value;

                    if (_menu != null) { value.AddDish(this); }
                }
            }
        }
        public ICollection<OrderContent> OrderContents { get; set; }
        public ICollection<DishContent> DishIngredients { get; set; }
        


        public Dish() { }

        public Dish(
            String name, Decimal price, DishType type, 
            DegreeOfAnimalOrigin degOfAnimal, bool glutenFree, Menu menu)
        {
            Name = name;
            Price = price;
            Type = type;
            AnimalOrigin = degOfAnimal;
            GlutenFree = glutenFree;
            Menu = menu;
        }

        internal void AddOrderDish(OrderContent orderContent)
        {
            throw new NotImplementedException();
        }

        //public void AddOrder(Order order, int count)
        //{
        //    throw new NotImplementedException();
        //    //OrderDish oDish = new OrderDish(order, this, count);
        //}



        override public String ToString()
        {
            return "Name: " + Name + ", Price " + Price + " PLN";
        }
    }
}
