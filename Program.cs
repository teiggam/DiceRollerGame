using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CasinoDiceRoller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, welcome to Six Tepid Breezes Casino Dice Rolling Game! \n");

            bool goOn = true;
            while (goOn == true)
            {
                try
                {
                    string input = GetUserInput("How many sides would you like your dice to have?");
                    int sidesOfDice = int.Parse(input);
                    if(sidesOfDice == 0)
                    {
                        Console.WriteLine("Number of sides must be greater than 0. Please try again. \n");
                        goOn = true;
                        continue;
                    }

                    int diceOne = GetRandomDice(1, sidesOfDice);
                    int diceTwo = GetRandomDice(1, sidesOfDice);
                    int total = diceOne + diceTwo;
                    Console.WriteLine($"You rolled a {diceOne} and {diceTwo}.  Total ({total})");

                    if (sidesOfDice == 6)
                    {
                        if (diceOne == 1 && diceTwo == 1)
                        {
                            Console.WriteLine("Snake Eyes!");
                        }
                        else if (diceOne == 1)
                        {
                            if (diceTwo == 2)
                            {
                                Console.WriteLine("Ace Deuce!");
                            }

                        }
                        else if (diceOne == 2)
                        {
                            if (diceTwo == 1)
                            {
                                Console.WriteLine("Ace Deuce!");
                            }

                        }
                        else if (diceOne == 6 && diceTwo == 6)
                        {
                            Console.WriteLine("Box Cars!");
                        }

                    }
                    if (sidesOfDice == 6 && total == 7 || total == 11)
                    {
                        Console.WriteLine("Win!");
                    }
                    else if (sidesOfDice == 6 && total == 2 || total == 3 || total == 12)
                    {
                        Console.WriteLine("Craps!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You have not entered an integer.  Please try again \n");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number you entered is too big.  Please try again. \n");
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("The number must be a positive integer.  Please try again. \n");
                    continue;
                }
                goOn = GetContinue();
            }
        }


        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine();
            return response;
        }

        public static int GetRandomDice(int min, int max)
        {
                Random random = new Random();
                int dice = random.Next(min, max + 1);
                return dice;
        }
        public static bool GetContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to roll again? y/n");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.Write("Thanks for playing!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand your response, please try again...");
            }
            return GetContinue();

        }
    }
}



