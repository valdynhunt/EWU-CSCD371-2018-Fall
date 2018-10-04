using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MathExpressions.Tests
{
    [TestClass]
    public class StringTests
    {
        [TestMethod]
        public void String_trim_property_returns_a_trimmed_string()
        {
            Assert.AreEqual("Design", " Design ".Trim());
            Assert.AreEqual("Move", "Move  ".Trim());
            Assert.AreEqual("here", "here".Trim());
        }

        [TestMethod]
        public void String_toupper_property_returns_string_all_caps()
        {
            Assert.AreEqual("DESIGN", "Design".ToUpper());
            Assert.AreEqual("RECORD", "reCoRd".ToUpper());
            Assert.AreEqual("A", "a".ToUpper());
        }

        [TestMethod]
        public void String_tolower_property_returns_string_all_lowercase()
        {
            Assert.AreEqual("design", "DESIGN".ToLower());
            Assert.AreEqual("record", "reCoRd".ToLower());
            Assert.AreEqual("a", "A".ToLower());
        }

        [TestMethod]
        public void String_length_property_returns_length_of_string()
        {
            Assert.AreEqual(6, "Design".Length);
            Assert.AreEqual(2, "go".Length);
            Assert.AreEqual(0, "".Length);
        }

        [TestMethod]
        public void String_endswith_property_returns_true_if_string_ends_in_selected_string()
        {
            string end = "ing";
            Assert.AreEqual(true, "moving".EndsWith(end));
            Assert.AreEqual(true, "sing".EndsWith(end));
        }

        [TestMethod]
        public void String_endswith_property_returns_false_if_string_does_not_end_in_selected_string()
        {
            string end = "ing";
            Assert.AreEqual(false, "move".EndsWith(end));
            Assert.AreEqual(false, "wanderings".EndsWith(end));
        }
    }
}
