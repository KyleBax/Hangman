using System;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            int games = 1;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                Random random = new();
                int index = random.Next(wordList.Count);
                string word = wordList[index];
                List<string> incorrectGuesses = new List<string>();
                List<string> correctGuesses = new List<string>();
                bool inSession = true;
                int tries = 11 - games;

                NewRound(games, tries);

                while (inSession)
                {
                    Console.WriteLine("Attempts left " + (tries - incorrectGuesses.Count));
                    Console.WriteLine("Your guesses so far:");
                    foreach (string guess in incorrectGuesses)
                    {
                        Console.Write(guess + " ");
                    }
                    Console.WriteLine(" ");

                    int success = word.Length;
                    for (int i = 1; i <= word.Length; i++)
                    {
                        string letter = word[i - 1].ToString();
                        if (correctGuesses.Contains(letter))
                        {
                            Console.Write(letter + " ");
                            success--;
                        }
                        else
                        {
                            Console.Write("_ ");
                        }
                    }
                    Console.WriteLine(" ");

                    string input = Console.ReadLine().ToLower();
                    if (correctGuesses.Contains(input) || incorrectGuesses.Contains(input))
                    {
                        Console.WriteLine("You have already guessed " + input + ", try a different letter.");
                    }
                    else
                    {
                        if (word.Contains(input))
                        {
                            Console.WriteLine("Well done, this word contains " + input);
                            correctGuesses.Add(input);
                        }
                        else
                        {
                            Console.WriteLine("This word does not contain " + input);
                            incorrectGuesses.Add(input);
                        }
                    }


                    if (success == 1)
                    {
                        Finish("Congrats, you win!!", word);
                        games++;
                        inSession = false;
                    }
                    if (incorrectGuesses.Count >= 11 - games)
                    {
                        Finish("You have been hung!!", word);
                        games = 1;
                        inSession = false;
                    }
                }
                Console.WriteLine("Would you like to keep playing? Y/N");
                keepPlaying = (Console.ReadLine().ToLower() == "y");
            }
        }
        /// <summary>
        /// Writes a line telling you if you win or lose
        /// </summary>
        /// <param name="first">first line telling you if you win or lose</param>
        /// <param name="second">The word the was being guessed</param>
        static void Finish(string first, string second)
        {
            Console.WriteLine(first);
            Console.WriteLine("The word was " + second);
        }
        /// <summary>
        /// Clears the previous round and welcomes you to the game, tells you which round you're on and how many mistakes you can make
        /// </summary>
        /// <param name="round">int to tell you the round and how many mistakes you can make</param>
        static void NewRound(int round, int tries)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the gallows!");
            Console.WriteLine("It's up to you to save these poor souls!");
            Console.WriteLine("Can you do it before they all die?");
            Console.WriteLine("It's time to Hangman!!!!!");
            Console.WriteLine("Round " + round);
            Console.WriteLine("You have " + (tries) + " wrong guesses before they hang");
        }
    }
}