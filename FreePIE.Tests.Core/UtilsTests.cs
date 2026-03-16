using System;
using System.Collections.Generic;
using System.Linq;
using FreePIE.Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreePIE.Tests.Core
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void GetTypes_ShouldReturnImplementations()
        {
            var types = Utils.GetTypes<ITestInterface>().ToList();

            Assert.IsTrue(types.Contains(typeof(TestImplementation)));
            Assert.IsFalse(types.Contains(typeof(ITestInterface)));
            Assert.IsFalse(types.Contains(typeof(AbstractImplementation)));
        }

        [TestMethod]
        public void GetAttributeImplementations_ShouldReturnAttributedTypes()
        {
            var implementations = Utils.GetAttributeImplementations<TestAttribute>();

            Assert.IsTrue(implementations.Values.Contains(typeof(AttributedClass)));
            Assert.AreEqual(1, implementations.Count);
            Assert.IsInstanceOfType(implementations.Keys.First(), typeof(TestAttribute));
        }
    }

    public interface ITestInterface { }
    public class TestImplementation : ITestInterface { }
    public abstract class AbstractImplementation : ITestInterface { }

    public class TestAttribute : Attribute { }

    [TestAttribute]
    public class AttributedClass { }
}
