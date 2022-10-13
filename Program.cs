using System;
using System.Collections.Generic;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the gallows!");
            Console.WriteLine("It's up to you to save these poor souls!");
            Console.WriteLine("Can you do it before they all die?");
            Console.WriteLine("It's time to Hangman!!!!!");

            List<string> wordList = new List<string>();
            wordList.Add("analysis");
            wordList.Add("blackmail");
            wordList.Add("kitchen");
            wordList.Add("cast");
            wordList.Add("superintendent");
            wordList.Add("legislation");
            wordList.Add("problem");
            wordList.Add("bare");
            wordList.Add("take");
            wordList.Add("cycle");

            string keepPlaying = "y";

            while (keepPlaying == "y")
            {
                Console.Clear();

                List<string> guesses = new List<string>();

                bool alive = true;

                Random random = new Random();
                int index = random.Next(wordList.Count);
                string word = wordList[index];

                //to be removed after everything else is working
                Console.WriteLine(word);

                //may not be needed, added as I was thinking of how to display the word length
                int length = word.Length;
                Console.WriteLine(length);




                while (alive == true)
                {
                    string input = Console.ReadLine().ToLower();




                    if (word.Contains(input))
                    {
                        Console.WriteLine("Well done, this word contains " + input);
                    }

                    if (word.Contains(input) == false)
                    {
                        Console.WriteLine("This word does not contain " + input);
                        guesses.Add(input);

                    }

                    if (input == word)
                    {
                        Console.WriteLine("Congrats");
                        alive = false;
                    }

                    Console.WriteLine("Your guesses so far");
                    foreach (string guess in guesses)
                    {
                        Console.Write(guess + " ");

                    }
                    Console.WriteLine(" ");

                    if (guesses.Count == 10)
                    {
                        Console.WriteLine("You have been hung!!!");
                        break;
                    }

                }

                Console.WriteLine("Would you like to play again? Y/N");
                keepPlaying = Console.ReadLine().ToLower();
            }






        }
    }
}