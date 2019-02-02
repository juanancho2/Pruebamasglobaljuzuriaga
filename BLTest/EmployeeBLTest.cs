using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLTest
{
    [TestClass]
    class EmployeeBLTest
    {
        [TestMethod]
        public void GetEmployee_Test()
        {
            var bl = new EmployeeBL();
            var empId = 1;

            var employee = bl.GetEmployeeAsync(empId).Result;

            Assert.IsNotNull(employee);
        }
    }
}
