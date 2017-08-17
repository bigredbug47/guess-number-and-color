using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_Color
{
    class Program
    {
        static int iCount = 0, iPosi = 0;
        static double iMin, iTemp_Min;
        static List<int> Width_Arr = new List<int>();
        static List<int> Height_Arr = new List<int>();
        static List<string> Color_Arr = new List<string>();
        static void Main(string[] args)
        {
            string choose;
            string user_w, user_h;
            do
            {
                Console.Clear();
                Console.WriteLine("Your choice is:\n1. Input a card.\n2. Guess a card.\n3. Exit");
                choose = Console.ReadLine();
                Console.Clear();
                if (choose == "1")
                {
                    int time;
                    Console.WriteLine("How many card you will input ???\n\n");
                    time = int.Parse(Console.ReadLine());
                    for (int j = 0; j < time; j++)
                    {
                        Console.WriteLine("Card number " + (j + 1) + ":");
                        input();
                    }
                }
                else if (choose == "2" && iCount > 2)
                {
                    user_w = Console.ReadLine();
                    user_h = Console.ReadLine();
                    Guess_Color(int.Parse(user_w), int.Parse(user_h));
                    Console.WriteLine("Do you want continue?\n1. Yes.\n2. No.\n");
                    int take;
                    take = int.Parse(Console.ReadLine());
                    if (take == 1) choose = "1";
                    else choose = "3";
                }
                else if (choose == "3")
                {
                    Console.WriteLine("\n\nThanks for playing!!!");
                    return;
                }
                else
                {
                    Console.WriteLine("Please choose correct number and the total of cards must larger than 2.\n\n");
                    choose = "4";
                }
            } while (choose !="3");            
        }
        static void input()
        {
            string width, height, color;
            width = Console.ReadLine();
            height = Console.ReadLine();
            color = Console.ReadLine();
            Width_Arr.Add(int.Parse(width));
            Height_Arr.Add(int.Parse(height));
            Color_Arr.Add(color);
            iCount++;
        }
        static void Guess_Color(int user_width, int user_height)
        {
            
            iMin = Math.Sqrt(Math.Abs((double)((user_width - Width_Arr[0]) * (user_width - Width_Arr[0])-((user_height-Height_Arr[0])*(user_height-Height_Arr[0])))));
            for (int i = 0; i < iCount; i++)
            {
                iTemp_Min = Math.Sqrt(Math.Abs(((double)((user_width - Width_Arr[i]) * (user_width - Width_Arr[i]) - ((user_height - Height_Arr[i]) * (user_height - Height_Arr[i]))))));
                if (iTemp_Min <= iMin)
                {
                    iMin = iTemp_Min;
                    iPosi = i;
                }
                Console.WriteLine("Number: " + i + " .Card's width: " + Width_Arr[i] + " .Card's height: " + Height_Arr[i] + " .Card's color: " + Color_Arr[i] + " .Distance: " + iTemp_Min);
            }
            Console.WriteLine("Your card's width is: " + user_width + " .Your card's height: " + user_height + " .Your card's color is maybe: " + Color_Arr[iPosi] + "\n");
        }
    }
}
