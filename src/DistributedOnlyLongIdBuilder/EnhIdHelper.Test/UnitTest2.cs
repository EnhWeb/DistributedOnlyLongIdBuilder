using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnhIdHelper.Test
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Guid guid = Guid.NewGuid();
            byte[] bytes = guid.ToByteArray();

            Console.WriteLine(guid);
            Console.WriteLine(bytes);
            Console.WriteLine(BitConverter.ToInt64(bytes, 0));

            Assert.IsTrue(false);
        }
    }
}