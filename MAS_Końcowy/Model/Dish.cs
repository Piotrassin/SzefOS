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
    public enum DegreeOfAnimalOrigin { Mięsne, Wegetariańskie, Wegańskie };
    public class Dish
    {
        //[Key]
        public int Id { get; private set; }
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public bool GlutenFree { get; private set; }
        public DishType Type { get; private set; }
        public DegreeOfAnimalOrigin AnimalOrigin { get; private set; }

        public ICollection<DishIngredients> DishIngredients { get; set; }


        public Dish() { }

        public Dish(String name, Decimal price, DishType type, DegreeOfAnimalOrigin degOfAnimal, bool glutenFree)
        {
            Name = name;
            Price = price;
            Type = type;
            AnimalOrigin = degOfAnimal;
            GlutenFree = glutenFree;
        }

        public async static void AddContent(int currId, DishIngredients content)
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
