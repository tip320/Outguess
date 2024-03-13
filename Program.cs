namespace Outguess {
    internal class Program {
        static void Main(string[] args) {

            //VARIABLES
            Random rndMaker = new Random();//random number generator
            int randNum = 0; //random number variable
            int numberOfGuesses = 0; //The amount of guesses the user would like to do
            int guess = 0; //The user guesses the number
            int guessWager = 0;//The multiplier that ties to numberOfGuesses
            double balance = 0; //The user's cash-in amount
            double balanceDifference = 0; //The balance after the user places their bet
            double bet = 0; //The amount the user will bet
            double winCounter = 0; //Adds one for every win condition
            double lossCounter = 0; //Adds one for every lose condition
            double playCounter = 0; //Adds one for every time the game is played
            double winPercentage = 0; //The number of wins divided by the number of plays times 100
            string playAgain = ""; //yes or no
            bool wannaPlay = true; //flag for playAgain

            Print("Welcome to Outguess: The Gambling Edition!");
            balance = InputDouble("Please enter your cash-in amount: $");

            //LOOP TO CONTROL GAME
            while (balance > 0 && wannaPlay) {

                numberOfGuesses = 10;
                Print($"You have ${balance} available.");
                bet = InputDouble("How much money would you like to wager on this try? $");
                if (bet <= 0) {
                    Print("You gotta bet something...Please try again");
                } else { 

                balanceDifference = balance - bet;

                    if (balanceDifference < 0) {
                        Print("Not enough money...Please try again");
                        Print("");
                    } else {
                        do {
                            Print(""); 
                            numberOfGuesses = InputInt("How many guesses do you need? (MAX 10): ");
                            if (numberOfGuesses <= 0 || numberOfGuesses > 10) {
                                Print("Invalid number...try again.");
                                Print("");
                            } else if (numberOfGuesses == 10) {
                                guessWager = 1;
                            } else if (numberOfGuesses == 9) {
                                guessWager = 2;
                            } else if (numberOfGuesses == 8) {
                                guessWager = 3;
                            } else if (numberOfGuesses == 7) {
                                guessWager = 4;
                            } else if (numberOfGuesses == 6) {
                                guessWager = 5;
                            } else if (numberOfGuesses == 5) {
                                guessWager = 6;
                            } else if (numberOfGuesses == 4) {
                                guessWager = 7;
                            } else if (numberOfGuesses == 3) {
                                guessWager = 8;
                            } else if (numberOfGuesses == 2) {
                                guessWager = 9;
                            } else if (numberOfGuesses == 1) {
                                guessWager = 10;
                            }
                        } while (numberOfGuesses <= 0 || numberOfGuesses > 10);


                        Print("");
                        randNum = rndMaker.Next(1, 201);
                        Print("I've chosen a secret number now guess it!");
                            do {
                                guess = InputInt("Enter your guess: ");
                                balance = balanceDifference;
                                if (guess > randNum) {
                                    numberOfGuesses--;
                                    Print($"Sorry, too high! You have {numberOfGuesses} guesses remaining.");
                                } else if (guess < randNum) {
                                    numberOfGuesses--;
                                    Print($"Sorry, too low! You have {numberOfGuesses} guesses remaining.");
                                }
                            } while (numberOfGuesses > 0 && guess != randNum);

                            if (guess == randNum) {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Print($"YOU WIN!!! My number was {randNum}! You just won ${bet * guessWager}!");
                                Console.ResetColor();
                                balance = bet * guessWager + balanceDifference;
                                winCounter++;
                                playCounter++;
                            } else {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Print($"You Lose! The correct number was {randNum}");
                                Console.ResetColor();
                                lossCounter++;
                                playCounter++;
                            }

                            if (balance > 0) {
                                do {
                                    Print($"You have ${balance}.");
                                    playAgain = Input("Would you like to play again? Y/N? ");
                                    playAgain = playAgain.ToLower();
                                    wannaPlay = playAgain == "y";
                                        if (playAgain != "y" && playAgain !="n") {
                                            Print("Invalid choice....try again");
                                            Print("");
                                        }
                                } while (playAgain != "y" && playAgain != "n");

                            } else {
                                Print("Sorry, you've run out of money.");
                            }//end if
                    }//END IF
                }//end if
            }//end while

        //GAME OVER 
        winPercentage = 100 * winCounter / playCounter;
        Print("");
            Console.ForegroundColor= ConsoleColor.DarkYellow;
        Print($"Thanks for playing Outguess! You have ${balance} for payout. I \"guess\" I'll see you next time!");
            Console.ResetColor();
        Print("__________________________________________________________________________________________________");
        Print($"Wins: {winCounter}");
        Print($"Losses: {lossCounter}");
        Print($"Games Played: {playCounter}");
        Print($"Win Percentage: {winPercentage}%");
            
            #region HELPER FUNCTIONS

            static string Input(string message) {
                Console.Write(message);
                return Console.ReadLine();
            }//end function

            static decimal InputDecimal(string message) {
                string value = Input(message);
                return decimal.Parse(value);
            }//end function

            static double InputDouble(string message) {
                string value = Input(message);
                return double.Parse(value);
            }//end function

            static int InputInt(string message) {
                string value = Input(message);
                return int.Parse(value);
            }//end function

            static string Print(string message) {
                Console.WriteLine(message);
                return message;
            }//end function

            static int Rand() {
                Random rand = new Random();
                return rand.Next(1, 201);
            }//end function
            #endregion

        }//end main
    }//end class
}//end namespace
