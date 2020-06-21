using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAS_Końcowy.Model
{
    public class ContractIngredient
    {
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public ContractIngredient() { }

        public ContractIngredient(Contract contract, Ingredient ingredient)
        {
            Contract = contract;
            Ingredient = ingredient;
        }



        public void a()
        {
            using (var context = new MASContext())
            {
                var contract = context.Contracts.Include(a => a.ContractIngredients).First(b => b.Id == 1);
                if (contract == null)
                {
                    throw new Exception("nie działa");
                }
                var i1 = new Ingredient("Chleb", 10.00m);
                var i2 = new Ingredient("Ser", 19.00m);
                var i3 = new Ingredient("Wołowina", 34.00m);
                var i4 = new Ingredient("Sałata", 5.00m);
                var ic1 = new ContractIngredient();

                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Update(contract);
                        context.SaveChanges();

                        context.Ingredients.Add(i1);
                        context.Ingredients.Add(i2);
                        context.Ingredients.Add(i3);
                        context.Ingredients.Add(i4);
                        context.SaveChanges();

                        context.ContractIngredients.Add(new ContractIngredient(contract, i1));
                        context.ContractIngredients.Add(new ContractIngredient(contract, i2));
                        context.ContractIngredients.Add(new ContractIngredient(contract, i3));
                        context.ContractIngredients.Add(new ContractIngredient(contract, i4));
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
