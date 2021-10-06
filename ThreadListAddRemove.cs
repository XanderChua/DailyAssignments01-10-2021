using System;
using System.Collections.Generic;
using System.Threading;
//Write a program which operate on a List and Does addition and Removal. 
//It can be any List with any particular type. You have to spawn threads depending on user inputs which can add and remove from the original List.
namespace ThreadListAddRemove
{
    public class Fruits
    {
        public string fruitname { get; set; }
        public Fruits(string fruitname)
        {
            this.fruitname = fruitname;
        }
    }
    public class FruitsCollection<Tfruits>
    {
        private IList<Tfruits> _fruits;
        public IList<Tfruits> FruitsObj
        {
            get
            {
                if (_fruits == null)
                {
                    _fruits = new List<Tfruits>();
                }
                return _fruits;
            }
            set
            {
                _fruits = value;
            }
        }
        public void AddFruits(Tfruits tfruits)
        {
            FruitsObj.Add(tfruits);
        }
        public void RemoveFruits(Tfruits tfruits)
        {
            FruitsObj.Remove(tfruits);
        }
    }
    class ThreadClass
    {
        FruitsCollection<Fruits> listFruits = new FruitsCollection<Fruits>();
        public void CallThread()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("--Thread List Add Remove--");
                Console.WriteLine("1. Input fruits");
                Console.WriteLine("2. Remove fruits");
                Console.WriteLine("3. List fruits");
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                      {
                    case 1:
                        {
                            Thread tadd = new Thread(DisplayAdd);
                            tadd.Start();
                            tadd.Join();
                            break;
                        }
                    case 2:
                        {
                            Thread tremove = new Thread(DisplayRemove);
                            tremove.Start();
                            tremove.Join();
                            break;
                        }
                    case 3:
                        {
                            Thread tlist = new Thread(DisplayList);
                            tlist.Start();
                            tlist.Join();
                            break;
                        }
                }
            }
        }
        public void DisplayAdd()
        {            
            Console.WriteLine("Enter name of fruit to add:");
            string addFruits = Console.ReadLine();
            listFruits.AddFruits(new Fruits(addFruits));
            Console.WriteLine(addFruits + " is added to list.");
        }
        public void DisplayRemove()
        {
            Console.WriteLine("Enter name of fruit to remove:");
            string removeFruits = Console.ReadLine();
            for (int i = 0; i < listFruits.FruitsObj.Count; i++)
            {
                if (string.Equals(removeFruits, listFruits.FruitsObj[i].fruitname))
                {
                    listFruits.RemoveFruits(listFruits.FruitsObj[i]);
                }
            }
            Console.WriteLine(removeFruits + " is removed from list.");
        }
        public void DisplayList()
        {
            foreach (var fruits in listFruits.FruitsObj)
            {
                Console.WriteLine(fruits.fruitname);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {           
            ThreadClass threadClass = new ThreadClass();
            threadClass.CallThread();                  
        }
    }
}
