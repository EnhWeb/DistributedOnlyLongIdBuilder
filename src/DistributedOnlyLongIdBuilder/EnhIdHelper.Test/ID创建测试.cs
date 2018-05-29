using System;
using System.Collections.Generic;
using EnhEnhIdWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnhIdHelper.Test
{
    [TestClass]
    public class ID创建测试
    {
        /// <summary>
        /// 动态生产有规律的ID Snowflake算法是Twitter的工程师为实现递增而不重复的ID实现的
        /// </summary>
        [TestMethod]
        public void EnhIdWork_ID生成测试1000W个ID()
        {
            var ids = new List<long>();
            for (int i = 0; i < 10000000; i++)//测试同时1000W有序ID
            {
                ids.Add(EnhIdWork.Instance().GetId());
            }
            for (int i = 0; i < ids.Count - 1; i++)
            {
                Assert.IsTrue(ids[i] < ids[i + 1]);
            }
        }

        [TestMethod]
        public void EnhIdWork_ID生成测试1000个ID()
        {
            var ids = new List<long>();
            for (int i = 0; i < 1000; i++)//测试同时1000有序ID
            {
                ids.Add(EnhIdWork.Instance().GetId());
            }

            for (int i = 0; i < ids.Count - 1; i++)
            {
                Assert.IsTrue(ids[i] < ids[i + 1]);
            }

            for(int i = 0; i < ids.Count - 1; i++)
            {
                Console.WriteLine($"ID：{ids[i]}，长度：{ids[i].ToString().Length}");
            }            
        }

        [TestMethod]
        public void EnhIdWork检查最大ID值()
        {
            string maxMachineId = $"EnhIdWork.maxMachineId:{EnhIdWork.maxMachineId}";
            string maxDatacenterId = $"EnhIdWork.maxDatacenterId:{EnhIdWork.maxDatacenterId}";

            Console.WriteLine(maxMachineId);
            Console.WriteLine(maxDatacenterId);

            Assert.IsTrue(5555 > EnhIdWork.maxMachineId);

            // Assert.Fail(maxMachineId);
        }
    }
}