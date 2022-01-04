using System;
using System.Collections.Generic;

namespace DividerGroups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            List<int>[] Groups = new List<int>[1];

            Console.Write("N = ");
            if(int.TryParse(Console.ReadLine(), out N))
            {
                if (N > 0)
                {
                    InitGroups(ref Groups);

                    FindGroups(ref Groups, N);

                    PrintGroups(Groups);
                    return;
                }
            }

            Console.WriteLine("Invalid input!");
            return;
        }

        static void InitGroups(ref List<int>[] Groups)
        {
            Array.Resize(ref Groups, 1);
            Groups[0] = new List<int>();
            Groups[0].Add(1);
        }

        static void FindGroups(ref List<int>[] Groups, int N)
        {
            bool divisorFinded = false;
            for(int i = 2; i <= N; i++)
            {
                for(int j = 0; j < Groups.Length; j++)
                {
                    divisorFinded = false;
                    foreach(int divisor in Groups[j])
                    {
                        if(i % divisor == 0)
                        {
                            divisorFinded = true;
                            break;
                        }
                    }
                    if(!divisorFinded)
                    {
                        Groups[j].Add(i);
                        break;
                    }
                }
                if(divisorFinded)
                {
                    Array.Resize(ref Groups, Groups.Length + 1);
                    Groups[Groups.Length - 1] = new List<int>();
                    Groups[Groups.Length - 1].Add(i);
                }
            }
        }

        static void PrintGroups(List<int>[] Groups)
        {
            for(int i = 0; i < Groups.Length; i++)
            {
                Console.WriteLine();
                Console.Write($"{i}: ");

                foreach(int j in Groups[i])
                {
                    Console.Write($"{j} ");
                }
            }
            Console.WriteLine();
        }
    }
}
