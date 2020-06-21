using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MAS_Końcowy.Model
{
    //TODO: Zmienić nazwę na zgodne z konwencją DishIngredients
    public class DishContent
    {
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Quantity { get; set; }

        public DishContent() { }

        public DishContent(Dish dish, Ingredient ingredient, double quantity)
        {
            Dish = dish;
            Ingredient = ingredient;
            Quantity = quantity;
        }
    }
}
