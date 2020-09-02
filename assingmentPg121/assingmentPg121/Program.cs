using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assingmentPg121
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Guess what animal is my favorite?");
            string animal = Console.ReadLine();
            bool isAnimal = animal == "dog";

            do
            {
                switch (animal)
                {
                    case "cat":
                        Console.WriteLine("You guessed Cat. Try again.");
                        Console.WriteLine("Guess what animal is my favorite?");
                        animal = Console.ReadLine();
                        break;
                    case "horse":
                        Console.WriteLine("You guessed Horse. Try again.");
                        Console.WriteLine("Guess what animal is my favorite?");
                        animal = Console.ReadLine();
                        break;
                    case "lion":
                        Console.WriteLine("You guessed Lion. Try again.");
                        Console.WriteLine("Guess what animal is my favorite?");
                        animal = Console.ReadLine();
                        break;
                    case "dog":
                        Console.WriteLine("You guessed Dog as my favorite animal. That is correct!");
                        isAnimal = true;
                        break;
                    default:
                        Console.WriteLine("You are wrong. Try again!");
                        Console.WriteLine("Guess what animal is my favorite?");
                        animal = Console.ReadLine();
                        break;
                }
            }
            while (!isAnimal);


            Console.ReadLine();
        }
    }
}
