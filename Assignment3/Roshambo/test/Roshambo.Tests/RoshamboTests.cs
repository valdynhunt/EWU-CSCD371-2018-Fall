using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Roshambo.Tests
{
    [TestClass]
    public class RoshamboTests
    {

        [TestMethod]
        public void Constructor_invokes_GreetPlayer()
        {
            string view = "Welcome to Roshambo, also known as Rock, Paper, Scissors.";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view,
            () =>
            {
                new Roshambo();
            });
        }

        [TestMethod]
        public void GreetPlayer_invokes_greeting()
        {
            string view = "Welcome to Roshambo, also known as Rock, Paper, Scissors.";
            Roshambo rps = new Roshambo();

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view,
            () =>
            {
                rps.GreetPlayer();
            });
        }

        [TestMethod]
        public void InitializeHealth_sets_beginning_player_health()
        {
            Roshambo rps = new Roshambo();
            int beginningHealth = 100;
            rps.InitializeHealth();

            Assert.AreEqual(beginningHealth, rps.GetPlayerHealth());
        }

        [TestMethod]
        public void InitializeHealth_sets_beginning_computer_health()
        {
            Roshambo rps = new Roshambo();
            int beginningHealth = 100;
            rps.InitializeHealth();

            Assert.AreEqual(beginningHealth, rps.GetComputerHealth());
        }

        [TestMethod]
        public void GetPlayerMove_choice_rock_returns_rock()
        {
            var sut = new Roshambo();
            string response = "rock";
            string view = $@">>*Please enter your move (rock, paper, scissors):
<<{response}
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GetPlayerMove(); });
        }

        [TestMethod]
        public void GoPlayer_choice_rock_returns_rock()
        {
            var sut = new Roshambo();
            string selection = "rock";
            string response = sut.GoPlayer(selection);
            Assert.AreEqual(selection, response);
        }

        [TestMethod]
        public void GoPlayer_choice_paper_returns_paper()
        {
            var sut = new Roshambo();
            string selection = "paper";
            string response = sut.GoPlayer(selection);
            Assert.AreEqual(selection, response);
        }

        [TestMethod]
        public void GoPlayer_choice_scissors_returns_scissors()
        {
            var sut = new Roshambo();
            string selection = "scissors";
            string response = sut.GoPlayer(selection);
            Assert.AreEqual(selection, response);
        }

        [TestMethod]
        public void GoPlayer_choice_invalid_reprompts()
        {
            var sut = new Roshambo();
            string selection = "spock";
            string secondSelection = "paper";
            string view = $@">>Your move is invalid. Please enter your move again.
>>*Please enter your move (rock, paper, scissors):
<<{secondSelection}
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(selection); });
        }

        [TestMethod]
        public void PrintCurrentHealth_prints_player_and_computer_health()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();
            string view = $@">>
