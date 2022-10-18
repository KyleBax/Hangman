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

            string keepPlaying = "y";

            while (keepPlaying == "y")
            {
                NewRound();

                List<string> incorrectGuesses = new List<string>();

                List<string> correctGuesses = new List<string>();

                bool inSession = true;

                Random random = new();
                int index = random.Next(wordList.Count);
                string word = wordList[index];




                Console.WriteLine("Game " + games);


                while (inSession)
                {

                    Console.WriteLine("Your guesses so far");
                    foreach (string guess in incorrectGuesses)
                    {
                        Console.Write(guess + " ");

                    }
                    Space();


                    int success = word.Length;
                    for (int i = 1; i <= word.Length; i++)
                    {
                        char character = word[i - 1];
                        string letter = Char.ToString(character);
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
                    Space();

                    string input = Console.ReadLine().ToLower();

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
                    }

                }

                Console.WriteLine("Would you like to keep playing? Y/N");
                keepPlaying = Console.ReadLine().ToLower();
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
        /// Clears the precious round and welcomes you to the game
        /// </summary>
        static void NewRound()
        {
            Console.Clear();

            Console.WriteLine("Welcome to the gallows!");
            Console.WriteLine("It's up to you to save these poor souls!");
            Console.WriteLine("Can you do it before they all die?");
            Console.WriteLine("It's time to Hangman!!!!!");
        }
        /// <summary>
        /// used whenever a space is needed or a new line is needed in the text printed to the console
        /// </summary>
        static void Space()
        {
            Console.WriteLine(" ");
        }


    }
}