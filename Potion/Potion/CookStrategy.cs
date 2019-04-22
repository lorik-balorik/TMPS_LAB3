using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    public abstract class CookStrategy
    {
        public abstract void Cook(string potion);
    }

    class ElixirofRevelationsPotion : CookStrategy
    {
        public override void Cook(string name)
        {
            Console.WriteLine("Cooking " + name + " with a pleasant sweet smell");
        }
    }

    class DraughtofWeaknessPotion : CookStrategy
    {
        public override void Cook(string name)
        {
            Console.WriteLine("Cooking "+ name + " potion with unpleasant tart smell. Shoul i really drink it?");
        }
    }
    
}
