using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Entities
{
    /// <summary>
    ///  Representación empleado con salario mensual
    /// </summary>
    [DataContract]
    public class MonthlyEmployeeDTO: IEmployeeDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string ContractTypeName { get; set; }
        [DataMember]
        public int RoleId { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }
        [DataMember]
        public float HourlySalary { get; set; }
        [DataMember]
        public float MonthtlySalary { get; set; }
        [DataMember]
        public float AnnualSalary { get { return MonthtlySalary * 12; } }
    }
}
