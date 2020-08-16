using System;
using InterfaceLearning;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Csharp.Tests
{
    [TestClass]
    public class DeskFanTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock =new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 0);
            Deskfan deskfan = new Deskfan(mock.Object);
            var expect = "Won't work.";
            var actual = deskfan.Work();
            Assert.AreEqual(expect, actual);
        }
        [TestMethod]
        public void PowerHighThan200()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 200);
            Deskfan deskfan = new Deskfan(mock.Object);
            var expect = "Waring!";
            var autual = deskfan.Work();
            Assert.AreEqual(expect, autual);
        }
    }
    //class PowerSupplyLowerThanZero : IPowerSupply
    //{
    //    public int GetPower()
    //    {
    //        return 0;
    //    }
    //}
    //class PowerSupplyLowerThan200 : IPowerSupply
    //{
    //    public int GetPower()
    //    {
    //        return 300;
    //    }
    //}
}
