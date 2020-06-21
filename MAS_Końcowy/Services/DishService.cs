using MAS_Końcowy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAS_Końcowy.Services
{
    class DishService
    {
        public static List<DishContent> GetContents(int dishId)
        {
            using (var context = new MASContext())
            {
                return context.DishContents
                    .Include(c => c.Ingredient)
                    .Where(a => a.DishId == dishId)
                    .ToList();
            }
        }

        public static void AddIngredient(int dishId, double quantity, Ingredient ingredient)
        {
            using (var context = new MASContext())
            {
                var dish = context.Dishes.Include(a => a.DishIngredients).Where(x => x.Id == dishId).FirstOrDefault();

                if (dish != null && !dish.DishIngredients.Any(a => a.IngredientId == ingredient.Id))
                {
                    context.DishContents.Add(new DishContent(dish, ingredient, quantity));
                    context.SaveChanges();
                }
            }
        }
    }
}
