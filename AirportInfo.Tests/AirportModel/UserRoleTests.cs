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
    public class UserRoleTests
    {
        [TestMethod()]
        public void DeleteTest()
        {
            UserRole userRole = new UserRole();
            userRole.UserRoleName = "dd";
            userRole.UserRoleDesc = "ddd";
            Assert.AreEqual(userRole.Delete(), true);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.AreEqual(new UserRole().GetAll(),true);
        }

        [TestMethod()]
        public void InsertTest()
        {
            UserRole userRole = new UserRole();
            userRole.UserRoleName = "dd";
            userRole.UserRoleDesc = "dddd";
            Assert.AreEqual(userRole.Insert(),true);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            UserRole userRole = new UserRole();
            userRole.UserRoleName = "dd";
            userRole.UserRoleDesc = "ddd";
            Assert.AreEqual(userRole.Update(), true);
        }
    }
}