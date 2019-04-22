using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    public class Potion 
    {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public CookStrategy CookStrategy { get; set; }
        public PotionTemplate CookingTemplate { get; set; }
        public Order order { get; set; }

        public Potion(string name, decimal price, PotionTemplate template)
        {
            Name = name;
            Price = price;
            CookingTemplate = template;
        }

        public void Livrate(Potion Potion)
        {
            Console.WriteLine("Livrating: " + Potion.Name);
        }

        public void Display()
        {
            Console.WriteLine("-----------------Potion Details-----------------");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Amount: " + Amount);
            Console.WriteLine("--------------Cooking Strategy-----------------");
            CookStrategy.Cook(Name);
            Console.WriteLine("---------------------Cooking-------------------");
            CookingTemplate.GetIngredients();
            CookingTemplate.Bake();
            CookingTemplate.Pour();
            Console.WriteLine("\n");
 
        }

    }

    public interface IPotionCollection
    {
        PotionIterator CreateIterator();
    }

    public class PotionCollection : IPotionCollection
    {
        private ArrayList _items = new ArrayList();

        public PotionIterator CreateIterator()
        {
            return new PotionIterator(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Add(value);  }
        }
    }

    public interface IPotionIterator
    {
        Potion First();
        Potion Next();
        bool IsDone { get; }
        int ItemIndex { get; }
        Potion CurrentPotion { get; }
    }

    public class PotionIterator : IPotionIterator
    {
        private PotionCollection _Potions;
        private int _current = 0;
        private int step = 1;

        public PotionIterator(PotionCollection Potions)
        {
            _Potions = Potions;
        }

        public Potion First()
        {
            _current = 0;
            return _Potions[_current] as Potion;
        }

        public Potion CurrentPotion
        {
            get { return _Potions[_current] as Potion; }
        }

        public Potion Next()
        {
            _current += step;
            if (!IsDone)
            {
                return _Potions[_current] as Potion;
            }

            return null;
        }

        public bool IsDone
        {
            get
            {
                return _current >= _Potions.Count;
            }
        }

        public int ItemIndex
        {
            get { return _current; }
        }
    }
}
