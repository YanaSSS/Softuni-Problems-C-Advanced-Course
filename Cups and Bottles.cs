using System;
using System.Linq;
using System.Collections.Generic;

namespace Cups_and_Bottles
{
    class Program
    {
        static void Main()
        {
            LinkedList<int> cups = new LinkedList<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                int currentBottle = bottles.Pop();
                if (cups.First() < currentBottle)
                {
                    wastedWater += (currentBottle - cups.First());
                    cups.RemoveFirst();
                }
                
                else
                {
                    var firstCup = cups.First();
                    cups.RemoveFirst();
                    firstCup -= currentBottle;
                    cups.AddFirst(firstCup);
                }

                if (cups.Count>0 && cups.First() == 0)
                {
                    cups.RemoveFirst();

                }
            }

            if(cups.Count==0)
            {
                Console.WriteLine("Bottles: " + string.Join(' ', bottles));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
            else if(bottles.Count==0)
            {
                Console.WriteLine("Cups: " + string.Join(' ', cups));
                Console.WriteLine($"Wasted litters of water: {wastedWater}");
            }
        }
    }
}
