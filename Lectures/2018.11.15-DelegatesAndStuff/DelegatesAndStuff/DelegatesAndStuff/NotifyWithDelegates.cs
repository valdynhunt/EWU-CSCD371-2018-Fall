using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesAndStuff
{
    [TestClass]
    public class NotifyWithDelegates
    {


        [TestMethod]
        public void Callback_GivenCallackDelegate()
        {
            Callback callback = new Callback();
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(callback.Notify);
            button.Click();
            Assert.IsTrue(callback.Called);
        }
        public bool Called { get; set; }
        public void Notify()
        {
            Called = true;
        }

        [TestMethod]
        public void Notify_GivenDelegate_Success()
        {
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(Notify);
            button.Click();
            Assert.IsTrue(Called);
        }

        [TestMethod]
        public void Callback_GivenTwoDelegate()
        {
            Callback callback = new Callback();
            ButtonWithDelegates button = new ButtonWithDelegates("Ok");
            button.Register(callback.Notify);
            button.Register(Notify);
            button.Click();
            Assert.IsTrue(callback.Called);
            Assert.IsTrue(Called);
        }
    }
}
