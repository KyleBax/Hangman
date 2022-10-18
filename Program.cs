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
                Console.Clear();

                Console.WriteLine("Welcome to the gallows!");
                Console.WriteLine("It's up to you to save these poor souls!");
                Console.WriteLine("Can you do it before they all die?");
                Console.WriteLine("It's time to Hangman!!!!!");

                List<string> incorrectGuesses = new List<string>();

                List<string> correctGuesses = new List<string>();

                bool inSession = true;

                Random random = new Random();
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
                    Console.WriteLine(" ");


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
                    Console.WriteLine(" ");

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
                        Console.WriteLine("Congrats, you win");
                        Console.WriteLine("The word was " + word);
                        games++;
                        inSession = false;
                    }


                    // want to increase dificulty by number of play throughs by reducing number of guesses available after each succesful game reseting on a failed game
                    if (incorrectGuesses.Count >= 10 - games)
                    {
                        Console.WriteLine("You have been hung!!!");
                        Console.WriteLine("The word was " + word);
                        inSession = false;
                    }

                }

                Console.WriteLine("Would you like to play again? Y/N");
                keepPlaying = Console.ReadLine().ToLower();
            }






        }


    }
}