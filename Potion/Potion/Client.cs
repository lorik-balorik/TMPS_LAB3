using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    public class Order
    {
        public List<Potion> PotionItems { get; set; }
        private int _PotionCount { get; set; }

        public Order()
        {
            PotionItems = new List<Potion>();
        }

        public void ExecuteCommand(ICommand command , Potion item)
        {
            command.Execute(PotionItems, item, item.Amount);
        }

        public void ShowOrder()
        {
            foreach (var item in PotionItems)
            {
                item.Display();
            }
        }

        public void GetDiscount(Order order)
        {
            if (order.PotionItems.Count >= 6)
            {
                Console.WriteLine("Congratulation you've got a discount of 7%");
            }
        }
    }

    public class Client
    {
        private Potion _menuItem;
        private ICommand _command;
        public Order Order { get; set; }
        private int _PotionCount;

        public Client()
        {
            _PotionCount = 0;
            Order = new Order();
        }

        public void SetCommand(int commandOption)
        {
            _command = new CommandFactory().GetCommand(commandOption);    
        }

        public void SetMenuItem(Potion PotionItem)
        {
            _menuItem = PotionItem;
        }

        public void ExecuteCommand()
        {
            Order.ExecuteCommand(_command, _menuItem);
        }

        public void ShowCurrentOrder()
        {
            Order.ShowOrder();
        }

        public void Notify()
        {
            Order.GetDiscount(Order);
        }

        public int PotionCount
        {
            get { return _PotionCount; }
            set
            {
                if (Order.PotionItems.Count >= value)
                {
                    _PotionCount = value;
                    Notify();
                }
            }
        }

       
    }
}
