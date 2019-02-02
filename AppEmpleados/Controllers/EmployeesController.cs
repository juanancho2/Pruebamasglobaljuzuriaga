using BL;
using BL.Exceptions;
using Entities;
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
            return await processRequest<List<IEmployeeDTO>>(() => {
                return this.bl.GetEmployeesAsync();
            });
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            return await processRequest<IEmployeeDTO>(() => {
                return this.bl.GetEmployeeAsync(id);
            });
        }

        private async Task<IHttpActionResult> processRequest<T>(Func<Task<T>> getFunc)
        {
            try
            {
                var res = await getFunc();
                if (res == null)
                    return NotFound();
                return Ok(res);
            }
            catch (ParsingFailedException e)
            {
                // Se controla en caso de que se modifique la api: http://masglobaltestapi.azurewebsites.net/api/Employees
                return InternalServerError(e);
            }
            catch (Exception er)
            {
                // En caso de otra excepción, se retorna un error 500. Sin embargo no se dan detalles de la excepción.
                return InternalServerError();
            }
        }
    }
}
