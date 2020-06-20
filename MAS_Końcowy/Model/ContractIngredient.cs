using System;
using System.Collections.Generic;
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
    }
}
