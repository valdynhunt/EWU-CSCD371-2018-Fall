using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;

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
        public void GoPlayer_choice_rock_returns_rock()
        {
            var sut = new Roshambo();
            string response = "rock";
            string view = $@">>*Please enter your move (rock, paper, scissors):
<<{response}
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(); });
        }

        [TestMethod]
        public void GoPlayer_choice_paper_returns_paper()
        {
            var sut = new Roshambo();
            string response = "paper";
            string view = $@">>*Please enter your move (rock, paper, scissors):
<<{response}
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(); });
        }

        [TestMethod]
        public void GoPlayer_choice_scissors_returns_scissors()
        {
            var sut = new Roshambo();

            string response = "scissors";
            string view = $@">>*Please enter your move (rock, paper, scissors):
<<{response}
";

            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(); });
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
        public void GoComputer_returns_valid_selection()
        {
            var sut = new Roshambo();
            sut.InitializeHealth();
            string returnValue = sut.GoComputer();

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

        //[TestMethod]
        //public void zGameLoop_()
        //{
        //    var sut = new Roshambo();
        //    sut.GameLoop();

        //}

        //========================================================================================
        //========================================================================================

        //        [TestMethod]
        //        public void zGetMoves_returns_valid_tuple_of_moves()
        //        {
        //            var stringBuilder = new StringBuilder();
        //            var outputWriter = new StringWriter(stringBuilder);
        //            Console.SetOut(outputWriter);

        //            var sut = new Roshambo();
        //            var testVariable = sut.GetMoves();

        //            string move1 = testVariable.Item1;
        //            string move2 = testVariable.Item2;

        //            bool move1IsValid = ((move1.Equals("rock"))
        //                || (move1.Equals("paper")) || (move1.Equals("scissors")));
        //            bool move2IsValid = ((move2.Equals("rock"))
        //                || (move2.Equals("paper")) || (move2.Equals("scissors")));


        //            string response = "scissors";
        //            string view = $@">>*Please enter your move (rock, paper, scissors):
        //<<{response}
        //";
        //            stringBuilder.Append(view);

        //            string output = stringBuilder.ToString();

        //            Assert.IsTrue(move1IsValid);
        //            Assert.IsTrue(move2IsValid);
        //            Assert.Equals(testVariable, response);
        //            Assert.Equals(view, output);
        //            //IntelliTect.TestTools.Console.ConsoleAssert.Expect("", () => { sut.GetMoves(); });
        //        }

        //========================================================================================
        //========================================================================================



        //========================================================================================
        //========================================================================================

        //        [TestMethod]
        //        public void zGoPlayer_choice_rock_returns_rock2()
        //        {
        //            var sut = new Roshambo();
        //            string response = "rock";
        //            string view = $@">>*Please enter your move (rock, paper, scissors):
        //<<{response}
        //";
        //            //string returnValue = sut.GoPlayer();
        //            //Assert.AreEqual(response, returnValue);
        //            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(); });

        //            // Question - at this point, I am not testing what is returned from the method.
        //            // Given IntelliTect syntax and MS Test, how would I structure the syntax to test the 
        //            // actual return value....with the console interaction I could only think of how to test
        //            // what is seen (view) as the interaction leading to the return...
        //        }

        //========================================================================================
        //========================================================================================

    }
}


