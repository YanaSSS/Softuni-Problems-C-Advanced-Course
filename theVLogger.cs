using System;
using System.Linq;
using System.Collections.Generic;

namespace The_V_Logger
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerPlatform
                = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0] == "Statistics")
                {
                    break;
                }

                string vlogger1 = input[0];
                string command = input[1];

                if (command == "joined")
                {
                    if (!vloggerPlatform.ContainsKey(vlogger1))
                    {
                        vloggerPlatform[vlogger1] = new Dictionary<string, HashSet<string>>();
                        vloggerPlatform[vlogger1].Add("followers", new HashSet<string>());
                        vloggerPlatform[vlogger1].Add("following", new HashSet<string>());
                    }
                }

                else if (command == "followed")
                {
                    string vlogger2 = input[2];

                    if (vlogger1 != vlogger2
                        && vloggerPlatform.ContainsKey(vlogger1)
                        && vloggerPlatform.ContainsKey(vlogger2))
                    {
                        vloggerPlatform[vlogger1]["following"].Add(vlogger2);
                        vloggerPlatform[vlogger2]["followers"].Add(vlogger1);
                    }
                }
            }

            vloggerPlatform = vloggerPlatform
                .OrderByDescending(v => v.Value["followers"].Count)
                .ThenBy(v => v.Value["following"].Count).ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine($"The V-Logger has a total of {vloggerPlatform.Count} vloggers in its logs.");

            int numberInRanking = 1;

            foreach (var vlogger in vloggerPlatform)
            {
                Console.WriteLine($"{numberInRanking}. {vlogger.Key} " +
                    $": {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (numberInRanking == 1 && vlogger.Value["followers"].Count > 0)
                {
                    Console.WriteLine(string.Join(Environment.NewLine,
                        vlogger.Value["followers"].OrderBy(x => x).Select(x => "* " + x)));
                }

                numberInRanking++;
            }
        }
    }
}
