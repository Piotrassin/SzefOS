using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class Ingredient
    {
        //[Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public Decimal PricePerKg { get; set; }
        public ICollection<DishIngredients> DishContents { get; set; }

        public Ingredient() { }

        public Ingredient(String name, Decimal pricePerKg)
        {
            Name = name;
            PricePerKg = pricePerKg;
        }
    }
}
