using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nums_Guess
{
    class Program
    {
        static int range = 20;
        static void Main(string[] args)
        {
            string khbit;
            do
            {
                int[] nums = new int[1100];
                int posi = 0;
                int i = 1100;
                int count_true = 1;
                int count_false = 1;
                float accuracy_true;
		Console.WriteLine("Your input: ");
                do
                {
                    input(ref nums, ref posi, ref count_true, ref count_false);
                    accuracy_true = (float)count_true / (count_true + count_false);
                    accuracy_true *= 100;
                    if (posi == 10 || posi == 50 || posi == 100 || posi == 200 || posi == 500 || posi == 700 || posi == 1000)
                    {
                        Console.WriteLine("Range: " + range + " .Time: " + posi);
                        Console.WriteLine("Accuracy(true): "+ accuracy_true + ".False: " + (100 - accuracy_true) + "\n\n\n");
                    }
                    i--;
                } while (i > 0);
                khbit = Console.ReadLine();
            } while (khbit!="0");
        }
        static void input(ref int[] nums, ref int posi, ref int count_true, ref int count_false)
        {
            Random rand = new Random();
            string str;
            int user_num = -1;
            int comp_num = -1;
            comp_num = Guess_Number(nums, posi);
            str = Console.ReadLine();
            int.TryParse(str, out user_num);
            if (user_num != -1) { nums[posi] = user_num; posi++; }
            if (comp_num == user_num) count_true++;
            else count_false++;
        }
        static int Guess_Number(int[] nums, int posi)
        {
            Random rand = new Random();
            if (posi < range) return rand.Next(2);
            else
            {
                posi -= 1;
                int check = posi;
                int[] temp = new int[range];
                for (int i = range-1; i >= 0; i--) 
                {
                    temp[i] = nums[posi];
                    posi--;
                }
                return CompareArr(nums, temp, check);
            }
        }
        static int CompareArr(int[] nums, int[] temp, int posi)
        {
            int k = -1;
            int count_zero, count_one;
            count_one = count_zero = 0;
            for (int i = 0; i < posi; i++) 
            {
                k = i;
                for (int j = 0; j < range; j++) 
                {
                    if (temp[j] == nums[i] && i < posi){ i++; }
                    else { j = range; i = k; }
                    if (j == range - 1) 
                    {
                        if (nums[i] == 0) count_zero++;
                        else count_one++;
                    }
                }
            }
            if (count_zero > count_one) return 0;
            else return 1;
        }
    }
}
