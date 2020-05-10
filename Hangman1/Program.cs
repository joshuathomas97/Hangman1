/* Application comments:
 -draw hangman if bothered.
 */

using System;
using System.IO.Pipes;
using System.Linq;
using System.Text;

namespace Hangman1
{
    class Program
    {
        static void Main()
        {
            
            int lives = 3;
            char[] letters = new char[26];
            int nletter = 0;
            bool restart = false;
            do
            {
                Random rnd = new Random(); //creates an instance of the random class
                string[] RandNames = { "yellow", "orange", "blue", "purple" }; //set possible names
                string word = RandNames[rnd.Next(RandNames.Length)]; //randomely selects name from above list
                StringBuilder ToDisplay = new StringBuilder();

                for (int i = 0; i < word.Length; i++)
                {
                    ToDisplay.Append("-");
                }
                Console.WriteLine("Guess a letter. You have {0} lives. At anytime type 'exit' to leave.", lives);
                Console.WriteLine(ToDisplay);

                do
                {

                    string guess = Console.ReadLine();

                    if (guess.Length != 1 && guess != "exit" || Char.IsLetter(guess[0]) == false) //checks if it is a letter
                    {
                        Console.WriteLine("You must enter only one letter or 'exit'. \n");
                    }

                    else
                    {


                        if (guess == "exit")
                        {
                            Environment.Exit(0);
                        }
                        char chguess = Convert.ToChar(guess);

                        if (letters.Contains(chguess))
                        {
                            Console.WriteLine("You have already guessed {0}", guess);
                            Console.WriteLine(ToDisplay);
                            continue;
                        }
                        else
                        {
                            letters[nletter] = chguess;
                            nletter++;
                        }





                        if (word.ToLower().Contains(guess))
                        {

                            for (int counter = 0; counter < word.Length; counter++)
                            {
                                //Console.WriteLine(counter);
                                if (word[counter] == chguess)
                                {
                                    ToDisplay[counter] = Convert.ToChar(guess);
                                }
                            }
                            Console.WriteLine("Correct! Guess another letter!");
                            Console.WriteLine(ToDisplay);


                            //int index = word.IndexOf(guess);

                            //int index2 = guess.IndexOf(word);
                            //Console.WriteLine("new method {0}", index2);
                        }
                        else
                        {
                            lives--;
                            Console.WriteLine("Incorrect! You have {0} lives left. \n", lives);
                        }
                        // l comes at as 1,want 2. u comes up as 2, want to be 5


                        if (ToDisplay.ToString().ToLower().Contains("-"))
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("You have won!");
                            break;
                        }
                    }


                } while (lives > 0);
                Console.WriteLine("Play again? Type 'yes' to play again.");
                //string ans = Console.ReadLine();
                if(Console.ReadLine() == "yes")
                {
                    restart = true;
                }
                else { restart = false; }

            } while (restart == true);
        }
        
    }   
}
