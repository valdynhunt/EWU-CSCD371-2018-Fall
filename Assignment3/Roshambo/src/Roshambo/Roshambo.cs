using System;

namespace Roshambo
{
    public class Roshambo
    {
        private int playerHealth;
        private int computerHealth;
        private string playerMove;
        private string computerMove;
        private const int BeginningHealth = 100;
        private const string ROCK = "rock";
        private const string PAPER = "paper";
        private const string SCISSORS = "scissors";
       

        public Roshambo()
        {
            GreetPlayer();
        }

        public void GreetPlayer()
        {
            Console.WriteLine("Welcome to Roshambo, also known" +
    " as Rock, Paper, Scissors.");
        }

        public void InitializeHealth()
        {
            this.playerHealth = BeginningHealth;
            this.computerHealth = BeginningHealth;
        }

        public int GetPlayerHealth()
        {
            return this.playerHealth;
        }

        public int GetComputerHealth()
        {
            return this.computerHealth;
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
                InitializeHealth();
                Tuple<int, int> tCurrentHealth = GetCurrentHealth();
                Console.WriteLine("\nBeginning health:  " + tCurrentHealth.Item1 + " - player");
                Console.WriteLine("\t\t   " + tCurrentHealth.Item2 + " - computer");
                Console.WriteLine("\nIt's on like Donkey Kong...");

                while ((this.playerHealth > 0) && (this.computerHealth > 0))
                {
                    PlayATurn();
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

        public void PrintCurrentHealth()
        {
            Console.WriteLine("\nPlayer health: " + this.playerHealth);
            Console.WriteLine("Computer health: " + this.computerHealth);
        }

        public void PlayATurn()
        {
            this.playerMove = GoPlayer();
            this.computerMove = GoComputer();
            bool playerWinsTurn;

            Console.WriteLine("\nplayer move: " + playerMove + "\ncomputer move: " + computerMove);

            if (!playerMove.Equals(computerMove))
            {
                if (playerMove.Equals(ROCK))
                {
                    playerWinsTurn = (computerMove.Equals(SCISSORS)) ? true : false;
                }
                else if (playerMove.Equals(PAPER))
                {
                    playerWinsTurn = (computerMove.Equals(ROCK)) ? true : false;
                }
                else
                {
                    playerWinsTurn = (computerMove.Equals(PAPER)) ? true : false;
                }

                string winningObject = (playerWinsTurn == true) ? playerMove : computerMove;
                AdjustScores(winningObject, playerWinsTurn);

            }

        }

        public void AdjustScores(string winningObject, bool playerWinsTurn)
        {
            if (playerWinsTurn)
            {
                if (winningObject.Equals(ROCK))
                {
                    this.computerHealth -= 20;
                }
                else if (winningObject.Equals(PAPER))
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
                if (winningObject.Equals(ROCK))
                {
                    this.playerHealth -= 20;
                }
                else if (winningObject.Equals(PAPER))
                {
                    this.playerHealth -= 10;
                }
                else
                {
                    this.playerHealth -= 15;
                }
            }
        }

        public string GoComputer()
        {
            string play = "";
            DateTime dateTime = DateTime.Now;
            int nowSeconds = dateTime.Second;

            if (nowSeconds % 3 == 0)
            {
                play = ROCK;
            }
            else if (nowSeconds % 2 == 0)
            {
                play = PAPER;
            }
            else
            {
                play = SCISSORS;
            }

            return play;
        }

        public string GoPlayer()
        {
            bool responseIsInvalid = true;
            string response = "";

            Console.WriteLine("*Please enter your move (rock, paper, scissors):");

            while (responseIsInvalid)
            {
                response = Console.ReadLine();
                if (response.Equals(ROCK) 
                    || (response.Equals(PAPER)) 
                    || (response.Equals(SCISSORS)))
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


        public static void Main(string[] args)
        {
            Roshambo play = new Roshambo();
            play.GameLoop();
            Console.WriteLine("\nThanks for playing Roshambo :)");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
