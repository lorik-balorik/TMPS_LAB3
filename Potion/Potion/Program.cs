
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    class Program
    {
        static PotionCollection Menu()
        {
            PotionCollection collection = new PotionCollection();
            collection[0] = new Potion("Draught of Weakness", 80, new DraughtofWeakness());
            collection[1] = new Potion("Draught of Fixation", 80, new DraughtofFixation());
            collection[2] = new Potion("Flask of Mortality", 70, new FlaskofMortality());
            collection[5] = new Potion("Elixir of Revelations", 85, new ElixirofRevelations());
            Console.WriteLine("After many days of travel, you enter a tavern owned by a very strange person");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("The Shopkeeper welcomes you, kind sir!");
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Please, have a look at my recipes of my potions. If you like one, my wizard will make it for you for very good price!");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Oh, I forgot to add. If you order more than 5 potions, you get a discount of 7 percent! Only today!");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("---------------------|Potions|---------------------");
            PotionIterator iterator = collection.CreateIterator();
            for (Potion item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(iterator.ItemIndex + 1 + ")" + item.Name + "\t" + item.Price + " gold coins");
            }

            return collection;
        }

        static void Main(string[] args)
        {
            var collection = Menu();
            Console.WriteLine("--------|Choose an action|----------");
            Console.WriteLine("1-AddCommand");

            List<Client> clientOrders = new List<Client>();
            Client client = new Client();
            while (true)
            {
                Console.WriteLine("Do you want to buy something ? Y/N");
                if (Console.ReadLine() == "Y" || Console.ReadLine() == "y")
                {
                    Console.WriteLine("Enter the potion number:");
                    var commandPotion = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the amount:");
                    var amount = int.Parse(Console.ReadLine());

                    client.SetCommand(1);
                    var Potion = collection[commandPotion - 1] as Potion;
                    Potion.Amount = amount;
                    Potion.Price = Potion.Amount * Potion.Price;
                    Potion.CookStrategy = new DraughtofWeaknessPotion();

                    client.SetMenuItem(Potion);
                    client.ExecuteCommand();
                    client.ShowCurrentOrder();
                    client.PotionCount = client.Order.PotionItems.Count;

                }
                else
                {
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
