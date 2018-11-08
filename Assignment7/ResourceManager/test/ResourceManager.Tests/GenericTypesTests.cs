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
        public void String_Instance_Defaults_Value_To_Null()
        {
            NonNullable<string> myNonNullable = new NonNullable<string>();
            Assert.IsNull(myNonNullable.Value);
            Assert.IsFalse(myNonNullable.HasValue);
        }

        [TestMethod]
        public void String_Instance_Explicit_Constructor_Sets_Value_To_NonNull()
        {
            NonNullable<string> myNonNullable = new NonNullable<string>("developer");
            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
        }

        [TestMethod]
        public void TestMethod1()
        {
            NonNullable<string> myNonNullable = new NonNullable<string>();
            Assert.IsNotNull(myNonNullable.Value);
            Assert.IsTrue(myNonNullable.HasValue);
        }
    }
}
