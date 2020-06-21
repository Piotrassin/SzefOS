using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public double ProfitMargin { get; private set; }
        public ICollection<Dish> Dishes { get; set; }



        //public Menu() { }

        //public Menu(double profitMargin)
        //{
        //    ProfitMargin = profitMargin;

        //}

        //public void RemoveDish(Dish dish)
        //{
        //    throw new NotImplementedException();
        //}

        //public void AddDish(Dish dish)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
