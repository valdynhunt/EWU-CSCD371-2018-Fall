using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManager.Tests
{
    [TestClass]
    public class GenericTypesTests
    {

        [TestMethod]
        public void Instantiate_ResourceManager_Gives_NonNull()
        {
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>();
            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
        }

        [TestMethod]
        public void Instantiation_Passing_In_Null_To_NonNullable_Gives_NonNull()
        {
            ResourceManager rm = null;
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);
            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
        }

        [TestMethod]
        public void Instantiation_Passing_In_Reference_To_NonNullable_Sets_Value_To_Ref()
        {
            ResourceManager rm = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);

            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
            Assert.AreEqual(rm, myNonNullable.Value);
        }

        [TestMethod]
        public void Getting_Value_From_NonNullable_Returns_T()
        {
            ResourceManager rm = new ResourceManager(@"C:\ProgramData\Temp\testFile1.txt");
            NonNullable<ResourceManager> myNonNullable = new NonNullable<ResourceManager>(rm);

            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);

            ResourceManager rm2 = myNonNullable.Value;

            Assert.AreEqual(rm, rm2);
            Assert.AreEqual(rm2.FileChecker, rm.FileChecker);
        }

    }
}
