using System;

namespace Hangman
{
    internal class Program
    {
        static readonly int TRIES = 11;
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
            wordList.Add("fail");
            wordList.Add("spirit");
            wordList.Add("cover");
            wordList.Add("volunteer");
            wordList.Add("position");
            wordList.Add("omission");
            wordList.Add("factor");
            wordList.Add("bronze");
            wordList.Add("grounds");
            wordList.Add("harm");

            int round = 1;
            bool keepPlaying = true;

            while (keepPlaying)
            {
                Random random = new();
                int index = random.Next(wordList.Count);
                string word = wordList[index];
                List<string> incorrectGuesses = new List<string>();
                List<string> correctGuesses = new List<string>();
                bool inSession = true;
                int wrongAttempts = TRIES - round;

                NewRound(round, wrongAttempts);

                while (inSession)
                {
                    Console.WriteLine("Attempts left " + (wrongAttempts - incorrectGuesses.Count));
                    Console.WriteLine("Your guesses so far:");
                    foreach (string guess in incorrectGuesses)
                    {
                        Console.Write(guess + " ");
                    }
                    Console.WriteLine(" ");

                    int lettersRemaining = word.Length;
                    for (int i = 0; i < word.Length; i++)
                    {
                        string letter = word[i].ToString();
                        if (correctGuesses.Contains(letter))
                        {
                            Console.Write(letter + " ");
                            lettersRemaining--;
                        }
                        else
                        {
                            Console.Write("_ ");
                        }
                    }
                    Console.WriteLine(" ");

                    if (lettersRemaining == 0)
                    {
                        Finish("Congrats, you win!!", word);
                        round++;
                        inSession = false;
                    }
                    if (incorrectGuesses.Count >= TRIES - round)
                    {
                        Finish("You have been hung!!", word);
                        round = 1;
                        inSession = false;
                    }

                    if (inSession)
                    {
                        string input = Console.ReadLine();
                        if (String.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Can not be blank");
                        }
                        else
                        {
                            input = input.Substring(0, 1).ToLower();
                            if (Char.IsLetter(input, 0))
                            {
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
                            }
                            else
                            {
                                Console.WriteLine("Please enter a letter next time.");
                            }
                        }
                    }
                }
                Console.WriteLine("Would you like to keep playing? Y/N");
                keepPlaying = (Console.ReadLine().ToLower() == "y");
            }
        }
        /// <summary>
        /// Writes a line telling you if you win or lose
        /// </summary>
        /// <param name="winOrLose">first line telling you if you win or lose</param>
        /// <param name="word">The word the was being guessed</param>
        static void Finish(string winOrLose, string word)
        {
            Console.WriteLine(winOrLose);
            Console.WriteLine("The word was " + word);
        }
        /// <summary>
        /// Clears the previous round and welcomes you to the game, tells you which round you're on and how many mistakes you can make
        /// </summary>
        /// <param name="round">which round of the game you are on</param>
        /// <param name="wrongAttempts">how many incorrect guesses you have</param>
        static void NewRound(int round, int wrongAttempts)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the gallows!");
            Console.WriteLine("It's up to you to save these poor souls!");
            Console.WriteLine("Can you do it before they all die?");
            Console.WriteLine("It's time to Hangman!!!!!");
            Console.WriteLine("Round " + round);
            Console.WriteLine("You have " + (wrongAttempts) + " wrong guesses before they hang");
        }
    }
}