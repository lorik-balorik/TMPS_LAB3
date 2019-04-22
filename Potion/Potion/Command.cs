using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Potion
{
    public class CommandFactory
    {
        public ICommand GetCommand(int commandOption)
        {
            switch (commandOption)
            {
                case 1:
                    return new AddCommand();
                default:
                    return new AddCommand();
            }
        }
    }

    public interface ICommand
    {
        void Execute(List<Potion> order, Potion PotionItem, int amount);
    }

    public class AddCommand : ICommand
    {
        public void Execute(List<Potion> order, Potion PotionItem, int amount )
        {
            for(var i = 0; i < amount; i++)
            {
                order.Add(PotionItem);
            }
        }
    }
}
