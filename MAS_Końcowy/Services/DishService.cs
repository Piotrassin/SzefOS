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

        public static void ChangePrice(Dish dish, double newMargin)
        {
            using (var context = new MASContext())
            {
                double sum = 0.0;
                var contents = context.DishContents.Include(a => a.Ingredient).Where(a => a.DishId == dish.Id).ToList();

                foreach (var content in contents)
                {
                    var quantity = (double)content.Quantity;
                    var pricePerKg = (double)content.Ingredient.PricePerKg;
                    sum += quantity * pricePerKg;
                }

                sum += sum * newMargin;

                dish.Price = (Decimal)sum;
                Dish EditedDish = context.Dishes.Where(a => a.Id == dish.Id).FirstOrDefault();
                EditedDish.Price = (Decimal)Math.Round(sum, 2);
                context.Update(EditedDish);
                context.SaveChanges();
            }
        }

        public static Dish Get(Dish dish)
        {
            if (dish == null)
            {
                throw new Exception("Passed argument is null");
            }
            using (var context = new MASContext())
            {
                return context.Dishes.FirstOrDefault(a => a.Id == dish.Id);
            }
        }
    }
}
