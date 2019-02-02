using DAL;
using Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EmployeeBL
    {
        private RestClient client;
        public EmployeeBL()
        {
            this.client = new RestClient();
            this.client.init("http://masglobaltestapi.azurewebsites.net");
        }

        public async Task<List<IEmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await this.client.Get<List<IEmployeeDTO>>("api/Employees", (stringContent) =>
            {
                return JsonConvert.DeserializeObject<List<IEmployeeDTO>>(stringContent, new EmployeeFactory());
            });
            return employees.ToList();
        }

        public async Task<IEmployeeDTO> GetEmployeeAsync(int id)
        {
            var employees = await this.client.Get<List<IEmployeeDTO>>("api/Employees", (stringContent) =>
            {
                return JsonConvert.DeserializeObject<List<IEmployeeDTO>>(stringContent, new EmployeeFactory());
            });
            return employees.FirstOrDefault(e => e.Id == id);
        }

    }
}
