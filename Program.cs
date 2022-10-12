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

            bool alive = true;

            Random random = new Random();
            int index = random.Next(wordList.Count);
            string word = wordList[index];
            Console.WriteLine(word);

            while (alive == true)
            {
                string guess = Console.ReadLine().ToLower();

                if (word.Contains(guess))
                {
                    Console.WriteLine("Well done");
                }

                if (word.Contains(guess) == false)
                {
                    Console.WriteLine("This word does not contain " + guess);
                }

                if (guess == word)
                {
                    Console.WriteLine("Congrats");
                }

            }






        }
    }
}