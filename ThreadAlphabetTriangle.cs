using System;
using System.Threading;

namespace ThreadAlphabetTriangle
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
                Console.WriteLine("Enter number from 1 to 26: ");
                int input = Int32.Parse(Console.ReadLine());
                for(int i = 1; i < input+1; i++)
                {
                    for(int j = 1; j < input+1 - i; j++)//every loop space decrease 1
                    {
                        Console.Write(" ");
                    }
                    char incline = 'A';
                    Thread.Sleep(1000);
                    for (int k = 1; k <= i; k++)
                    {
                        Console.Write(incline++);
                    }
                    char decline = (char)(incline - 2);
                    for (int l = 1; l < i; l++)
                    {
                        Console.Write(decline--);
                    }
                    Console.Write("\n");
                }              
            }           
        }
    }
}
