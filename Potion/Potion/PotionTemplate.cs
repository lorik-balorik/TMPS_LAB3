using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    public enum Ingredients{
        Fluxweed , Aconite, Belladona, Bezoar, Mushrooms, Cheese, Lionfish, Peppermint,  Peacock, Ptolemy, Nightshade, Rose
    }

    public abstract class PotionTemplate
    {
        public List<Ingredients> ingredients { get; set; }

        public abstract void GetIngredients();

        public abstract void Bake();

        public void Pour()
        {
            Console.WriteLine("Pouring Potion in beautiful flask");
        }

        public void Cook()
        {
            GetIngredients();
            Bake();
            Pour();
        }
    }

    public class DraughtofWeakness : PotionTemplate
    {

        public override void Bake()
        {
            Console.WriteLine("Cook 30 minutes at 180 degrees Celsius");
        }

        public override void GetIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>()
            {
                Ingredients.Fluxweed,
                Ingredients.Belladona,
                Ingredients.Mushrooms,
                Ingredients.Rose
            };
            foreach (var item in ingredients)
            {
               Console.WriteLine("Add:\t" + item);
            }
        }
    }


    public class ElixirofRevelations : PotionTemplate
    {

        public override void Bake()
        {
            Console.WriteLine("Cook 40 minutes at 180 degrees Celsius");
        }

        public override void GetIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>()
            {
                Ingredients.Mushrooms,
                Ingredients.Belladona,
                Ingredients.Lionfish,
                Ingredients.Peacock
            };
            foreach (var item in ingredients)
            {
                 Console.WriteLine("Add:\t" + item);
            }
        }
    }


    public class DraughtofFixation : PotionTemplate
    {

        public override void Bake()
        {
            Console.WriteLine("Cook 35 minutes at 160 degrees Celsius");
        }

        public override void GetIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>()
            {
               Ingredients.Nightshade,
               Ingredients.Peppermint,
                Ingredients.Bezoar,
                Ingredients.Mushrooms
            };
            foreach (var item in ingredients)
            {
                 Console.WriteLine("Add:\t" + item);
            }
        }
    }


    public class FlaskofMortality : PotionTemplate
    {
   
        public override void Bake()
        {
            Console.WriteLine("Cook 42 minutes at 150 degrees Celsius");
        }

        public override void GetIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>()
            {
                Ingredients.Ptolemy,
                Ingredients.Aconite,
                Ingredients.Fluxweed,
                Ingredients.Cheese
            };

            foreach (var item in ingredients)
            {
                Console.WriteLine("Add:\t" + item);
            }
        }
    }
}
