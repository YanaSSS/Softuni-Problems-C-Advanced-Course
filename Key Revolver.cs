using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] locks = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> loadedGun = new Stack<int>(bullets);
            Queue<int> locksToBreak = new Queue<int>(locks);

            int bulletsUsed = 0;

            while (loadedGun.Count != 0 && locksToBreak.Count != 0)
            {


                int currentBullet = loadedGun.Pop();

                if (currentBullet <= locksToBreak.Peek())
                {
                    Console.WriteLine("Bang!");
                    locksToBreak.Dequeue();

                }

                else
                {
                    Console.WriteLine("Ping!");
                }

                bulletsUsed++;

                if (bulletsUsed % gunBarrelSize == 0 && loadedGun.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

            }

            if (locksToBreak.Count != 0)
            {

                Console.WriteLine($"Couldn't get through. Locks left: {locksToBreak.Count}");

            }
            else if (locksToBreak.Count == 0)
            {
                Console.WriteLine($"{loadedGun.Count} bullets left. " +
                    $"Earned ${ intelligenceValue - (bulletsUsed * bulletPrice)}");
            }
        }
    }
}
