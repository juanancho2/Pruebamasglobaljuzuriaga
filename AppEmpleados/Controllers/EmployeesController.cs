using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppEmpleados.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeBL bl;
        public EmployeesController()
        {
            this.bl = new EmployeeBL();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployees()
        {
            var result = await this.bl.GetEmployeesAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            var result = await this.bl.GetEmployeesAsync();
            var employee = result.FirstOrDefault(emp => emp.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }
    }
}
