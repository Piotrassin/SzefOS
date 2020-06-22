using MAS_Końcowy.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAS_Końcowy.Services
{
    class MenuService
    {
        public static IEnumerable<Dish> GetDishes(int menuId)
        {
            using (var context = new MASContext())
            {
                return context.Dishes
                    .Include(c => c.Menu)
                    .Include(a => a.DishIngredients)
                        .ThenInclude(b => b.Ingredient)
                    .Where(d => d.Menu.Id == menuId)
                    .ToList();
            }
        }

        public static Menu GetMenu(int menuId)
        {
            using (var context = new MASContext())
            {
                return context.Menus.Find(menuId);
            }
        }

        public static void Delete(Menu menu)
        {
            if(menu == null)
            {
                throw new Exception("Passed argument is null");
            }

            using (var context = new MASContext())
            {
                context.Menus.Remove(menu);
                context.SaveChanges();
            }
        }

        public static List<Menu> ToList()
        {
            using (var context = new MASContext())
            {
                return context.Menus.ToList();
            }
        }

        public static void New()
        {
            using (var context = new MASContext())
            {
                context.Menus.Add(new Menu(0.0d));
                context.SaveChanges();
            }
        }

        public static void ChangePrices(Menu menu, double newMargin)
        {
            using (var context = new MASContext())
            {
                menu.ProfitMargin = newMargin;
                context.Menus.Update(menu);
                context.SaveChanges();

                using (var transaction = context.Database.BeginTransaction())
                {
                    var dishes = GetDishes(menu.Id);
                    if (dishes != null)
                    {
                        foreach (var dish in dishes)
                        {
                            DishService.ChangePrice(dish, newMargin);
                        }
                    }
                    transaction.Commit();
                }
                context.SaveChanges();
            }
        }
    }
}
