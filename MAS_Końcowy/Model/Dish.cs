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
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public bool GlutenFree { get; private set; }
        public DishType Type { get; private set; }
        public DegreeOfAnimalOrigin AnimalOrigin { get; private set; }

        public Menu Menu { get; set; }
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

        public async static void AddIngredient(int currId, DishContent content)
        {
            using (var context = new MASContext())
            {
                var curDish = await context.Dishes.Where(x => x.Id == currId).FirstOrDefaultAsync();

                if (!curDish.DishIngredients.Contains(content))
                {
                    curDish.DishIngredients.Add(content);
                    context.Entry(curDish).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }

        
    }
}
