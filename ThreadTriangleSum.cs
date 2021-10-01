using System;
using System.Threading;

namespace ThreadTriangleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadClass t = new ThreadClass();
            t.Callthread();

        }
        class ThreadClass
        {
            public void Callthread()
            {
                Thread t = new Thread(Display);
                t.Start();
            }
            public void Display()
            {               
                Console.WriteLine("Enter the limit: ");
                int input = Int32.Parse(Console.ReadLine());
                int[] numArray = new int[input+1];
                for (int i = 1; i < numArray.Length; i++)
                {
                    for(int j = 1; j <= i; j++)
                    {
                        Thread.Sleep(300);
                        Console.Write(IdkWhatMethodIsThiszxc(j) + " ");
                    }
                    Console.Write("\n");
                    Thread.Sleep(1000);
                }
            }
            static int IdkWhatMethodIsThiszxc(int number)
            {
                int first = 0;
                int second = 1;
                int result = 0;
                if (number == 0)
                {
                    return number;
                }
                if (number == 1)
                {
                    return number;
                }
                for (int i = 2; i <= number; i++)  
                {
                    result = first + second;
                    first = second;
                    second = result;
                }
                return result;
            }
        } 
    }
}
