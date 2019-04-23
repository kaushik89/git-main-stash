using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Welcome to MasterMind-------------------------");
            string quit = string.Empty;
            while (!quit.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                int guessCount = 1;
                Console.WriteLine("Guess the number");
                string randomString = GetRandomString();
                string userInput = Console.ReadLine(); ;
                while (guessCount <= 10)
                {
                    if (!ValidateNumber(randomString, userInput))
                    {
                        guessCount++;
                        Console.WriteLine("Try again or Press Q to Quit the game.");
                    }
                    else
                    {
                        Console.WriteLine("You Won. Press any key to play again. Press Q to Quit the game.");
                    }

                    userInput = Console.ReadLine();
                    if (userInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
                    {
                        quit = userInput;
                        break;
                    }
                }

                if (userInput.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    quit = userInput;
                }
                else if (guessCount > 10)
                {
                    Console.WriteLine("You lost the game. Press any key to play again. Press Q to Quit the game. ");
                    quit = Console.ReadLine();
                }
            }
        }

        public static bool ValidateNumber(string source, string guess)
        {
            var plusString = string.Empty;
            var minusStrign = string.Empty;

            if (source == guess)
            {
                return true;
            }
            if (guess.Length != 4)
            {
                Console.WriteLine("The guess should contain 4 characters");
                return false;
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] == guess[i])
                {
                    plusString += "+";
                }
                else if (guess.Contains(source[i]))
                {
                    minusStrign += "-";
                }
            }

            Console.WriteLine("Hint: " + plusString + minusStrign);
            return false;
        }

        /// <summary>
        /// Generates a string with characters non-repeating
        /// </summary>
        /// <returns></returns>
        public static string GetRandomString()
        {
            var chars = "123456";
            var stringChars = new char[4];
            var random = new Random();

            int i = 0;
            while (i < stringChars.Length)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
                i++;
            }

            return new String(stringChars);
        }
    }
}
