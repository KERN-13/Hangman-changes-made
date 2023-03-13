using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Hangman!");
            // Create a dictionary of categories and their corresponding words.
            Dictionary<string, string[]> categories = new Dictionary<string, string[]>();
            categories["fruit"] = new string[] { "apple", "orange", "banana", "grape", "strawberry" };
            categories["vegetables"] = new string[] { "carrot", "tomato", "lettuce", "potato", "onion" };
            categories["animals"] = new string[] { "lion", "tiger", "elephant", "giraffe", "hippo" };

            // Set the number of remaining guesses to six (the number of body parts in a hangman drawing).
            int remainingGuesses = 6;
            Random rnd = new Random();

            while (true)
            {
                // Prompt the user to choose a category.
                Console.WriteLine("Choose a category: ");
                Console.WriteLine("1. Fruit");
                Console.WriteLine("2. Vegetables");
                Console.WriteLine("3. Animals");

                string input = Console.ReadLine();
                string chosenCategory;

                switch (input)
                {
                    case "1":
                        chosenCategory = "fruit";
                        break;
                    case "2":
                        chosenCategory = "vegetables";
                        break;
                    case "3":
                        chosenCategory = "animals";
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        return;
                }

               
                // Choose a random word from the selected category.
                string[] chosenWords = categories[chosenCategory];

                int index = rnd.Next(chosenWords.Length);
                string word = chosenWords[index];

                // Create an array of underscores the same length as the word, to track the user's progress.
                char[] progress = new char[word.Length];
                for (int i = 0; i < progress.Length; i++)
                {
                    progress[i] = '_';
                }



                // Keep looping until the user has either won or lost.
                while (true)
                {
                    // Print the current progress and remaining guesses.
                    Console.WriteLine(progress);
                    Console.WriteLine($"You have {remainingGuesses} guesses remaining.");

                    // Get the user's next guess.
                    Console.Write("Enter a letter: ");
                    char guess = Console.ReadLine().ToLower()[0];

                    // Check if the guess is in the word.
                    bool isCorrect = false;
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == guess)
                        {
                            progress[i] = guess;
                            isCorrect = true;
                        }
                    }

                    // If the guess was incorrect, decrement the remaining guesses.
                    if (!isCorrect)
                    {
                        remainingGuesses--;
                    }

                    // Check if the user has won or lost.
                    bool hasWon = !progress.Contains('_');

                    if (hasWon)
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                    else if (remainingGuesses == 0)
                    {
                        Console.WriteLine("You lose!");
                        break;
                    }
                }
                //check if user wants to play again. if not, break out of the loop.
                Console.WriteLine("Do you want to play again (y/n)? ");
                string playAgain = Console.ReadLine().ToLower();

                if (input != "y")
                {
                    break;
                }
            }
        }
    }
}