>>Player health: {sut.GetPlayerHealth()}
>>Computer health: {sut.GetComputerHealth()}
";
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.PrintCurrentHealth(); });
        }

        [TestMethod]
        public void GetCurrentHealth_returns_tuple_of_health_values()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            var tTuple = Tuple.Create<int, int>(sut.GetPlayerHealth(), sut.GetComputerHealth());

            Assert.AreEqual(tTuple, sut.GetCurrentHealth());
        }

        [TestMethod]
        public void GetNowSeconds_returns_int_seconds()
        {
            var sut = new Roshambo();
            int nowSeconds = sut.GetNowSeconds();

            Assert.AreEqual(DateTime.Now.Second, sut.GetNowSeconds());
        }

        [TestMethod]
        public void GoComputer_returns_rock()
        {
            var sut = new Roshambo();
            int nowSeconds = 3;
            string returnValue = sut.GoComputer(nowSeconds);

            bool returnedValueIsValid = (returnValue.Equals("rock")
                                        || returnValue.Equals("paper")
                                        || returnValue.Equals("scissors"));

            Assert.IsTrue(returnedValueIsValid);
        }

        [TestMethod]
        public void GoComputer_returns_paper()
        {
            var sut = new Roshambo();
            int nowSeconds = 2;
            string returnValue = sut.GoComputer(nowSeconds);

            bool returnedValueIsValid = (returnValue.Equals("rock")
                                        || returnValue.Equals("paper")
                                        || returnValue.Equals("scissors"));

            Assert.IsTrue(returnedValueIsValid);
        }

        [TestMethod]
        public void GoComputer_returns_scissors()
        {
            var sut = new Roshambo();
            int nowSeconds = 5;
            string returnValue = sut.GoComputer(nowSeconds);

            bool returnedValueIsValid = (returnValue.Equals("rock")
                                        || returnValue.Equals("paper")
                                        || returnValue.Equals("scissors"));

            Assert.IsTrue(returnedValueIsValid);
        }

        [TestMethod]
        public void AdjustScores_verify_player_wins_with_rock()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetComputerHealth() - 20;
            sut.AdjustScores("rock", true);
            Assert.AreEqual(expectedHealth, sut.GetComputerHealth());
        }

        [TestMethod]
        public void AdjustScores_verify_player_wins_with_paper()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetComputerHealth() - 10;
            sut.AdjustScores("paper", true);
            Assert.AreEqual(expectedHealth, sut.GetComputerHealth());
        }

        [TestMethod]
        public void AdjustScores_verify_player_wins_with_scissors()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetComputerHealth() - 15;
            sut.AdjustScores("scissors", true);
            Assert.AreEqual(expectedHealth, sut.GetComputerHealth());
        }

        [TestMethod]
        public void AdjustScores_verify_computer_wins_with_rock()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetPlayerHealth() - 20;
            sut.AdjustScores("rock", false);
            Assert.AreEqual(expectedHealth, sut.GetPlayerHealth());
        }

        [TestMethod]
        public void AdjustScores_verify_computer_wins_with_paper()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetPlayerHealth() - 10;
            sut.AdjustScores("paper", false);
            Assert.AreEqual(expectedHealth, sut.GetPlayerHealth());
        }

        [TestMethod]
        public void AdjustScores_verify_computer_wins_with_scissors()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();

            int expectedHealth = sut.GetPlayerHealth() - 15;
            sut.AdjustScores("scissors", false);
            Assert.AreEqual(expectedHealth, sut.GetPlayerHealth());
        }

        [TestMethod]
        public void PlayATurn_results_in_tie_if_both_play_rock()
        {
            var sut = new Roshambo();

            string pMove = "rock";
            string cMove = "rock";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("tie", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_results_in_tie_if_both_play_paper()
        {
            var sut = new Roshambo();

            string pMove = "paper";
            string cMove = "paper";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("tie", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_results_in_tie_if_both_play_scissors()
        {
            var sut = new Roshambo();

            string pMove = "scissors";
            string cMove = "scissors";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("tie", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_wins_with_rock_against_scissors()
        {
            var sut = new Roshambo();

            string pMove = "rock";
            string cMove = "scissors";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("player", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_loses_with_scissors_against_rock()
        {
            var sut = new Roshambo();

            string pMove = "scissors";
            string cMove = "rock";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("computer", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_wins_with_scissors_against_paper()
        {
            var sut = new Roshambo();

            string pMove = "scissors";
            string cMove = "paper";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("player", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_loses_with_paper_against_scissors()
        {
            var sut = new Roshambo();

            string pMove = "paper";
            string cMove = "scissors";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("computer", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_wins_with_paper_against_rock()
        {
            var sut = new Roshambo();

            string pMove = "paper";
            string cMove = "rock";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("player", returnedValue);
        }

        [TestMethod]
        public void PlayATurn_player_loses_with_rock_against_paper()
        {
            var sut = new Roshambo();

            string pMove = "rock";
            string cMove = "paper";

            var tMoves = Tuple.Create<string, string>(pMove, cMove);

            string returnedValue = sut.PlayATurn(tMoves);

            Assert.AreEqual("computer", returnedValue);
        }
        
    }
}


