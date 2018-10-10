using System;

namespace Roshambo
{
    class Roshambo
    {
        private int playerHealth;
        private int computerHealth;
        private string playerMove;
        private string computerMove;
        private const int BeginningHealth = 100;
       

        public Roshambo()
        {
            Console.WriteLine("Welcome to Roshambo, also known" +
                " as Rock, Paper, Scissors.");

            this.playerHealth = 0;
            this.computerHealth = 0;
        }

        public void InitializeScores()
        {
            this.playerHealth = BeginningHealth;
            this.computerHealth = BeginningHealth;
        }

        public Tuple<int, int> GetCurrentHealth()
        {
            var tCurrentHealth = Tuple.Create<int, int>(this.playerHealth, this.computerHealth);
            return tCurrentHealth;
        }

        public void GameLoop()
        {
            bool anotherGame = false;
            do
            {
                InitializeScores();
                Tuple<int, int> tCurrentHealth = GetCurrentHealth();
                Console.WriteLine("\nBeginning health:  " + tCurrentHealth.Item1 + " - player");
                Console.WriteLine("\t\t   " + tCurrentHealth.Item2 + " - computer");
                Console.WriteLine("\nIt's on like Donkey Kong...");

                while ((this.playerHealth > 0) && (this.computerHealth > 0))
                {
                    playATurn();
                    tCurrentHealth = GetCurrentHealth();
                    Console.WriteLine("\nCurrent health:  " + tCurrentHealth.Item1 + " - player");
                    Console.WriteLine("\t\t " + tCurrentHealth.Item2 + " - computer");
                }

                string winner = (playerHealth > 0) ? "Player" : "Computer";
                Console.WriteLine(winner + " wins!");

                Console.Write("Would you like to play another game? (y/n): ");
                string response = Console.ReadLine();
                anotherGame = (response.Equals("y")) ? true : false;
            } while (anotherGame);
        }

        private void printCurrentScores()
        {
            Console.WriteLine("\nPlayer health: " + this.playerHealth);
            Console.WriteLine("Computer health: " + this.computerHealth);
        }

        private void playATurn()
        {
            this.playerMove = goPlayer();
            this.computerMove = goComputer();
            bool playerWinsTurn;

            Console.WriteLine("\nplayer move: " + playerMove + "\ncomputer move: " + computerMove);

            if (!playerMove.Equals(computerMove))
            {
                if (playerMove.Equals("rock"))
                {
                    playerWinsTurn = (computerMove.Equals("scissors")) ? true : false;
                }
                else if (playerMove.Equals("paper"))
                {
                    playerWinsTurn = (computerMove.Equals("rock")) ? true : false;
                }
                else
                {
                    playerWinsTurn = (computerMove.Equals("paper")) ? true : false;
                }

                string winningObject = (playerWinsTurn == true) ? playerMove : computerMove;
                adjustScores(winningObject, playerWinsTurn);

            }

        }

        private void adjustScores(string winningObject, bool playerWinsTurn)
        {
            if (playerWinsTurn)
            {
                if (winningObject.Equals("rock"))
                {
                    this.computerHealth -= 20;
                }
                else if (winningObject.Equals("paper"))
                {
                    this.computerHealth -= 10;
                }
                else
                {
                    this.computerHealth -= 15;
                }
            }
            else
            {
                if (winningObject.Equals("rock"))
                {
                    this.playerHealth -= 20;
                }
                else if (winningObject.Equals("paper"))
                {
                    this.playerHealth -= 10;
                }
                else
                {
                    this.playerHealth -= 15;
                }
            }
        }

        private string goComputer()
        {
            string play = "";
            DateTime dateTime = DateTime.Now;
            int nowSeconds = dateTime.Second;

            if (nowSeconds % 3 == 0)
            {
                play = "rock";
            }
            else if (nowSeconds % 2 == 0)
            {
                play = "paper";
            }
            else
            {
                play = "scissors";
            }

            return play;
        }

        private string goPlayer()
        {
            bool responseIsInvalid = true;
            string response = "";

            Console.Write("\n * Please enter your move (rock, paper, scissors): ");

            while (responseIsInvalid)
            {
                response = Console.ReadLine();
                if (response.Equals("rock") || response.Equals("paper") || response.Equals("scissors"))
                {
                    responseIsInvalid = false;
                }
                else
                {
                    Console.Write("Your move is invalid. Please enter your move again: ");
                }
            }
            return response;
        }

        private static void PlayGame()
        {
            Roshambo play = new Roshambo();
            play.GameLoop();
            Console.WriteLine("\nThanks for playing Roshambo :)");
        }

        static void Main(string[] args)
        {
            PlayGame(); // initialize class + do while
        }


    }
}
