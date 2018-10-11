using IntelliTect.TestTools.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Roshambo.Tests
{
    [TestClass]
    public class RoshamboTests
    {
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
        public void GameLoop_()
        {
        }

        [TestMethod]
        public void PlayATurn_()
        {
        }

        //========================================================================================
        //========================================================================================

        [TestMethod]
        public void GoPlayer_choice_rock_returns_rock2()
        {
            var sut = new Roshambo();
            string response = "rock";
            string view = $@">>*Please enter your move (rock, paper, scissors):
<<{response}
";
            //string returnValue = sut.GoPlayer();
            //Assert.AreEqual(response, returnValue);
            IntelliTect.TestTools.Console.ConsoleAssert.Expect(view, () => { sut.GoPlayer(); });

            // Question - at this point, I am not testing what is returned from the method.
            // Given IntelliTect syntax and MS Test, how would I structure the syntax to test the 
            // actual return value....with the console interaction I could only think of how to test
            // what is seen (view) as the interaction leading to the return...
        }

        //========================================================================================
        //========================================================================================

    }
}


