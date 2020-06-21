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
    }
}
