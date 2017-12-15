using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportData.Tests
{
    [TestClass()]
    public class TerminalTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "G";
            Assert.AreEqual(temp.Delete(), true);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.AreEqual(new Terminal().GetAll(),true);
        }

        [TestMethod()]
        public void InsertTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "F";
            Assert.AreEqual(temp.Insert(), true);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Terminal temp = new Terminal();
            temp.TerminalCode = "G";
            temp.TerminalCodeOld = "F";
            Assert.AreEqual(temp.Update(), true);
        }
    }
}