using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entities
{   

    /// <summary>
    /// Interface de empleados
    /// </summary>
    public interface IEmployeeDTO
    {
        int Id { get; set; }
        string Name { get; set; }
        string ContractTypeName { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        float HourlySalary { get; set; }
        float MonthtlySalary { get; set; }
        float AnnualSalary { get; }
    }
}
