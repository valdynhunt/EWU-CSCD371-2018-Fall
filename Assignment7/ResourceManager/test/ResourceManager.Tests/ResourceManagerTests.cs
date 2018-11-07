using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ResourceManager.Tests
{
    public class ResourceManagerTests
    {

        [TestMethod]
        public void UsingExample()
        {

            {
                using (ResourceManager myFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt"))
                using (ResourceManager mySecondFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile2.txt"))
                {
                    int i = 0;
                    int bad = 5 / i;
                }
            }

            {
                ResourceManager myThirdFileChecker = null;
                try
                {
                    // do stuff
                    myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile3.txt");


                    // something bad happens here and throws an exception
                }
                finally
                {
                    myThirdFileChecker?.Dispose();
                }

            }

            Console.WriteLine("To Infinity and Beyond...");

        } // end UsingExample

        [TestMethod]
        public void UsingExample2()
        {
            {
                ResourceManager myThirdFileChecker = null;
                try
                {
                    // do stuff
                    myThirdFileChecker = new ResourceManager(@"C:\ProgramData\Temp\testFile3.txt");
                    Assert.AreEqual(myThirdFileChecker.GetInstanceCount(), 1);

                    // something bad happens here and throws an exception
                }
                finally
                {
                    myThirdFileChecker?.Dispose();
                }

            }

            Console.WriteLine("To Infinity and Beyond...");

        } // end UsingExample2
    } // end class ResourceManagerTests
}
