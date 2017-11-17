using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONDR_Lab2
{
    class Program
    {
        static int ShowArr(int[,] arr)
        {
            int maxFF = 0;
            int maxI = 0;
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write("Хромосома [{0}] =  ",i+1);
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                arr[i, 10] = Function(arr, i);
                Console.Write("   FF = {0}",arr[i,10]);
                if (maxFF < Function(arr, i))
                {
                    maxFF = Function(arr, i);
                    maxI = i;
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            return maxI;
        }
        static void Crossing(int[,] arr, int father,int mother,int child1, int child2)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 2 || i == 3 || i == 7 || i == 8)
                {
                    arr[child1, i] = arr[father, i];
                    arr[child2, i] = arr[mother, i];
                }
                else
                {
                    arr[child1, i] = arr[mother, i];
                    arr[child2, i] = arr[father, i];
                }
            }
        }
        static int Function(int[,] arr,int line)
        {
            int res = 1;
            for (int i = 0; i < 10; i++)
            {
                if (i < 6)
                    res *= arr[line, i];
                else
                    res += arr[line, i];
            }
            return res;
        }
        static void Mutation(int[,] arr)
        {
            Random rand = new Random();
            for (int i = 6; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (rand.NextDouble() < 0.21)
                        arr[i, j] = rand.Next(5, 22);  
                }
            }
        }
        static void Main(string[] args)
        {
            int[,] arr = new int[10, 11];
            int max;
            Random rand = new Random();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = rand.Next(5, 22);
                }
            }
            Console.WriteLine("Вихiдна популяцiя: ");
            ShowArr(arr);
            Crossing(arr, 2, 3, 6, 7);
            Crossing(arr, 4, 5, 8, 9);
            Console.WriteLine("Популяцiя пiсля схрещування: ");
            ShowArr(arr);
            Console.WriteLine("Популяцiя пiсля мутацiї: ");
            Mutation(arr);
            max = ShowArr(arr);
            Console.WriteLine("Хромосома [{0}] = має найбiльше значення функцiї вiдповiдностi",max);
            Console.ReadKey();
        }
    }
}
